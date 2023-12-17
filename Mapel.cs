using MySql.Data.MySqlClient;
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
    public partial class Mapel : Form
    {
        public MySqlCommand cmd;
        public MySqlDataReader dr;
        public String id;
        public Mapel()
        {
            InitializeComponent();
        }

        private void Mapel_Load(object sender, EventArgs e)
        {
            Tampil();
            MySqlDataAdapter adp = new MySqlDataAdapter("select * from guru", Koneksi.conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            cbnamaguru.DataSource = dt;
            cbnamaguru.DisplayMember = "nama";
            cbnamaguru.ValueMember = "id";
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                String Queri = "INSERT INTO mapel (`nama_mapel`, `kode_mapel`, `guru_id`) VALUES ('" + txtnama.Text + "', '" + txtkodemapel.Text + "', '" + cbnamaguru.SelectedValue + "')";
                cmd = new MySqlCommand(Queri, Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Simpan Data Mapel");
                Koneksi.conn.Close();

                Tampil();
                Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Tambah Data Gagal");
            }
        }
    
        private void Tampil()
        {
            try
            {


                Koneksi.conn.Open();

                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `vmapel`", Koneksi.conn);

                DataSet ds = new DataSet();

                da.Fill(ds);

                dgsiswa.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }
        private void Clear()
        {

            txtnama.Text = "";
            txtkodemapel.Text = "";
            txtcari.Text = "";
            cbnamaguru.Text = "";

            btDelete.Enabled = false;
            btUpdate.Enabled = false;
            btCancel.Enabled = false;
            btInsert.Enabled = true;

        }

        private void dgsiswa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btDelete.Enabled = true;
            btUpdate.Enabled = true;
            btCancel.Enabled = true;
            btInsert.Enabled = false;

            int baris = dgsiswa.CurrentCell.RowIndex;
            id = dgsiswa.Rows[baris].Cells[0].Value.ToString();
            txtnama.Text = dgsiswa.Rows[baris].Cells[1].Value.ToString();
            txtkodemapel.Text = dgsiswa.Rows[baris].Cells[2].Value.ToString();
            cbnamaguru.Text = dgsiswa.Rows[baris].Cells[3].Value.ToString();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                String Queri = "UPDATE mapel SET `nama_mapel`='" + txtnama.Text + "', `kode_mapel`='" + txtkodemapel.Text + "', `guru_id`='" + cbnamaguru.SelectedValue + "' WHERE  `id`='" + id + "'";
                cmd = new MySqlCommand(Queri, Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Update Data Guru");
                Koneksi.conn.Close();

                Tampil();
                Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Update Gagal");
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();


                cmd = new MySqlCommand("DELETE FROM mapel WHERE  `id`= '" + id + "'", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Hapus Data mapel");
                Koneksi.conn.Close();

                Tampil();
                Clear();
            }
            catch (Exception)
            {

                MessageBox.Show("Hapus Data Gagal");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtcari_TextChanged(object sender, EventArgs e)
        {
            try
            {

                Koneksi.conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `vmapel` where nama_mapel LIKE '%" + txtcari.Text + "%'", Koneksi.conn);
                DataSet ds = new DataSet();

                da.Fill(ds);
                dgsiswa.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
