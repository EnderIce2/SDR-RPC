using DiscordRPC;
using DiscordRPC.Message;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnderIce2.SDRSharpPlugin
{
    public partial class TopWindowMessages : UserControl
    {
        public TopWindowMessages()
        {
            InitializeComponent();
        }
        private string _ChangeLabel;
        public string ChangeLabel
        {
            get
            {
                return _ChangeLabel;
            }
            set
            {
                _ChangeLabel = value;
                label1.Text = value;
                LogWriter.WriteToFile(value);
            }
        }
        private bool AnswerA;
        private bool AnswerD;
        public async Task<bool> RequestAnswer(DiscordRpcClient client, JoinRequestMessage args)
        {
            LogWriter.WriteToFile("Incoming RPC request from " + args.User.Username);
            button1.Visible = true;
            button2.Visible = true;
            ChangeLabel = $"SDR# RPC | {args.User.Username} has requested to get Spy Server Network address.";
            while (!AnswerA || !AnswerD) // TODO: Rework
            {
                LogWriter.WriteToFile("waiting...");
                Application.DoEvents();
                await Task.Delay(200).ConfigureAwait(false);
            }
            bool tmpansw = AnswerA;
            LogWriter.WriteToFile($"Client sent an answer. {tmpansw}");
            client.Respond(args, tmpansw);
            AnswerA = false;
            AnswerD = false;
            button1.Visible = false;
            button2.Visible = false;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            SetDefaultTextInLabel(tmpansw);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            return tmpansw;
        }
        private async Task SetDefaultTextInLabel(bool accepted)
        {
            if (accepted)
            {
                ChangeLabel = $"SDR# RPC | Request accepted";
            }
            else
            {
                ChangeLabel = $"SDR# RPC | Request declined";
            }

            await Task.Delay(5000).ConfigureAwait(false);
            ChangeLabel = $"SDR# RPC | Ready";
        }
    }
}
