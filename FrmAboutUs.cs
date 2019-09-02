using MetroFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ProgremmersDictionary
{
    public partial class FrmAboutUs : MetroFramework.Forms.MetroForm
    {
        public FrmAboutUs()
        {
            InitializeComponent();
            CheckTheme();
        }


        // connection variables
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\ProgremmersDictionary\ProgremmersDictionary\MyDataBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dRead;

        //
        /* check the value of theme*/
        //
        public void CheckTheme()
        {
            string theme = "";
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT * FROM Theme", con);
                dRead = cmd.ExecuteReader();
                if (dRead.Read())
                {
                    theme = dRead["color"].ToString();
                    //con.Close();
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Error loading theme...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }

            if (theme == "teal")
            {
                ThemeTeal();
            }
            else if (theme == "blue")
            {
                ThemeBlue();
            }
        }
        //
        /* end theme check */
        //


        void ThemeTeal()
        {
            this.Style = MetroFramework.MetroColorStyle.Teal;
            metroProgressBar1.Style = MetroColorStyle.Teal;
            pictureBox1.Image = Properties.Resources.VersionTeal;
        }

        void ThemeBlue()
        {
            this.Style = MetroFramework.MetroColorStyle.Blue;
            metroProgressBar1.Style = MetroColorStyle.Blue;
            pictureBox1.Image = Properties.Resources.VersionBlue;
            

        }


        private void FrmAboutUs_Load(object sender, EventArgs e)
        {
            metroProgressBar1.Value = 0;
            

          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start();
            metroProgressBar1.Increment(1);
        }

        private void mtBtnOk_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Close();
        }
    }
}
