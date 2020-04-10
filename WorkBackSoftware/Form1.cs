using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkBackSoftware
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Useless_Events
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            fastCodingMethod();

        }

        private void fastCodingMethod() // Completed
        {
            string to = ToTXT.Text, from = FromTXT.Text;

            LogsTXT.Text += "\nGetting Paths";

            var diSource = new DirectoryInfo(from);
            var diTarget = new DirectoryInfo(to);

            LogsTXT.Text += "\nConverting Paths to Directory Info";

            LogsTXT.Text += "\nStarting Backup ...";

            CopyAll(diSource, diTarget);

            LogsTXT.Text += "\nBackup Finished";
        }

        private void driveFriendlyMethod() // Not Completed|Discontinued
        {
            string to = ToTXT.Text, from = FromTXT.Text;

            List<string> toFileList = createFileList(to);
            List<string> fromFilelist = createFileList(from);
            List<string> BackupFiles = fromFilelist.Except(toFileList).ToList();

            foreach (var item in BackupFiles)
            {

                //need to complete


            }
        }

        private List<String> createFileList(string dir) // Not in use|Discontinued
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(dir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(dir))
                {
                    files.AddRange(createFileList(d));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
