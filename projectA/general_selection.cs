using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databaseproject
{
    public partial class general_selection : Form
    {
        public general_selection()
        {
            InitializeComponent();
        }

        private void addInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Generral form = new Student_Generral();
            form.Show();
            this.Hide();
        }

        private void makeGoupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            makeGroup G = new makeGroup();
            G.Show();
            this.Hide();
        }

        private void addAdvisorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General_Advisor g = new General_Advisor();
            g.Show();
            this.Hide();
        }

        private void addProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project p = new project();
            this.Hide();
            p.Show();
        }

        private void addEvaluationCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Evaluation E = new Evaluation();
            this.Hide();
            E.Show();
        }
    }
}
