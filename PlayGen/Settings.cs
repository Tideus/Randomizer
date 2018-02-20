using System;
using System.Windows.Forms;


namespace PlayGen
{
    public partial class Settings : Form
    {
        
        bool onMP3 = PlayGen.Properties.Settings.Default.format_MP3;
        bool onWAW = PlayGen.Properties.Settings.Default.format_WAV;
        bool onFLAC = PlayGen.Properties.Settings.Default.format_FLAC;
        bool openFolder = PlayGen.Properties.Settings.Default.ToOpenFolders;

        StartForm form = null;
        public Settings(StartForm startForm)
        {
            InitializeComponent();
            LoadSetting();
            form = startForm;
        }

        void LoadSetting()
        {
            checkBoxMP3.Checked = onMP3;
            checkBoxWAV.Checked = onWAW;
            checkBoxFLAC.Checked = onFLAC;
            checkOpenFolder.Checked = openFolder;
        }

        void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            Save(form);           
        }
           
        void Save(StartForm startForm)
        {
            SaveSettings();
            startForm.Clear();
            this.Close();
        }

        void SaveSettings()
        {
            PlayGen.Properties.Settings.Default.format_MP3 = onMP3;
            PlayGen.Properties.Settings.Default.format_WAV = onWAW;
            PlayGen.Properties.Settings.Default.format_FLAC = onFLAC;
            PlayGen.Properties.Settings.Default.ToOpenFolders = openFolder;
            PlayGen.Properties.Settings.Default.Save();                   
        }

        void checkBoxFLAC_CheckedChanged(object sender, EventArgs e)
        {
            switch (((CheckBox)sender).Tag.ToString())
            {
                case "0": onMP3 = ((CheckBox)sender).Checked; break;
                case "1": onWAW = ((CheckBox)sender).Checked; break;
                case "2": onFLAC = ((CheckBox)sender).Checked; break;
                case "3": openFolder = ((CheckBox)sender).Checked; break;
                default: break;
            }
        }

        public static string[] GetAudioFormat()
        {

            int n = 3;
            int k = 0;

            string[] formats = new[] { ".mp3", ".wav", ".flac" };
            int[] countFormat = new int[3];

            if (Properties.Settings.Default.format_MP3)
            {
                countFormat[0] = 1;
            }
            else
            {
                countFormat[0] = 0;
                n--;
            }

            if (Properties.Settings.Default.format_WAV)
            {
                countFormat[1] = 1;
            }
            else
            {
                countFormat[1] = 0;
                n--;
            }

            if (Properties.Settings.Default.format_FLAC)
            {
                countFormat[2] = 1;
            }
            else
            {
                countFormat[2] = 0;
                n--;
            }

            string[] audioFormats = new string[n];

            for (int i = 0; i < countFormat.Length; i++)
            {
                if (countFormat[i] != 0)
                {
                    audioFormats[k] = formats[i];
                    k++;
                }
            }

            return audioFormats;
        }
    }
}