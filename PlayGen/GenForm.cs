using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO;



namespace PlayGen
{   
      
    public partial class StartForm : Form
    {
        #region MyPropirties
        public DirectoryInfo PathInfo
        {
            get { return pathInfo; }

            set { pathInfo = value; }
        }
        public FlowLayoutPanel Panel
        {
            get { return panel; }
            set { panel = value; }
        }
        public ToolStripProgressBar ProgressBar
        {
            get { return tSProgressBar; }
            set { tSProgressBar = value; }
        }

        public ToolStripLabel ProgressLabel
        {
            get { return progressLabel; }
            set { progressLabel = value; }
        }
        
        public TabControl TabPlaylist
        {
            get { return tabPlaylist; }
            set { tabPlaylist = value; }
        }
        public int Mode
        {
            get { return mode; }
            set { mode = value; }
        }
        public bool BlockShuffle
        {
            get { return blockShuffle; }

            set { blockShuffle = value; }
        }
        public bool AllShuffle
        {
            get { return allShuffle; }

            set { allShuffle = value; }
        }
        public ToolStripLabel TimeCount
        {
            get { return timeCount; }

            set { timeCount = value; }
        }
        #endregion

        #region PrivateFilds
        string MyDirectory = ""; // сейв для директорий

        ConrolFolder box = new ConrolFolder(); //экземпляр для отрисовки элементов на панели

        DirectoryInfo pathInfo = null;

        int mode = 0; // режим генерации     
        bool blockShuffle = false; //блочный рандом
        bool allShuffle = false; // перемешать все


        #endregion

        public StartForm()
        {
            InitializeComponent();
            Config();
        }

        public void Config()
        {
            panel.AllowDrop = true;
            panel.DragEnter += new DragEventHandler(panel_DragEnter);
            panel.DragDrop += new DragEventHandler(panel_DragDrop);

            
            ChangeBox.SelectedIndex = 0; // выбро режима генератора
        }

        private async void buttonAddPatch_Click(object sender, EventArgs e)
        {
          
            FolderBrowserDialog FBD = new FolderBrowserDialog();

            FBD.SelectedPath = MyDirectory;

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                MyDirectory = FBD.SelectedPath;
                textBoxPatch.Text = MyDirectory;
                PathInfo = new DirectoryInfo(MyDirectory); // папка с файлами

    

                if (ChangeBox.SelectedIndex == 0)
                {              
                    await Task.Factory.StartNew(() => box.GenConrol(this));
                }
                else
                {

                }
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }  

        public void Clear()
        {
            box.Clear(this);
            textBoxPatch.Clear();
            timeCount.Text = "00:00";
        }      

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "*.m3u";
            sfd.Filter = "M3U files|*.m3u|Text files|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK &&
                sfd.FileName.Length > 0)
            {
                for (int i = 0; i < tabPlaylist.TabCount; i++)
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName, true);
                    sw.WriteLine(tabPlaylist.TabPages[i].ToolTipText);
                    sw.WriteLine(tabPlaylist.TabPages[i].Controls.OfType<TextBox>().First().Text);
                    sw.Close();
                }
            }
        }

        private async void StartButton_Click(object sender, EventArgs e)
        {          
            if (ChangeBox.SelectedIndex == 0)
            {
                await Task.Factory.StartNew(() => box.GenTrackMode(this), TaskCreationOptions.LongRunning);
            }
        }

        private void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
                ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move))
                e.Effect = DragDropEffects.Move;
        }

        private async void panel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop) && e.Effect == DragDropEffects.Move)
            {
                string[] objects = (string[])e.Data.GetData(DataFormats.FileDrop);
                // В objects хранятся пути к папкам и файлам                         

                for (int i = 0; i < objects.Length; i++)
                {
                    textBoxPatch.Text = objects[i];

                    pathInfo = new DirectoryInfo(textBoxPatch.Text);

                    if (pathInfo.Exists)
                    {

                        if (ChangeBox.SelectedIndex == 0)
                        {

                            await Task.Factory.StartNew(() => box.GenConrol(this),
                                                        TaskCreationOptions.LongRunning);                            
                        }
                        else
                        {
                            //todo: реализовать одиночный режим
                        }
                    }
                }
            }
        }

        private void ChangeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChangeBox.SelectedIndex == 1)
            {
                box.Clear(this);
                Mode = 1;
            }
            else
            {
                box.Clear(this);
                Mode = 0;
            }
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked)
            {
                AllShuffle = true;
                BlockShuffle = false;

                radioButtonAll.ForeColor = System.Drawing.Color.Orange;
                radioButtonBlock.ForeColor = System.Drawing.Color.White;
                radioButtonNone.ForeColor = System.Drawing.Color.White;
            }
            if (radioButtonBlock.Checked)
            {
                AllShuffle = false;
                BlockShuffle = true;

                radioButtonAll.ForeColor = System.Drawing.Color.White;
                radioButtonBlock.ForeColor = System.Drawing.Color.Orange;
                radioButtonNone.ForeColor = System.Drawing.Color.White;
            }
            if (radioButtonNone.Checked)
            {
                AllShuffle = false;
                BlockShuffle = false;

                radioButtonAll.ForeColor = System.Drawing.Color.White;
                radioButtonBlock.ForeColor = System.Drawing.Color.White;
                radioButtonNone.ForeColor = System.Drawing.Color.Orange;
            }
        }

        private void labelCompany_MouseEnter(object sender, EventArgs e)
        {
            labelCompany.ForeColor = System.Drawing.Color.Orange;
        }

        private void labelCompany_MouseLeave(object sender, EventArgs e)
        {
            labelCompany.ForeColor = System.Drawing.Color.White;
        }

        private void labelCompany_Click(object sender, EventArgs e)
        {
            //todo: разкомментировать
            //System.Diagnostics.Process.Start("http://sinecuraweb.ru/");
        }

        private void расширенныеНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settingsForm = new Settings(this);
            settingsForm.ShowDialog();
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveButton_Click(sender, e);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }     
    }
}