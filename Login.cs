using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekat_2026_Andjela_Simic
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Andjela Simic
            //drugi red
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text=="")
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
            else
            {
                SqlConnection veza = konekcija.povezi();
                SqlCommand naredba = new SqlCommand("SELECT * FROM Korisnik WHERE email = '" + textBox1.Text + "'", veza);
                SqlDataAdapter adapt = new SqlDataAdapter(naredba);
                DataTable podaci = new DataTable();
                adapt.Fill(podaci);
                int count = podaci.Rows.Count;
                if (count == 0)
                {
                    MessageBox.Show("Neispravan e-mail");
                }
                else
                {
                    if (podaci.Rows[0]["pass"].ToString() != textBox2.Text)
                    {
                        MessageBox.Show("Neispravna lozinka ");
                    }
                    else
                    {
                        this.Hide();
                        Glavna nova = new Glavna();
                        nova.Show();

                    }
                }
        }
    }
}
