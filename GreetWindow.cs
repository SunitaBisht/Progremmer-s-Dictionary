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
    public partial class GreetWindow : Form
    {
        public GreetWindow()
        {
            InitializeComponent();
            CheckTheme();    
        }

        private void GreetWindow_Load(object sender, EventArgs e)
        {
            //
        }


        // connection variables
        SqlConnection con=new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\ProgremmersDictionary\ProgremmersDictionary\MyDataBase.mdf;Integrated Security=True");
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
            else if(theme == "blue")
            {
                ThemeBlue();
            }
        }
        //
        /* end theme check */
        //


        //
        /* Apply Theme teal*/
        //
        void ThemeTeal()
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(178)))), ((int)(((byte)(181))))); // set backcolor of the form
            this.BackgroundImage = Properties.Resources.greetTeal; // set the teal color image
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(178)))), ((int)(((byte)(181))))); // set the transparancy
        }
        //
        /* end teal*/
        //


        //
        /* Apply Theme blue */
        //
        void ThemeBlue()
        {
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(189)))), ((int)(((byte)(226))))); //
            this.BackgroundImage = Properties.Resources.greetBlue; //
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(189)))), ((int)(((byte)(226))))); //
        }
        //
        /* end blue*/
        //



        //
        /* start the timer */
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Start(); // start the timer at form load
           
            this.Close(); // close the Greet Form
        }


        //
        /* when mouse is hover the Greeting Window */
        //
        private void GreetWindow_MouseHover(object sender, EventArgs e)
        {
            // show 'loading...' when the mouse is hover on the form
            greetWindowtoolTip.SetToolTip(GreetWindow.ActiveForm, "loading");
        }
        //
        /* end Greeting Window tool tip */
        //


        //
        /* when the mouse is hover the loading ring */
        //
        private void waitRing_MouseHover(object sender, EventArgs e)
        {
            // show 'loading...' when the mouse is hover on the loading ring
            greetWindowtoolTip.SetToolTip(waitRing, "laoding...");
        }
        //
        /* end loading ring tooltip */
        //

    }// end class 'GreetWindow'

}// end namespace 'ProgrammersDictionary'