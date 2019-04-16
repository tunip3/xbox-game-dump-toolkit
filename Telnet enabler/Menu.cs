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
    }
}
