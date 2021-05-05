using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using SDRSharp.Common;
using SDRSharp.Radio;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnderIce2.SDRSharpPlugin
{
    public class MainPlugin : ISharpPlugin
    {
        private const string _displayName = "Discord RPC";
        private SettingsPanel _controlPanel;
        private const LogLevel logLevel = LogLevel.Trace;
        private const int discordPipe = -1;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        bool RPCalreadyLoaded;
        private ISharpControl _control;
        bool playedBefore;
        private SDRSharp.FrontEnds.SpyServer.ControllerPanel controllerPanel;
        private TopWindowMessages windowMessages;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        private RichPresence presence = new RichPresence()
        {
            Details = "Loading...",
            State = "Loading...",
            Assets = new Assets()
            {
                LargeImageKey = "image_large",
                LargeImageText = "SDRSharp",
                SmallImageKey = "image_small",
                SmallImageText = $"SDR-RPC plugin v{Assembly.LoadFrom("SDR-RPC.dll").GetName().Version} by EnderIce2" // should show the correct version
            }
        };
        private DiscordRpcClient client;
        private bool isRunning = true;
        public string DisplayName => _displayName;
        public bool HasGui => true;
        public UserControl Gui => _controlPanel;
        public void Initialize(ISharpControl control)
        {
            IConfigurationPanelProvider configurationPanelProvider;

            if (Utils.GetBooleanSetting("ShowWelcomePage", true))
            {
                new WelcomeForm().ShowDialog();
            }

            _controlPanel = new SettingsPanel();
            windowMessages = new TopWindowMessages(); // TODO: do something when "EnableRPCInvite" is set to false
            _control = control;
            try
            {
                if (Utils.GetBooleanSetting("EnableRPCInvite", false))
                {
                    _control.RegisterFrontControl(windowMessages, PluginPosition.Top);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (Utils.GetBooleanSetting("EnableRPCInvite", false))
            {
                presence.Secrets = new Secrets()
                {
                    JoinSecret = "invalid_secret"
                };
                presence.Party = new Party()
                {
                    ID = Secrets.CreateFriendlySecret(new Random()),
                    Size = 1,
                    Max = 100
                };
            }

            if (Utils.GetBooleanSetting("EnableRPCInvite", false))
            {
                windowMessages.Show();
            }

            if (Utils.GetBooleanSetting("EnableRPC", true))
            {
                if (RPCalreadyLoaded)
                {
                    _controlPanel.ChangeStatus = "Restart required";
                    return;
                }
                if (Utils.GetStringSetting("ClientID").Replace(" ", "").Length != 18)
                {
                    client = new DiscordRpcClient("765213507321856078", pipe: discordPipe)
                    {
                        Logger = new ConsoleLogger(logLevel, true)
                    };
                }
                else
                {
                    client = new DiscordRpcClient(Utils.GetStringSetting("ClientID"), pipe: discordPipe)
                    {
                        Logger = new ConsoleLogger(logLevel, true)
                    };
                }

                client.RegisterUriScheme();
                client.OnRpcMessage += Client_OnRpcMessage;
                client.OnPresenceUpdate += Client_OnPresenceUpdate;
                client.OnReady += OnReady;
                client.OnClose += OnClose;
                client.OnError += OnError;
                client.OnConnectionEstablished += OnConnectionEstablished;
                client.OnConnectionFailed += OnConnectionFailed;
                client.OnSubscribe += OnSubscribe;
                client.OnUnsubscribe += OnUnsubscribe;
                client.OnJoin += OnJoin;
                client.OnJoinRequested += OnJoinRequested;
                presence.Timestamps = new Timestamps()
                {
                    Start = DateTime.UtcNow
                };

                if (Utils.GetBooleanSetting("EnableRPCInvite", false))
                {
                    client.SetSubscription(EventType.Join | EventType.JoinRequest);
                }

                client.SetPresence(presence);
                client.Initialize();
                try
                {
                    configurationPanelProvider = (IConfigurationPanelProvider)_control.Source;
                    controllerPanel = (SDRSharp.FrontEnds.SpyServer.ControllerPanel)configurationPanelProvider.Gui;
                }
                catch (Exception ex)
                {
                    LogWriter.WriteToFile("----> " + ex);
                    MessageBox.Show($"Cannot get Spy Server Network address\n\nError:\n{ex}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _ = MainLoop();
            }
            else
            {
                _controlPanel.ChangeStatus = "RPC is disabled";
            }
            LogWriter.WriteToFile("EOM Initialize");
        }
        private void Client_OnPresenceUpdate(object sender, PresenceMessage args)
        {
            LogWriter.WriteToFile($"[RpcMessage] | Presence state: {args.Presence.State}");
        }
        private void Client_OnRpcMessage(object sender, IMessage msg)
        {
            LogWriter.WriteToFile($"[RpcMessage] | {msg.Type} | {msg}");
        }
        private void OnConnectionFailed(object sender, ConnectionFailedMessage args)
        {
            _controlPanel.ChangeStatus = $"RPC Connection Failed!\n{args.Type} | {args.FailedPipe}";
        }
        private void OnConnectionEstablished(object sender, ConnectionEstablishedMessage args)
        {
            _controlPanel.ChangeStatus = "RPC Connection Established!";
        }
        private void OnError(object sender, ErrorMessage args)
        {
            _controlPanel.ChangeStatus = $"RPC Error:\n{args.Message}";
            windowMessages.ChangeLabel = "SDR# RPC | Internal error";
        }
        private void OnClose(object sender, CloseMessage args)
        {
            _controlPanel.ChangeStatus = "RPC Closed";
            windowMessages.ChangeLabel = "SDR# RPC | Closed";
            Close();
        }
        private void OnReady(object sender, ReadyMessage args)
        {
            _controlPanel.ChangeStatus = "RPC Ready";
            windowMessages.ChangeLabel = "SDR# RPC | Ready";
        }
        private void OnSubscribe(object sender, SubscribeMessage args)
        {
            _controlPanel.ChangeStatus = $"Subscribed: {args.Event}";
        }
        private void OnUnsubscribe(object sender, UnsubscribeMessage args)
        {
            _controlPanel.ChangeStatus = $"Unsubscribed: {args.Event}";
        }
        private void OnJoin(object sender, JoinMessage args)
        {
            presence.Party.Size++;
            presence.Secrets.JoinSecret = args.Secret;
            MessageBox.Show("OnJoin: " + args.Secret);
            _control.StopRadio();
            _control.RefreshSource(true);
            Utils.SaveSetting("spyserver.uri", args.Secret);
            _control.StartRadio();
        }
        private async void OnJoinRequested(object sender, JoinRequestMessage args)
        {
            try
            {
                if (await windowMessages.RequestAnswer(client, args))
                {
                    MessageBox.Show("Accepted RequestAnswer");
                }
                else
                {
                    MessageBox.Show("Declined RequestAnswer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        async Task MainLoop()
        {
            try
            {
                await Task.Delay(2000).ConfigureAwait(false);
                isRunning = true;
                LogWriter.WriteToFile($"MainLoop called {isRunning} {client.IsInitialized}");
                while (client != null && isRunning)
                {
                    if (Utils.GetBooleanSetting("EnableRPCInvite", false))
                    {
                        LogWriter.WriteToFile("Setting secret...");
                        try
                        {
                            string sdr_url = "sdr://" + controllerPanel.Host + ":" + controllerPanel.Port + "/";
                            LogWriter.WriteToFile(sdr_url);
                            presence.Secrets.JoinSecret = sdr_url;
                        }
                        catch (Exception ex)
                        {
                            LogWriter.WriteToFile(ex.ToString());
                        }
                    }
                    LogWriter.WriteToFile("Waiting 500ms in loop...");
                    await Task.Delay(500).ConfigureAwait(false);
                    if (_control.RdsRadioText != null)
                    {
                        if (_control.IsPlaying)
                        {
                            presence.Assets.SmallImageKey = "play";
                            playedBefore = true;
                        }
                        else if (!_control.IsPlaying && playedBefore)
                        {
                            presence.Assets.SmallImageKey = "pause";
                        }

                        if (!playedBefore)
                        {
                            presence.Details = "Frequency: Not playing";
                            presence.State = "RDS: Not playing";
                        }
                        else
                        {
                            try
                            {
                                string space_for_listen_list = " | ";
                                if (!Utils.GetBooleanSetting("EnableRPCInvite", false))
                                {
                                    space_for_listen_list = "";
                                }

                                LogWriter.WriteToFile($"Frequency: {_control.Frequency}");
                                LogWriter.WriteToFile($"RdsRadioText: {_control.RdsRadioText}");
                                LogWriter.WriteToFile($"RdsProgramService: {_control.RdsProgramService}");
                                LogWriter.WriteToFile("Setting presence...");
                                presence.Details = $"Frequency: {string.Format("{0:#,0,,0 Hz}", _control.Frequency)}";
                                if (string.IsNullOrWhiteSpace(_control.RdsRadioText + _control.RdsProgramService))
                                {
                                    presence.State = $"RDS: unknown{space_for_listen_list}";
                                }
                                else
                                {
                                    presence.State = $"RDS: {_control.RdsProgramService} - {_control.RdsRadioText}{space_for_listen_list}";
                                }
                            }
                            catch (Exception ex)
                            {
                                LogWriter.WriteToFile(ex.ToString());
                            }
                            /* presence.Secrets.JoinSecret = */
                            /* _control.RegisterFrontControl(Gui, PluginPosition.Top); */
                        }
                        try
                        {
                            client.SetPresence(presence);
                        }
                        catch (ObjectDisposedException ex)
                        {
                            LogWriter.WriteToFile($"ObjectDisposedException exception for SetPresence\n{ex}");
                        }
                        LogWriter.WriteToFile("SetPresence");
                        _controlPanel.ChangeStatus = $"Presence Updated {DateTime.UtcNow}";
                    }
                    else
                    {
                        LogWriter.WriteToFile("Frequency or Radio Text are null!");
                        await Task.Delay(1000).ConfigureAwait(false);
                    }
                }
                if (client == null)
                {
                    _controlPanel.ChangeStatus = "Client was null";
                }
                else
                {
                    _controlPanel.ChangeStatus = "Presence stopped";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The process cannot access the file"))
                {
                    _ = MainLoop();
                    return;
                }
                _controlPanel.ChangeStatus = $"RPC Update Error\n{ex.Message}";
                LogWriter.WriteToFile(ex.ToString());
            }
        }
        public void Close()
        {
            LogWriter.WriteToFile("Close called");
            isRunning = false;
            client.Dispose();
        }
    }
}