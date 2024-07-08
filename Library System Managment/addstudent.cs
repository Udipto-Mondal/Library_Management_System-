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

namespace Addstudent
{
    public partial class addstudent : Form
    {
        public addstudent()
        {
            InitializeComponent();
        }
        
        private void exibtn_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm?","Confirmation",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)== DialogResult.OK)
            {
                this.Close();
            }
        }

        private void refbtn_Click(object sender, EventArgs e)
        {
            textsname.Clear();
            textdepartment.Clear();
            textscontact.Clear();
            textsID.Clear();
            textsemail.Clear();
            textstudentsem.Clear();
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            if (textsname.Text != "" && textsID.Text != "" && textdepartment.Text != "" && textstudentsem.Text != "" && textscontact.Text != "" && textsemail.Text != "")
            {
                string name = textsname.Text;
                int sid = int.Parse(textsID.Text);
                string dept = textdepartment.Text;
                string sem = textstudentsem.Text;
                Int64 contact = Int64.Parse(textscontact.Text);
                string email = textsemail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = " insert into StudentInfo (stname,stuid,stdep,stsem,stcontact,stemail) values('" + name + "'," + sid + ",'" + dept + "','" + sem + "'," + contact + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Student Enroll successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Please Fill All the Field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addstudent_Load(object sender, EventArgs e)
        {

        }
    }
}
