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
using DiscUtils;
using DiscUtils.Iso9660;
using System.IO;

namespace Materialform
{
    public partial class Form3 : MaterialForm
    {
        public Form3()
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open iso File";
            theDialog.Filter = "iso files|*.iso";
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                input.Text = theDialog.FileName;
            }
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog inp = new FolderBrowserDialog();
            inp.Description = "select output folder";
            if (inp.ShowDialog() == DialogResult.OK)
            {
                output.Text = inp.SelectedPath;
            }
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Iso to dump conversion started\npress ok to continue");
            ExtractISO(input.Text, output.Text);
            MessageBox.Show("Iso converted to dump");
        }

        void ExtractISO(string ISOName, string ExtractionPath)
        {
            using (FileStream ISOStream = File.Open(ISOName, FileMode.Open))
            {
                try
                {
                    var Reader = new DiscUtils.Udf.UdfReader(ISOStream);
                    ExtractDirectory(Reader.Root, ExtractionPath + "\\", "");
                    Reader.Dispose();
                } catch
                {
                    CDReader Reader = new CDReader(ISOStream, true, true);
                    ExtractDirectory(Reader.Root, ExtractionPath + "\\", "");
                    Reader.Dispose();
                }
            }
        }
        void ExtractDirectory(DiscDirectoryInfo Dinfo, string RootPath, string PathinISO)
        {
            if (!string.IsNullOrWhiteSpace(PathinISO))
            {
                PathinISO += "\\" + Dinfo.Name;
            }
            RootPath += "\\" + Dinfo.Name;
            AppendDirectory(RootPath);
            foreach (DiscDirectoryInfo dinfo in Dinfo.GetDirectories())
            {
                ExtractDirectory(dinfo, RootPath, PathinISO);
            }
            foreach (DiscFileInfo finfo in Dinfo.GetFiles())
            {
                using (Stream FileStr = finfo.OpenRead())
                {
                    using (FileStream Fs = File.Create(RootPath + "\\" + finfo.Name)) // Here you can Set the BufferSize Also e.g. File.Create(RootPath + "\\" + finfo.Name, 4 * 1024)
                    {
                        FileStr.CopyTo(Fs, 4 * 1024); // Buffer Size is 4 * 1024 but you can modify it in your code as per your need
                    }
                }
            }
        }
        static void AppendDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
            }
            catch (DirectoryNotFoundException Ex)
            {
                AppendDirectory(Path.GetDirectoryName(path));
            }
            catch (PathTooLongException Exx)
            {
                AppendDirectory(Path.GetDirectoryName(path));
            }
        }
    }
}
