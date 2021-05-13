using SDRSharp.Radio;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnderIce2.SDRSharpPlugin
{
    public partial class SettingsPanel : UserControl
    {
        private string _ChangeStatus;
        public string ChangeStatus
        {
            get => _ChangeStatus;
            set
            {
                _ChangeStatus = value;
                label1.Text = value;
                LogWriter.WriteToFile(value);
            }
        }
        public SettingsPanel()
        {
            InitializeComponent();
            textBox1.Text = Utils.GetStringSetting("ClientID");
            checkBox1.Checked = Utils.GetBooleanSetting("EnableRPC", true);
            checkBox2.Checked = Utils.GetBooleanSetting("LogRPC", false);
            checkBox3.Checked = Utils.GetBooleanSetting("EnableRPCInvite", false);
            LogWriter.WriteToFile("SettingsPanel loaded");
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Utils.SaveSetting("EnableRPC", checkBox1.Checked);
            label1.Text = "Restart required";
            LogWriter.WriteToFile($"checkbox on SettingsPanel clicked {checkBox1.Checked}");
            /* Utils.GetBooleanSetting("EnableRPC"); */
        }

        private void Button1_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://github.com/EnderIce2/SDR-RPC");

        private void CheckBox2_CheckedChanged(object sender, EventArgs e) => Utils.SaveSetting("LogRPC", checkBox2.Checked);

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private async void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox1.Text.Replace(" ", "").Length == 18)
            {
                Utils.SaveSetting("ClientID", textBox1.Text);
                e.Handled = true;
                e.SuppressKeyPress = true;
                await Task.Delay(200).ConfigureAwait(false);
                textBox1.Text = Utils.GetStringSetting("ClientID");
                label1.Text = "Saved.";
            }
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            Utils.SaveSetting("EnableRPCInvite", checkBox3.Checked);
            label1.Text = "Restart required";
            LogWriter.WriteToFile($"checkbox on SettingsPanel clicked {checkBox3.Checked}");
        }
    }
}