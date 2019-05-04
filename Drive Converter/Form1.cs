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
using XBOX_One_Drive_Converter;
using System.IO;

namespace Drive_Converter
{
    public partial class Form1 : MaterialForm
    {
        public Form1()
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
            this.refreshDrives();
        }

        private void refreshDrives()
        {
            Cursor.Current = Cursors.WaitCursor;
            List<DeviceManager.XBOX_External_Storage_Device> list = DeviceManager.ParsePhysicalDrives();
            this.DetectedXBOXDrivesGridView.Rows.Clear();
            foreach (DeviceManager.XBOX_External_Storage_Device xbox_External_Storage_Device in list)
            {
                this.DetectedXBOXDrivesGridView.Rows.Add(new object[]
                {
                    xbox_External_Storage_Device.DeviceName,
                    xbox_External_Storage_Device.DeviceCaption,
                    xbox_External_Storage_Device.DeviceMode
                });
            }
            Cursor.Current = Cursors.Default;
            if (list.Count == 0)
            {
                MessageBox.Show("No Xbox One external storage devices found.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void MaterialFlatButton3_Click(object sender, EventArgs e)
        {
            this.refreshDrives();
        }

        private void MaterialFlatButton2_Click(object sender, EventArgs e)
        {
            int chosendrive = DetectedXBOXDrivesGridView.CurrentRow.Index;
            var devicename = DetectedXBOXDrivesGridView.Rows[chosendrive].Cells["DeviceName"].Value.ToString();
            var caption = DetectedXBOXDrivesGridView.Rows[chosendrive].Cells["DeviceCaption"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to convert\n" + caption, "Convert drive", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                DeviceManager.ChangeDeviceMode(devicename, DeviceManager.DeviceMode.PC);
                this.refreshDrives();
                Cursor.Current = Cursors.Default;
            }
        }

        private void MaterialFlatButton1_Click(object sender, EventArgs e)
        {
            int chosendrive = DetectedXBOXDrivesGridView.CurrentRow.Index;
            var devicename = DetectedXBOXDrivesGridView.Rows[chosendrive].Cells["DeviceName"].Value.ToString();
            var caption = DetectedXBOXDrivesGridView.Rows[chosendrive].Cells["DeviceCaption"].Value.ToString();
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to convert\n" + caption, "Convert drive", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                DeviceManager.ChangeDeviceMode(devicename, DeviceManager.DeviceMode.Xbox);
                this.refreshDrives();
                Cursor.Current = Cursors.Default;
            }
        }

        private void DetectedXBOXDrivesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
