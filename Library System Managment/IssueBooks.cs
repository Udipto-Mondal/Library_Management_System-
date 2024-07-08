﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();


            cmd =new SqlCommand("select bname from NewBookP",con);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                for(int i = 0; i<sdr.FieldCount;i++)
                {
                    comboBox1.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }
        int count;

        private void Searchbtn_Click(object sender, EventArgs e)
        {
            if(textSearchST.Text != "")
            {
                int stid = int.Parse(textSearchST.Text);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from StudentInfo where stuid = " + stid + " ";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                //count----------------------------
                cmd.CommandText = "select count(studentID) from IRBook where studentID = " + stid + " and book_return_date is null ";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA1.Fill(DS1);
                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());
                //count----------------------------
                if (DS.Tables[0].Rows.Count != 0)
                {
                    textSTNAME.Text = DS.Tables[0].Rows[0][0].ToString();
                    textSTDEPT.Text = DS.Tables[0].Rows[0][2].ToString();
                    textSTSEM.Text = DS.Tables[0].Rows[0][3].ToString();
                    textSTCONTACT.Text = DS.Tables[0].Rows[0][4].ToString();
                    textSTEMAIL.Text = DS.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    textSTEMAIL.Clear();
                    textSTCONTACT.Clear();
                    textSTNAME.Clear();
                    textSTSEM.Clear();
                    textSTDEPT.Clear();
                    MessageBox.Show("Invalid Student ID", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void issuebookbtn_Click(object sender, EventArgs e)
        {
            if ( textSTNAME.Text !="")
            {
                if(comboBox1.SelectedIndex != -1 && count <= 2)
                {
                    int STID = int.Parse(textSearchST.Text);
                    string name = textSTNAME.Text;
                    string dept = textSTDEPT.Text;
                    string sem = textSTSEM.Text;
                    Int64 contact = Int64.Parse(textSTCONTACT.Text);
                    string email = textSTEMAIL.Text;
                    string bookname = comboBox1.Text;
                    string bookidate = dateTimePicker1.Text;


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source= DESKTOP-5903S8A\\SQLEXPRESS; database= master; integrated security=True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = " insert into IRBook (studentID,st_name,st_dep,st_sem,st_contact,st_email,book_name,book_issue_date) values(" + STID + ",'" + name + "','" + dept + "','" + sem + "'," + contact + ",'" + email + "','"+bookname+"','"+bookidate+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Book Issued", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("Select Book or you have 3(MAX) Book Issued Already", "No Book Issued", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Student ID, And Try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textSearchST_TextChanged(object sender, EventArgs e)
        {
            if( textSearchST.Text== "")
            {
                textSTNAME.Clear();
                textSTDEPT.Clear();
                textSTSEM.Clear();
                textSTCONTACT.Clear();
                textSTEMAIL.Clear();
            }
        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {
            textSearchST.Clear();
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you Sure,Exit?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
    }

