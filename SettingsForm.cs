using SDRSharp.Radio;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EnderIce2.SDRSharpPlugin
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            textBox1.Text = Utils.GetStringSetting("ClientID");
            checkBox1.Checked = Utils.GetBooleanSetting("LogRPC", false);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://ko-fi.com/enderice2") { UseShellExecute = true });
            Close();
        }

        private void Button1_Click(object sender, EventArgs e) => Close();

        private void CheckBox1_CheckedChanged(object sender, EventArgs e) => Utils.SaveSetting("ShowWelcomePage", !checkBox1.Checked);

        private void Button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("MIT License\n\nCopyright (c) 2018 Lachee\n\nPermission is hereby granted, free of charge, to any person obtaining a copy\nof this software and associated documentation files (the \"Software\"), to deal\nin the Software without restriction, including without limitation the rights\nto use, copy, modify, merge, publish, distribute, sublicense, and/or sell\ncopies of the Software, and to permit persons to whom the Software is\nfurnished to do so, subject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all\ncopies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,\nFITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE\nAUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER\nLIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,\nOUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE\nSOFTWARE.", "discord-rpc-csharp");
            MessageBox.Show("The MIT License (MIT)\n\nCopyright(c) 2007 James Newton-King\n\nPermission is hereby granted, free of charge, to any person obtaining a copy of\nthis software and associated documentation files (the \"Software\"), to deal in\nthe Software without restriction, including without limitation the rights to\nuse, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of\nthe Software, and to permit persons to whom the Software is furnished to do so,\nsubject to the following conditions:\n\nThe above copyright notice and this permission notice shall be included in all\ncopies or substantial portions of the Software.\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR\nIMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS\nFOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR\nCOPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER\nIN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN\nCONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.", "Newtonsoft.Json");
        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e) => Utils.SaveSetting("LogRPC", checkBox1.Checked);

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text.Replace(" ", "").Replace("\n", "").Replace("\r", "");
            if (!int.TryParse(textBox1.Text, out _) || textBox1.Text.Length != 18)
            {
                MessageBox.Show("Invalid Client ID!");
            }
            Utils.SaveSetting("ClientID", textBox1.Text);
            label1.Text = $"Configuration Updated.\nNew ID: {Utils.GetStringSetting("ClientID")}";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Utils.SaveSetting("ClientID", "765213507321856078");
            textBox1.Text = "765213507321856078";
        }
    }
}
