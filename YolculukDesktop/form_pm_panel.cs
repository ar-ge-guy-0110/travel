using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YolculukDesktop
{
    public partial class form_pm_panel : Form
    {
        public form_pm_panel()
        {
            InitializeComponent();
        }

        private void form_pm_panel_Load(object sender, EventArgs e)
        {
            Form imager = new form_debug();
            imager.Show();
        }

        private void form_pm_panel_FormClosed(object sender, FormClosedEventArgs e)
        {
            class_ProgramMaster.mainloginform.Show();
        }

        private void firmatanimbutton_Click(object sender, EventArgs e)
        {
            Form compdef = new form_pm_companies();
            compdef.ShowDialog();
        }

        private void otobustanimbutton_Click(object sender, EventArgs e)
        {
            Form busdef = new form_pm_buses();
            busdef.ShowDialog();
        }

        private void guztanimbutton_Click(object sender, EventArgs e)
        {
            Form routedef = new form_pm_routes();
            routedef.ShowDialog();
        }

        private void sefertanimbutton_Click(object sender, EventArgs e)
        {
            Form voyagedef = new form_pm_voyages();
            voyagedef.ShowDialog();
        }
    }
}
