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
        private SettingsPanel _controlPanel;
        private const LogLevel logLevel = LogLevel.Trace;
        private const int discordPipe = -1;

        private ISharpControl _control;
        private bool playedBefore;

        private DiscordRpcClient client;
        private bool isRunning = true;
        public bool HasGui => true;
        public string DisplayName => "Discord RPC";
        public UserControl Gui => _controlPanel;

        private readonly RichPresence presence = new RichPresence()
        {
            Details = "Loading...",
            State = "Loading...",
            Assets = new Assets()
            {
                LargeImageKey = "image_large",
                LargeImageText = "SDRSharp",
                SmallImageKey = "image_small",
                SmallImageText = $"SDR-RPC Plugin v{Assembly.LoadFrom("SDR-RPC.dll").GetName().Version}"
            }
        };

        public void Initialize(ISharpControl control)
        {
            _controlPanel = new SettingsPanel();
            _control = control;
            if (Utils.GetBooleanSetting("EnableRPC", true))
            {
                if (Utils.GetStringSetting("ClientID").Replace(" ", "").Length != 18)
                {
                    Utils.SaveSetting("ClientID", "765213507321856078");
                }
                client = new DiscordRpcClient(Utils.GetStringSetting("ClientID"), pipe: discordPipe)
                {
                    Logger = new ConsoleLogger(logLevel, true)
                };

                client.RegisterUriScheme();
                client.OnRpcMessage += Client_OnRpcMessage;
                client.OnPresenceUpdate += Client_OnPresenceUpdate;
                client.OnReady += OnReady;
                client.OnClose += OnClose;
                client.OnError += OnError;
                client.OnConnectionEstablished += OnConnectionEstablished;
                client.OnConnectionFailed += OnConnectionFailed;
                presence.Timestamps = new Timestamps()
                {
                    Start = DateTime.UtcNow
                };
                client.SetPresence(presence);
                client.Initialize();
                _ = MainLoop();
            }
            else
            {
                _controlPanel.ChangeStatus = "RPC is disabled";
            }
            LogWriter.WriteToFile("EOM Initialize");
        }

        private async Task MainLoop()
        {
            loop_start:
            try
            {
                await Task.Delay(2000).ConfigureAwait(false);
                isRunning = true;
                LogWriter.WriteToFile($"MainLoop called {isRunning} {client.IsInitialized}");
                while (client != null && isRunning)
                {
                    LogWriter.WriteToFile("Waiting 5000ms in loop...");
                    await Task.Delay(5000).ConfigureAwait(false); // 5 second delay
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
                                LogWriter.WriteToFile($"Frequency: {_control.Frequency}");
                                LogWriter.WriteToFile($"RdsRadioText: {_control.RdsRadioText}");
                                LogWriter.WriteToFile($"RdsProgramService: {_control.RdsProgramService}");
                                LogWriter.WriteToFile("Setting presence...");
                                presence.Details = $"Frequency: {$"{_control.Frequency:#,0,,0 Hz}"}";
                                presence.State = string.IsNullOrWhiteSpace(_control.RdsRadioText + _control.RdsProgramService)
                                    ? "RDS: unknown"
                                    : _control.FmStereo
                                        ? $"RDS: ((( {_control.RdsProgramService} ))) - {_control.RdsRadioText}"
                                        : $"RDS: {_control.RdsProgramService} - {_control.RdsRadioText}";
                            }
                            catch (Exception ex)
                            {
                                LogWriter.WriteToFile(ex.ToString());
                            }
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
                    goto loop_start;
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

        private void Client_OnPresenceUpdate(object sender, PresenceMessage args) => LogWriter.WriteToFile($"[RpcMessage] | Presence state: {args.Presence.State}");

        private void Client_OnRpcMessage(object sender, IMessage msg) => LogWriter.WriteToFile($"[RpcMessage] | {msg.Type} | {msg}");

        private void OnConnectionFailed(object sender, ConnectionFailedMessage args) => _controlPanel.ChangeStatus = $"RPC Connection Failed!\n{args.Type} | {args.FailedPipe}";

        private void OnConnectionEstablished(object sender, ConnectionEstablishedMessage args) => _controlPanel.ChangeStatus = "RPC Connection Established!";

        private void OnError(object sender, ErrorMessage args) => _controlPanel.ChangeStatus = $"RPC Error:\n{args.Message}";

        private void OnClose(object sender, CloseMessage args)
        {
            _controlPanel.ChangeStatus = "RPC Closed";
            Close();
        }

        private void OnReady(object sender, ReadyMessage args) => _controlPanel.ChangeStatus = "RPC Ready";
    }
}