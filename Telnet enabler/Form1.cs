using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Renci.SshNet.Common;
using Renci.SshNet;

namespace Materialform
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
            IP.Text = "XBOXONE";
            // Create a material theme manager and add the form to manage (this)
            MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Configure color schema
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue400, Primary.Blue500,
                Primary.Blue500, Accent.LightBlue200,
                TextShade.WHITE);
        }
        public string ip = "XBOXONE";
        public string code;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            var client = new SshClient(ip, "DevToolsUser", vspaircode.Text);
            //connect to the xbox one
            client.Connect();
            //create a tost to say that the game is being dumped
            client.RunCommand("J:\\unattendedsetuphelper.exe toast game%20being%20dumped");
            MessageBox.Show("game being dumped");
            //dump game then create a toast to say that the game has been dumped
            client.RunCommand("J:\\tools\\xcopy.exe o:\\ e:\\diskdumps\\" + gamename.Text + " /I /E /H && J:\\unattendedsetuphelper.exe toast finished%20dumping%20game");
            //disconnect
            MessageBox.Show("game finished dumping");
            client.Disconnect();
        }

        private void IP_Click(object sender, EventArgs e)
        {
            
        }

        private void IP_TextChanged(object sender, EventArgs e)
        {
            ip = IP.Text;
        }

        private void vspaircode_TextChanged(object sender, EventArgs e)
        {
            code = vspaircode.Text;
        }
    }
}
