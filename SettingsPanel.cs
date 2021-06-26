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
            LogWriter.WriteToFile("SettingsPanel loaded");
        }

        private void Button1_Click(object sender, EventArgs e) => new SettingsForm().Show();

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Utils.SaveSetting("EnableRPC", checkBox1.Checked);
            label1.Text = "Restart required";
            LogWriter.WriteToFile($"checkbox on SettingsPanel clicked {checkBox1.Checked}");
            /* Utils.GetBooleanSetting("EnableRPC"); */
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e) => Utils.SaveSetting("LogRPC", checkBox2.Checked);

        private async void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBox1.Text.Replace(" ", "");
            if (!int.TryParse(textBox1.Text, out _))
            {
                MessageBox.Show("Invalid ID!");
            }
            if (e.KeyCode == Keys.Enter && textBox1.Text.Length == 18)
            {
                Utils.SaveSetting("ClientID", textBox1.Text);
            }
            else if (e.KeyCode == Keys.Enter && textBox1.Text.Length != 18)
            {
                Utils.SaveSetting("ClientID", "765213507321856078"); // TODO: do it better
            }
            e.Handled = true;
            e.SuppressKeyPress = true;
            await Task.Delay(100).ConfigureAwait(false);
            textBox1.Text = Utils.GetStringSetting("ClientID"); // write what we stored, should not trigger keydown event
            label1.Text = $"Configuration Updated.\nNew ID: {Utils.GetStringSetting("ClientID")}";
        }

        private void SettingsPanel_Load(object sender, EventArgs e)
        {
            // can't use bcz System.Drawing.Color is from dotnet core 5
            //MainPlugin._control.ThemeForeColor;
            //BackColor = MainPlugin._control.ThemePanelColor;
            //MainPlugin._control.ThemeBackColor;
            BackColor = System.Drawing.Color.FromArgb(15, 15, 15);
            ForeColor = System.Drawing.Color.FromArgb(244, 244, 244);
        }
    }
}