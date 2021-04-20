using System;
using System.Drawing;
using System.IO; // File Heandling 
using System.Windows.Forms;

namespace Person
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Add icon From progrem to avoid size increse 
           
            // method 1 [ meet problem if change program name ]
            //this.Icon = Icon.ExtractAssociatedIcon("Person.exe");
            // Method 2 
            // note icon dosen't appear in Visual studio open from folder of bin/debug
            this.Icon = Icon.ExtractAssociatedIcon(AppDomain.CurrentDomain.FriendlyName + ".exe");
        }

        private void btnAdd_Click(object sender, EventArgs e)
   {
    try
            {
    // Validate 
     // trim to delete white speace from txtbox
     if (txtID.Text.Trim() == "" || txtName.Text.Trim() == "" || txtAddress.Text.Trim() == "")
         {
             MessageBox.Show("Please enter all data");
             return;
         }

         // Read From File 
         StreamReader fCheck = new StreamReader("Data.txt");
         string strCheck = fCheck.ReadToEnd();
         fCheck.Close();

         if (strCheck.Contains(txtID.Text + ";"))
         {
             MessageBox.Show("ID already Exits , try another one ");
             txtID.Focus();
             txtID.SelectAll();

         }
         else
         {
             // Write to file 
             StreamWriter sw = new StreamWriter("Data.txt", true);  // true will not override file,Append to file 

             string strPerson = txtID.Text + ";"
                                + txtName.Text + ";"
                                + txtAddress.Text;
             sw.WriteLine(strPerson);
             sw.Close();
             MessageBox.Show("Person is Added");

                    // clear forms after added
                    /* foreach (Control c in this.Controls)
                     {  
                         if (c is TextBox)
                             c.Text = " ";
                     }*/
                    txtID.Text = "";
             txtName.Text = "";
             txtAddress.Text = "";
             txtID.Focus();
         }
     }
     catch(Exception err)
     {MessageBox.Show(err.Message);}
           
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Trim() != "")
                {
                    StreamReader sr = new StreamReader("Data.txt");
                    string line = " ";
                    bool found = false;
                    do
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] array = line.Split(';');
                            if (txtID.Text == array[0])
                            {
                                txtName.Text = array[1];
                                txtAddress.Text = array[2];
                                found = true;
                                break;
                            }
                        }
                    } while (line != null);
                    sr.Close();
                    if (!found)
                    {
                        MessageBox.Show("ID not found");
                    }
                }
                else
                {
                    MessageBox.Show("Please enter Valid ID");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void showBtn_Click(object sender, EventArgs e)
        {
            Form fmShow = new Form();
            TextBox txtShow = new TextBox(); 
            fmShow.StartPosition = FormStartPosition.CenterScreen;
            fmShow.Font = this.Font;
            fmShow.Icon = this.Icon;
            fmShow.Text = "All Data";
            fmShow.Size = this.Size;
            txtShow.Multiline = true;
            txtShow.Dock = DockStyle.Fill;
            fmShow.Controls.Add(txtShow);

            try
            {
                StreamReader sw = new StreamReader("Data.txt");
                string data = sw.ReadToEnd();
                sw.Close();
                txtShow.Text = data;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            fmShow.ShowDialog();
        }
    }
}
