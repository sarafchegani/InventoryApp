using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InventoryApp.Framwork
{
    public partial class MainFormBase : Form
    {
       
        private ViewEngine viewengine;
        public MainFormBase()
        {
            InitializeComponent();
           
        }
        public ViewEngine viewEngine
        {
            get
            {
                if (viewengine == null)
                    viewengine = new ViewEngine();
                return viewengine;
            }
        }
       
    }
}
