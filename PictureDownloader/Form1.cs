using System;
using System.IO;
using System.Windows.Forms;

namespace PictureDownloader
{
    public partial class Form1 : Form
    {
        public static Form1 f;

        public Form1()
        {
            InitializeComponent();
            output.Text = Application.StartupPath;
            folderBrowserDialog1.SelectedPath = Application.StartupPath;
            f = this;
            CheckForIllegalCrossThreadCalls = false;
            log("启动下载器");
        }

        private void start_ValueChanged(object sender, EventArgs e)
        {
            if (start.Value > end.Value)
            {
                if (Config.setEnd((int)start.Value)) end.Value = Config.getEnd();
                else
                {
                    start.Value = Config.getStart();
                    return;
                }
            }
            if (!Config.setStart((int)start.Value)) start.Value = Config.getStart();
        }

        private void end_ValueChanged(object sender, EventArgs e)
        {
            if (start.Value > end.Value) end.Value = start.Value;
            if (!Config.setEnd((int)end.Value)) end.Value = Config.getEnd();
        }

        private void output_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) output_Leave(sender, e);
        }

        private void output_Leave(object sender, EventArgs e)
        {
            if (Directory.Exists(output.Text)) folderBrowserDialog1.SelectedPath = output.Text;
            else output.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) output.Text = folderBrowserDialog1.SelectedPath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Config.setURL(url.Text);
            url.Enabled = false;
            Config.setCookie(cookie.Text);
            cookie.Enabled = false;
            start.Enabled = false;
            end.Enabled = false;
            Config.setLength((int)length.Value);
            length.Enabled = false;
            Config.setOutput(output.Text);
            output.Enabled = false;
            button1.Enabled = false;
            Config.setDirect(direct.Checked);
            direct.Enabled = false;
            Config.setThreads((int)threads.Value);
            threads.Enabled = false;
            button2.Enabled = false;
            ProgressManager.startProgress();
        }

        public void updateProgress(int current, int max)
        {
            progress.Maximum = max * 100;
            progress.Value = current * 100;
            if (current == max)
            {
                url.Enabled = true;
                // cookie.Enabled = true;
                start.Enabled = true;
                end.Enabled = true;
                length.Enabled = true;
                output.Enabled = true;
                button1.Enabled = true;
                direct.Enabled = true;
                threads.Enabled = true;
                button2.Enabled = true;
            }
        }

        public void log(string log)
        {
            lock(logger)
            {
                logger.Text += "[" + DateTime.Now.ToLocalTime() + "] " + log + "\r\n";
                logger.SelectionStart = logger.Text.Length;
                logger.ScrollToCaret();
            }
        }
    }
}
