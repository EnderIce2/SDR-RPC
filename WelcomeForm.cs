using SDRSharp.Radio;
using System;
using System.Windows.Forms;

namespace EnderIce2.SDRSharpPlugin
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://ko-fi.com/enderice2");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Utils.SaveSetting("ShowWelcomePage", !checkBox1.Checked);
        }
    }
}
