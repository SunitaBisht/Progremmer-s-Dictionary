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
using MetroFramework;


namespace ProgremmersDictionary
{
    public partial class FrmAddItems : MetroFramework.Forms.MetroForm
    {
        public FrmAddItems()
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
            mtTxtWord.Style = MetroFramework.MetroColorStyle.Teal;
            mtTxtDescription.Style = MetroFramework.MetroColorStyle.Teal;
            mtTxtSyntex.Style = MetroFramework.MetroColorStyle.Teal;
            mtTxtExample.Style = MetroFramework.MetroColorStyle.Teal;
            mtCmbLanguage.Style = MetroFramework.MetroColorStyle.Teal;
        }

        void ThemeBlue()
        {
            this.Style = MetroFramework.MetroColorStyle.Blue;
            mtTxtWord.Style = MetroFramework.MetroColorStyle.Blue;
            mtTxtDescription.Style = MetroFramework.MetroColorStyle.Blue;
            mtTxtSyntex.Style = MetroFramework.MetroColorStyle.Blue;
            mtTxtExample.Style = MetroFramework.MetroColorStyle.Blue;
            mtCmbLanguage.Style = MetroFramework.MetroColorStyle.Blue;
            
        }

        private void mtBtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void mtBtnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(mtCmbLanguage.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Please select your language.", "Dictionary Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (String.IsNullOrEmpty(mtTxtWord.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "The Word field can't be empty.", "Dictionary Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(String.IsNullOrEmpty(mtTxtSyntex.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "The Syntex field can't be empty.", "Dictionary Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (String.IsNullOrEmpty(mtTxtDescription.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "The Description field can't be empty.", "Dictionary Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (String.IsNullOrEmpty(mtTxtExample.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "The Example field can't be empty.", "Dictionary Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    con.Open(); // open connection

                    switch (mtCmbLanguage.Text)
                    {
                        case "C":
                            cmd = new SqlCommand("INSERT INTO c VALUES('" + mtTxtWord.Text + "','" + mtTxtDescription.Text + "','" + mtTxtSyntex.Text + "','" + mtTxtExample.Text + "')", con);
                            break;
                        case "C++":
                            cmd = new SqlCommand("INSERT INTO cpp VALUES('" + mtTxtWord.Text + "','" + mtTxtDescription.Text + "','" + mtTxtSyntex.Text + "','" + mtTxtExample.Text + "')", con);
                            break;
                        case "C#":
                            cmd = new SqlCommand("INSERT INTO csharp VALUES('" + mtTxtWord.Text + "','" + mtTxtDescription.Text + "','" + mtTxtSyntex.Text + "','" + mtTxtExample.Text + "')", con);
                            break;
                        case "Java":
                            cmd = new SqlCommand("INSERT INTO java VALUES('" + mtTxtWord.Text + "','" + mtTxtDescription.Text + "','" + mtTxtSyntex.Text + "','" + mtTxtExample.Text + "')", con);
                            break;
                    }//end switch

                    cmd.ExecuteNonQuery();
                    MetroMessageBox.Show(this, "Dictionary Updated...", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                
                MetroFramework.MetroMessageBox.Show(this, ex.Message, "Dictionary Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}
