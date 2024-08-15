using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDRSharp.Common;
using SDRSharp.Radio;
using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using EnderIce2.SDRSharpPlugin;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace EnderIce2.SDRSharpPlugin
{
    public partial class ControlPanel : UserControl
    {
        private string _ChangeStatus;
        private ISharpControl _control;

        public string ChangeStatus
        {
            get => _ChangeStatus;
            set
            {
                _ChangeStatus = value;
                statusLbl.Text = value;
                LogWriter.WriteToFile(value);
            }
        }

        public ControlPanel(ISharpControl control)
        {
            _control = control;
            InitializeComponent();
            versionLbl.Text = $"v{Assembly.GetExecutingAssembly().GetName().Version.ToString()}";
            IDtxtBox.Text = Utils.GetStringSetting("ClientID");
            dbgCheckBox.Checked = Utils.GetBooleanSetting("LogRPC", false);
        }

        private void IDtxtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            IDtxtBox.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "");

            if (IDtxtBox.Text.All(char.IsWhiteSpace))
            {
                IDtxtBox.Text = "765213507321856078";
            }

            Utils.SaveSetting("ClientID", IDtxtBox.Text);
            ChangeStatus = "Configuration Updated";
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void dbgCheckBox_CheckedChanged(object sender, EventArgs e) => Utils.SaveSetting("LogRPC", dbgCheckBox.Checked);

        private void versionLbl_DoubleClick(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://enderice2.github.io/SDR-RPC/") { UseShellExecute = true });
        }

        private void helpBtn_Click(object sender, EventArgs e) => new HelpForm().ShowDialog();

        private void creditsBtn_Click(object sender, EventArgs e) => new CreditsForm().ShowDialog();
    }
}