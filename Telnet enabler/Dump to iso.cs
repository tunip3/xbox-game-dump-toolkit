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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using IMAPI2.Interop;
using System.IO;

namespace Materialform
{
    public partial class Form2 : MaterialForm
    {
        [DllImport("shlwapi.dll", CharSet = CharSet.Unicode)]
        static internal extern uint SHCreateStreamOnFile
    (string pszFile, uint grfMode, out IStream ppstm);

        public Form2()
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog inp = new FolderBrowserDialog();
            inp.Description = "select input folder";
            if (inp.ShowDialog() == DialogResult.OK)
            {
                input.Text = inp.SelectedPath;
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();      
            saveFileDialog1.Title = "Save iso file";
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "iso";
            saveFileDialog1.Filter = "Optical disk image (*.iso)|*.iso|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                output.Text = saveFileDialog1.FileName;
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            bool correctdump = false;
            if (Directory.Exists(input.Text + "\\MSXC"))
            {
                if (Directory.Exists(input.Text + "\\Licenses"))
                {
                    correctdump = true;
                }
            }
            if (correctdump)
            {
                IFileSystemImage ifsi = new MsftFileSystemImage();
                ifsi.ChooseImageDefaultsForMediaType(IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_DISK);
                ifsi.FileSystemsToCreate = FsiFileSystems.FsiFileSystemUDF;
                ifsi.VolumeName = "DVD_ROM";
                ifsi.Root.AddTree(input.Text, true);//use a valid folder
                                                    //this will implement the Write method for the formatter
                IStream imagestream = ifsi.CreateResultImage().ImageStream;
                if (imagestream != null)
                {
                    System.Runtime.InteropServices.ComTypes.STATSTG stat;
                    imagestream.Stat(out stat, 0x01);
                    IStream newStream;
                    if (0 == SHCreateStreamOnFile
                        (output.Text, 0x00001001, out newStream) && newStream != null)
                    {
                        IntPtr inBytes = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(long)));
                        IntPtr outBytes = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(long)));
                        try
                        {
                            imagestream.CopyTo(newStream, stat.cbSize, inBytes, outBytes);
                            Marshal.ReleaseComObject(imagestream);
                            imagestream = null;
                            newStream.Commit(0);
                        }
                        finally
                        {
                            Marshal.ReleaseComObject(newStream);
                            Marshal.FreeHGlobal(inBytes);
                            Marshal.FreeHGlobal(outBytes);
                            if (imagestream != null)
                                Marshal.ReleaseComObject(imagestream);
                        }
                    }
                }
                Marshal.ReleaseComObject(ifsi);
                MessageBox.Show("Dump converted to iso");
            }
            else
            {
                MessageBox.Show("The path given: \n" + input.Text+"\n"+"appears to be an incorrect dump, check this path and try again"+"\n"+"if you still get this error you should try redumping the title"+"\n"+"in the case that all of the suggestions have failed you should"+"\n"+"ask for help on the Xbox One homebrew discord");
            }
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void input_Click(object sender, EventArgs e)
        {

        }

        private void output_Click(object sender, EventArgs e)
        {

        }
    }
}
