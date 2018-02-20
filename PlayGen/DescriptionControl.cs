using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayGen
{
    public partial class DescriptionControl : UserControl
    {
        public DescriptionControl()
        {
            InitializeComponent();
        }

        public CheckBox InnerShuffle
        {
            get
            {
                return checkBoxInnerShuffle;
            }
            set
            {
                checkBoxInnerShuffle = value;
            }
        }
          
    }
}
