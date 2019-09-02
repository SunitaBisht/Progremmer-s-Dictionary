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
    public partial class FrmMainWindow : MetroFramework.Forms.MetroForm
    {   
        //
        /*connection variables*/
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\ProgremmersDictionary\ProgremmersDictionary\MyDataBase.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dRead;
        /* end declaration of connection variables*/
        //

        //
        /* declaration of string variables to store data from database*/
        string description, syntex, example;
        /* end declaration of data string */
        //

        //
        /*constructor*/
        //
        public FrmMainWindow()
        {
            InitializeComponent();
            CheckTheme();
        }
        //
        /*end constructor*/
        //


        //
        /* set propeties on form load */
        //
        private void FrmMainWindow_Load(object sender, EventArgs e)
        {
           // 
        }
        //
        /* end form load */
        //


        
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
            else
            {
                ThemeBlue();
            }
        }
        //
        /* end theme check */
        //

        //
        /* Button click event */
        //
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();


            // focus at search button
            btnSearch.BackColor = Color.White;
            btnDescription.BackColor = Color.Transparent;
            btnSyntex.BackColor = Color.Transparent;
            btnExample.BackColor = Color.Transparent;

            // clear the contents of text boxes
            mtTxtSearch.Clear();
            mtTxtResult.Clear();

            // clear the content of variables
            description = "";
            syntex = "";
            example = "";
        }
        //
        /*end button click*/
        //


        //
        /*button definition click event*/
        //
        private void btnDescription_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();
            
            btnSearch.BackColor = Color.Transparent;
            btnDescription.BackColor = Color.White;
            btnSyntex.BackColor = Color.Transparent;
            btnExample.BackColor = Color.Transparent;

            mtTxtResult.Clear(); //clear previous search
            mtTxtResult.Text = description; //show the value of Description in result box
            
        }
        //
        /*end button definition click event*/
        //


        //
        /*Button Syntex click event*/
        //
        private void btnSyntex_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();


            btnSearch.BackColor = Color.Transparent;
            btnDescription.BackColor = Color.Transparent;
            btnSyntex.BackColor = Color.White;
            btnExample.BackColor = Color.Transparent;

            mtTxtResult.Clear(); //clear previous search
            mtTxtResult.Text = syntex; //show the value of Description in result box
        }
        //
        /*end Button Syntex click event*/
        //


        //
        /*Button Example click event*/
        //
        private void btnExample_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();


            btnSearch.BackColor = Color.Transparent;
            btnDescription.BackColor = Color.Transparent;
            btnSyntex.BackColor = Color.Transparent;
            btnExample.BackColor = Color.White;

            mtTxtResult.Clear(); // clear the previous search
            mtTxtResult.Text = example; //show the value of Description in result box
        }
        //
        /* end button Example click event*/
        //


        //
        /* Button theme click event*/
        //
        private void btnTheme_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();


            if (this.Style == MetroFramework.MetroColorStyle.Blue)
            {
                ThemeTeal();
            }
            else
            {
                ThemeBlue();
            }
            
            Refresh();
        }
        //
        /* end Button theme click event*/
        //


        //
        /* Set theme to blue */
        //
        void ThemeBlue()
        {
            this.Style = MetroFramework.MetroColorStyle.Blue;
            mtPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnDescription.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnSyntex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnExample.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            pBoxVersion.Image = Properties.Resources.VersionBlue;
            pBoxArrow.Image = Properties.Resources.ArrowBlue;
            mtTxtSearch.Style = MetroFramework.MetroColorStyle.Blue;
            btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnAboutUs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnAboutUs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            btnContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            mtCmbLang.Style = MetroFramework.MetroColorStyle.Blue;
            this.Icon = Properties.Resources.IconBlue;
            btnTheme.BackgroundImage = Properties.Resources.ThemeTeal;
            btnTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));

            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE Theme SET color='blue' WHERE id=1", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        
        }
        //
        /* end theme blue */
        //


        //
        /* set theme to teal */
        //
        void ThemeTeal()
        {
            this.Style = MetroFramework.MetroColorStyle.Teal;
            mtPanelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnDescription.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnSyntex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnExample.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            pBoxVersion.Image = Properties.Resources.VersionTeal;
            pBoxArrow.Image = Properties.Resources.ArrowTeal;
            mtTxtSearch.Style = MetroFramework.MetroColorStyle.Teal;
            btnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnAboutUs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnAboutUs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnContact.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            btnContact.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));
            mtCmbLang.Style = MetroFramework.MetroColorStyle.Teal;
            this.Icon = Properties.Resources.IconTeal;
            btnTheme.BackgroundImage = Properties.Resources.ThemeBlue;
            btnTheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(170)))), ((int)(((byte)(173)))));

            try
            {
                con.Open();
                cmd = new SqlCommand("UPDATE Theme SET color='teal' WHERE id=1", con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
        //
        /* end theme blue */
        //


        //
        /* set tool tip */
        //
        private void btnMainMenu_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnMainMenu, "Main Menu");
        }

        private void mtCmbLang_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(mtCmbLang, "Choose Language");
        }

        private void btnAdd_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAdd, "Add Item");
        }
        //
        /* close tool tip */
        //


        //
        /*button main menu click event*/
        //
        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            
            // if main menu is not visible
            // if arrow of main menu is not visible
            if ((mtPanelMainMenu.Visible == false)&&(pBoxArrow.Visible==false))
            {
                mtPanelMainMenu.Visible = true; // show the main menu
                pBoxArrow.Visible = true; // show the main menu arrow
            }
            else
            {
                mtPanelMainMenu.Visible = false; // hide the main menu
                pBoxArrow.Visible = false; // hide the main menu arrow
            }
        }
        //
        /* end main menu */
        //


        //
        /* hide the main menu if anothe control is clicked */
        //
        void HideMainMenu()
        {
            // if main menu is visible
            if ((mtPanelMainMenu.Visible == true) && (pBoxArrow.Visible == true))
            {
                mtPanelMainMenu.Visible = false; // hide the main menu
                pBoxArrow.Visible = false; // hide the main menu arrow
            }//end if
        }
        //
        /*end Hide main menu*/
        //


        //
        /* Auto complete the Search Box text While writing for c */
        //
        void AutoCompleteSearchBox4C()
        {
            
            // variable to store whole words from database
            AutoCompleteStringCollection cCollection = new AutoCompleteStringCollection();


            con.Open();

            cmd = new SqlCommand("SELECT * FROM c", con);
            dRead = cmd.ExecuteReader();

            while (dRead.Read())
            {
                string str = dRead["Word"].ToString();
                cCollection.Add(str);
            }
            con.Close();
            mtTxtSearch.AutoCompleteCustomSource = cCollection;
        }
        //
        /* end auto complete search box for C */
        //


        //
        /* Auto complete the Search Box text While writing for Cpp */
        //
        void AutoCompleteSearchBox4Cpp()
        {
            
            // variable to store whole words from database
            AutoCompleteStringCollection cppCollection = new AutoCompleteStringCollection();


            con.Open();

            cmd = new SqlCommand("SELECT * FROM cpp", con);
            dRead = cmd.ExecuteReader();

            while (dRead.Read())
            {
                string str = dRead["Word"].ToString();
                cppCollection.Add(str);
            }
            con.Close();
            mtTxtSearch.AutoCompleteCustomSource = cppCollection;
        }
        //
        /* end auto complete search box for Cpp*/
        //



        //
        /* Auto complete the Search Box text While writing for C# */
        //
        void AutoCompleteSearchBox4Csharp()
        {
            
            // variable to store whole words from database
            AutoCompleteStringCollection cSharpCollection = new AutoCompleteStringCollection();


            con.Open();

            cmd = new SqlCommand("SELECT * FROM csharp", con);
            dRead = cmd.ExecuteReader();

            while (dRead.Read())
            {
                string str = dRead["Word"].ToString();
                cSharpCollection.Add(str);
            }
            con.Close();
            mtTxtSearch.AutoCompleteCustomSource = cSharpCollection;
        }
        //
        /* end auto complete search box for C#*/
        //



        //
        /* Auto complete the Search Box text While writing for java*/
        //
        void AutoCompleteSearchBox4Java()
        {
            

            // variable to store whole words from database
            AutoCompleteStringCollection javaCollection = new AutoCompleteStringCollection();


            con.Open();

            cmd = new SqlCommand("SELECT * FROM java", con);
            dRead = cmd.ExecuteReader();

            while (dRead.Read())
            {
                string str = dRead["Word"].ToString();
                javaCollection.Add(str);
            }
            con.Close();
            mtTxtSearch.AutoCompleteCustomSource = javaCollection;
        }
        //
        /* end auto complete search box for java*/
        //


        //
        /* complete the search box */
        //
        private void mtTxtSearch_TextChanged(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();

            mtTxtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            mtTxtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            switch (mtCmbLang.Text)
            {
                case "C":
                    AutoCompleteSearchBox4C();
                    break;
                case "C++":
                    AutoCompleteSearchBox4Cpp();
                    break;
                case "C#":
                    AutoCompleteSearchBox4Csharp();
                    break;
                case "Java":
                    AutoCompleteSearchBox4Java();
                    break;
            }//end switch


            mtTxtSearch_ButtonClick(sender, e);
            
           
        }
        //
        /* end search box */
        //

        
        //
        /* text box button click */
        //
        private void mtTxtSearch_ButtonClick(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();

            try
            {
                con.Open(); // open connection

                // check the language
                switch (mtCmbLang.Text)
                {
                    case "C":
                        cmd = new SqlCommand("SELECT * FROM c WHERE Word = '" + mtTxtSearch.Text + "'", con);
                        break;
                    case "C++":
                        cmd = new SqlCommand("SELECT * FROM cpp WHERE Word = '" + mtTxtSearch.Text + "'", con);
                        break;
                    case "C#":
                        cmd = new SqlCommand("SELECT * FROM csharp WHERE Word = '" + mtTxtSearch.Text + "'", con);
                        break;
                    case "Java":
                        cmd = new SqlCommand("SELECT * FROM java WHERE Word = '" + mtTxtSearch.Text + "'", con);
                        break;
                }//end switch



                dRead = cmd.ExecuteReader(); //executes query

                if (dRead.Read())
                {
                    description = dRead["Description"].ToString();
                    syntex = dRead["Syntax"].ToString();
                    example = dRead["Example"].ToString();

                    btnDescription_Click(sender, e);
                }

            }
            catch (Exception ex)
            {
                
                MetroFramework.MetroMessageBox.Show(this, "Please select a language first", "Dictionary Says", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                con.Close();
            }
        }
        //
        /* end text box button click */
        //


        //
        /* if search text box click*/
        //
        private void mtTxtSearch_Click(object sender, EventArgs e)
        {
            //btnSearch_Click(sender, e);
            HideMainMenu();

            if (String.IsNullOrEmpty(mtTxtSearch.Text))
            {
                btnSearch_Click(sender, e);
            }//end if

        }
        //
        /* end search text box click */
        //


        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();

            FrmAboutUs AboutUs = new FrmAboutUs();
            AboutUs.Show();
        }


        private void btnContact_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();

            System.Diagnostics.Process.Start("http:\\www.yogshsaini579.wixsite.com/kyt4u"); // jump to to my blog page lounching default web browser
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // if main menu is visible
            HideMainMenu();

            FrmAddItems addItem = new FrmAddItems();
            addItem.Show();
        }


        //
        /* if a new language is selected*/
        //
        private void mtCmbLang_TextChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }
        //
        /* end language selection */
        //


        //
        /* if user wants to close the application */
        //
        private void FrmMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            switch(MetroMessageBox.Show(this,"Are you sure to Exit", "Dictionary Says...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
            }
            
          
        }

        
       

    }//end main class
}//end namespace 
