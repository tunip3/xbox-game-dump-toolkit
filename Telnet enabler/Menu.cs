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
using System.IO;
using System.Resources;
using System.Diagnostics;

namespace Materialform
{
    public partial class Menu : MaterialForm
    {
        public Menu()
        {
            InitializeComponent();
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

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            this.Hide();
            form1.Show();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            this.Hide();
            form2.Show();
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            this.Hide();
            form3.Show();
        }

        private void MaterialFlatButton4_Click(object sender, EventArgs e)
        {
            var outPath = Path.GetTempPath() + "driveconverter.exe";
            if (File.Exists(outPath)) {
                File.Delete(outPath);
            }
            File.WriteAllBytes(outPath, GameDumpToolkit.Properties.Resources.Drive_Converter);
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = true;
            // You can start any process, HelloWorld is a do-nothing example.
            myProcess.StartInfo.FileName = outPath;
            myProcess.Start();
            // This code assumes the process you are starting will terminate itself.
            // Given that is is started without a window so you cannot terminate it
            // on the desktop, it must terminate itself or you can do it programmatically
            // from this application using the Kill method.
            this.Close();
        }
    }
}
