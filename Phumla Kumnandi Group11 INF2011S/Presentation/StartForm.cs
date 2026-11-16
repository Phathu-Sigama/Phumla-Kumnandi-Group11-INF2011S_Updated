using Phumla_Kumnandi_Group11_INF2011S.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phumla_Kumnandi_Group11_INF2011S
{
    public partial class StartForm: Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnReceptionist_Click(object sender, EventArgs e)
        {
            HomeForm homeForm = new HomeForm(); // Open HomeForm
            homeForm.Show();
            this.Hide(); 
        }

        private void btnManager_Click(object sender, EventArgs e)
        {
            ReportViewForm reportViewForm = new ReportViewForm(); // Open ReportViewForm
            reportViewForm.Show();
            this.Hide(); 
        }
    }
}
