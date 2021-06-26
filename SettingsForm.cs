using SDRSharp.Radio;
using System;
using System.Windows.Forms;

namespace EnderIce2.SDRSharpPlugin
{
    public partial class SettingsForm : Form
    {
        public SettingsForm() => InitializeComponent();

        private void Button2_Click(object sender, EventArgs e) => System.Diagnostics.Process.Start("https://ko-fi.com/enderice2");

        private void Button1_Click(object sender, EventArgs e) => Close();

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) => Utils.SaveSetting("ShowWelcomePage", !checkBox1.Checked);
    }
}

            //try
            //{
            //    System.Diagnostics.Process.Start("https://github.com/EnderIce2/SDR-RPC"); // open the url (on some systems can show "The system cannot find the file specified.")
            //}
            //catch (System.ComponentModel.Win32Exception) // The system cannot find the file specified.
            //{
            //    try
            //    {
            //        System.Diagnostics.Process.Start("iexplore", "https://github.com/EnderIce2/SDR-RPC"); // open the url with internet explorer
            //    }
            //    catch (System.ComponentModel.Win32Exception) // The system cannot find the file specified.
            //    {
            //        System.Diagnostics.Process.Start("notepad", "https://github.com/EnderIce2/SDR-RPC"); // if internet explorer is not installed (idk how we can get to that point but whatever), open the link in notepad
            //    }
            //}