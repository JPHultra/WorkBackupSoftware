﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            notifyIcon1.Text = "Work Backup Software";
            notifyIcon1.Visible = false;
            notifyIcon1.Icon = this.Icon;

            notifyIcon1.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon1.ContextMenuStrip.Items.Add("Start Backup", null, this.MenuBackup_Click);
            notifyIcon1.ContextMenuStrip.Items.Add("Quit", null, this.MenuExit_Click);

            if (File.Exists(@"settings.wbs"))
            {
                LoadSettings();
            }

            string[] args = Environment.GetCommandLineArgs();

            if (args[0] == "auto")
            {
                autoBackup(args[1], args[2]);
            }
        }
        
        private void MenuBackup_Click(object sender, EventArgs e)
        {
            backup();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private static readonly Stopwatch watch = new Stopwatch();

        #region Useless_Events
        private void label1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

            backup();

        }

        private void backup() // Completed
        {
            try
            {
                watch.Start();
                LogsTXT.Text = "";

                string to = ToTXT.Text, from = FromTXT.Text;

                AddLog("Getting Paths");

                var diSource = new DirectoryInfo(from);
                var diTarget = new DirectoryInfo(to);

                AddLog("Converting Paths to Directory Info");

                AddLog("Starting Backup ...");

                AddLog("");

                CopyAll(diSource, diTarget);

                AddLog("");

                AddLog("Backup Finished");

                AddLog("Time Elapsed: " + watch.Elapsed.Hours + "h:" + watch.Elapsed.Minutes + "m:" + watch.Elapsed.Seconds + "s");

                notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;

                notifyIcon1.BalloonTipText = "Time Elapsed: " + watch.Elapsed.Hours + "h:" + watch.Elapsed.Minutes + "m:" + watch.Elapsed.Seconds + "s";

                notifyIcon1.BalloonTipTitle = "Backup Finished!";

                notifyIcon1.ShowBalloonTip(5000);

                watch.Stop();
                watch.Reset();
            }
            catch (Exception)
            {
                MessageBox.Show("Check if selected Path's are valid or for any typing errors!", "Critical Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void autoBackup(string to, string from) // Completed
        {

            AddLog("Getting Paths");

            var diSource = new DirectoryInfo(from);
            var diTarget = new DirectoryInfo(to);

            AddLog("Converting Paths to Directory Info");

            AddLog("Starting Backup ...");

            AddLog("");

            CopyAll(diSource, diTarget);

            AddLog("");

            AddLog("Backup Finished");

            Environment.Exit(0);
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

        public void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                Directory.CreateDirectory(target.FullName);
                
                // Copy each file into the new directory.
                foreach (FileInfo fi in source.GetFiles())
                {
                    if (!File.Exists(target.ToString() + @"\" + fi.Name) || (File.GetLastWriteTime(source.ToString() + @"\" + fi.Name) > File.GetLastWriteTime(target.ToString() + @"\" + fi.Name)))
                    {
                        AddLog("Copying " + target.FullName + @"\" + fi.Name);
                        fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                    }
                    else
                    {
                        AddLog(target.FullName + @"\" + fi.Name + " Already exists. Skipping...");
                    }
                }

                // Copy each subdirectory using recursion.
                foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
                {
                    DirectoryInfo nextTargetSubDir =
                        target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Invalid Path!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveSettingsBTN_Click(object sender, EventArgs e)
        {

            string[] linhas = new string[2];

            linhas[0] = "to|" + ToTXT.Text;
            linhas[1] = "from|" + FromTXT.Text;

            System.IO.File.WriteAllLines(@"settings.wbs", linhas);

            MessageBox.Show("Settings Were Saved!", "Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void LoadSettings()
        {
            string[] lines = System.IO.File.ReadAllLines(@"settings.wbs");

            for (int i = 0; i < lines.Length; i++)
            {
                string[] SeparateSettings = lines[i].Split('|');

                if (i==0)
                {
                    ToTXT.Text = SeparateSettings[1];
                }
                else if(i == 1)
                {
                    FromTXT.Text = SeparateSettings[1];
                }
            }
        }

        private void ToOpenBTN_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {

                    ToTXT.Text = fbd.SelectedPath.ToString();
                }
            }
        }

        private void FromOpenBTN_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    FromTXT.Text = fbd.SelectedPath.ToString();
                }
            }
        }

        private void AddLog(string text)
        {
            LogsTXT.AppendText(text);
            LogsTXT.AppendText(Environment.NewLine);
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }

        }
    }
}
