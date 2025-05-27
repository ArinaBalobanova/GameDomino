using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Domino2
{
    public partial class MainWindow : Form
    {
        private Guid _userId;
        public MainWindow(Guid userId)
        {
            InitializeComponent();
        }
        public void SetUserId(Guid userId)
        {
            _userId = userId;
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
