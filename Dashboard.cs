using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Data_Siswa
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            panel3.Visible = false;
            Siswa FormAktif = new Siswa();

            FormAktif.MdiParent = this;
            FormAktif.Show();
            FormAktif.Dock = DockStyle.Fill;    
            label1.Text = "Kelola Data Siswa";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            panel3.Visible = false;
            Guru FormAktif = new Guru();

            FormAktif.MdiParent = this;
            FormAktif.Show();
            FormAktif.Dock = DockStyle.Fill;

            label1.Text = "Kelola Data Guru";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            panel3.Visible = false;
            Mapel FormAktif = new Mapel();

            FormAktif.MdiParent = this;
            FormAktif.Show();
            FormAktif.Dock = DockStyle.Fill;

            label1.Text = "Kelola Data Mata Pelajaran";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            panel3.Visible = true;
            label1.Text = "Aplikasi Pendataan Nilai";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();

            panel3.Visible = false;
            Nilai FormAktif = new Nilai();

            FormAktif.MdiParent = this;
            FormAktif.Show();
            FormAktif.Dock = DockStyle.Fill;

            label1.Text = "Kelola Data Nilai";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new login().Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
