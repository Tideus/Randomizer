using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlayGen
{
    public partial class UIControl : UserControl
    {
        public UIControl()
        {
            InitializeComponent();
        }

        public Label NumerLabel
        {
            get
            {
                return labelNumer;
            }

            set
            {
                labelNumer = value;
            }
        }

        public TextBox TextBoxFolder
        {
            get
            {
                return textBoxPath;
            }

            set
            {
                textBoxPath = value;
            }
        }

        public NumericUpDown NumericHours
        {
            get
            {
                return numericHours;
            }

            set
            {
                numericHours = value;
            }
        }

        public NumericUpDown NumericMinutes
        {
            get
            {
                return numericMinutes;
            }

            set
            {
                numericMinutes = value;
            }
        }

        public Label MaxTime
        {
            get
            {
                return labelMaxTime;
            }

            set
            {
                labelMaxTime = value;
            }
        }

        public CheckBox TrackMix
        {
            get { return trackMix; }

            set { trackMix = value; }
        }

        public CheckBox DirectoryMix
        {
            get { return directoryMix; }

            set { directoryMix = value; }
        }

        private void directoryMix_CheckedChanged(object sender, EventArgs e)
        {
            if (DirectoryMix.Checked)
            {
                DirectoryMix.BackColor = Color.Pink;
            }

            else
            {
                DirectoryMix.BackColor = Color.White;
            }
        }

        private void trackMix_CheckedChanged(object sender, EventArgs e)
        {
            if (TrackMix.Checked)
            {
                TrackMix.BackColor = Color.LightGreen;
            }

            else
            {
                TrackMix.BackColor = Color.White;
            }
        }
    }
}
