using SDRSharp.Radio;
using System;
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
            checkBox1.Checked = Utils.GetBooleanSetting("EnableRPC", true);
            LogWriter.WriteToFile("User Control Loaded");
        }

        private void SettingsButton_Click(object sender, EventArgs e) => new SettingsForm().Show();

        private void EnableRPC_CheckedChanged(object sender, EventArgs e)
        {
            Utils.SaveSetting("EnableRPC", checkBox1.Checked);
            label1.Text = "Restart required";
            LogWriter.WriteToFile($"checkbox on SettingsPanel clicked {checkBox1.Checked}");
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