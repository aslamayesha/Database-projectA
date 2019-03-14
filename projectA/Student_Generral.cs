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

namespace databaseproject
{
    public partial class Student_Generral : Form
    {
        public string conString = "Data Source=FINE\\AYESHASLAM;Initial Catalog=ProjectA;Integrated Security=True";
        public Student_Generral()
        {
            InitializeComponent();
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Buttons";
            btn.Name = "update";
            btn.Text = "UPDATE";
            btn.UseColumnTextForButtonValue = true;
            StudentDatagrid.Columns.Add(btn);
            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Delete";
            btn1.Name = "Delete";
            btn1.Text = "Delete";
            btn1.UseColumnTextForButtonValue = true;
            StudentDatagrid.Columns.Add(btn1);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            int g = 2;
            if(txtgender.Text=="Male")
            {
                g = 1;
            }

            DateTime odate = Convert.ToDateTime(txtdatetime.Text);
            if (con.State == System.Data.ConnectionState.Open)
            {
                string q = "insert into [Person] values('" + txtfirstname.Text.ToString() + "','" + txtlastname.Text.ToString() + "','" + txtcontact.Text.ToString() + "','" + txtemail.Text.ToString() + "','" + Convert.ToDateTime(txtdatetime.Text) + "','" + g + "')";
                SqlCommand cmd = new SqlCommand(q, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("a new row1 inserted");

                SqlDataAdapter sda = new SqlDataAdapter("select * from Person",con);
                DataTable T= new DataTable();
                sda.Fill(T);
                
                String fname = txtfirstname.Text.ToString();

                int val=0;
                foreach (DataRow row in T.Rows)
                {
                    if (row["Firstname"].ToString() == txtfirstname.Text && row["Email"].ToString()==txtemail.Text)
                    {
                         val = Convert.ToInt32(row["Id"]);
                    } 
                }
                string q1 = "insert into [Student] values('"+val+"','" + txtregistrationno.Text.ToString() + "')";
                SqlCommand cmd1 = new SqlCommand(q1, con);
                cmd1.ExecuteNonQuery();
                MessageBox.Show("a new row2 inserted");
                SqlDataAdapter sda1 = new SqlDataAdapter("Select Person.FirstName,Person.LastName,Person.Contact,Person.Email,Person.DateOfBirth,Person.Gender,Student.RegistrationNo from Person join Student on Person.id = Student.id", con);
                DataTable TT = new DataTable();
                sda1.Fill(TT);
                StudentDatagrid.DataSource = TT;
                




            }
            else
            {
                MessageBox.Show("connecton is not open");
            }

        }

        private void Student_Generral_Load(object sender, EventArgs e)
        {
            grid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            general_selection g = new general_selection();
            this.Hide();
            g.Show();
        }
        int id;
        string fname;
        string Lname;
        string contact;
        string email;
        string dateofbirth;
        int gender=0;
        string R_g;
        private void StudentDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("hshshs");
            if (e.ColumnIndex==0)
            {
                MessageBox.Show("hshshs");
                if(StudentDatagrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value!=null)
                {
                    StudentDatagrid.CurrentRow.Selected = true;
                    fname= StudentDatagrid.Rows[e.RowIndex].Cells["Firstname"].FormattedValue.ToString();
                    txtfirstname.Text = StudentDatagrid.Rows[e.RowIndex].Cells["Firstname"].FormattedValue.ToString();
                    Lname= StudentDatagrid.Rows[e.RowIndex].Cells["LastName"].FormattedValue.ToString();
                    txtlastname.Text = StudentDatagrid.Rows[e.RowIndex].Cells["LastName"].FormattedValue.ToString();
                    contact= StudentDatagrid.Rows[e.RowIndex].Cells["Contact"].FormattedValue.ToString();
                     email= StudentDatagrid.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                    txtcontact.Text = StudentDatagrid.Rows[e.RowIndex].Cells["Contact"].FormattedValue.ToString();
                    txtemail.Text = StudentDatagrid.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();
                    dateofbirth= StudentDatagrid.Rows[e.RowIndex].Cells["DateOfBirth"].FormattedValue.ToString();
                    txtdatetime.Text= StudentDatagrid.Rows[e.RowIndex].Cells["DateOfBirth"].FormattedValue.ToString();
                    R_g= StudentDatagrid.Rows[e.RowIndex].Cells["RegistrationNo"].FormattedValue.ToString();
                    txtregistrationno.Text= StudentDatagrid.Rows[e.RowIndex].Cells["RegistrationNo"].FormattedValue.ToString();
                    if (StudentDatagrid.Rows[e.RowIndex].Cells["Gender"].FormattedValue.ToString()=="1")
                    {
                        gender = 1;
                        txtgender.Text = "Male";
                    }
                    else
                    {
                        gender = 2;
       
                        txtgender.Text = "Female";
                    }


                }
            }
            else if(e.ColumnIndex == 1)
            {
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                //string q1 = "select Person.Id from Person where Person.FirstName='" + StudentDatagrid.Rows[e.RowIndex].Cells["Firstname"].FormattedValue.ToString() + "'AND Person.LastName='" + StudentDatagrid.Rows[e.RowIndex].Cells["LastName"].FormattedValue.ToString() + "' AND Person.Contact='" + StudentDatagrid.Rows[e.RowIndex].Cells["Contact"].FormattedValue.ToString() + "' AND Person.Email='" + StudentDatagrid.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString() + "'AND Person.DateOfBirth='" + Convert.ToDateTime(StudentDatagrid.Rows[e.RowIndex].Cells["DateOfBirth"].FormattedValue.ToString())+ "' ";
                SqlDataAdapter sda = new SqlDataAdapter("select * from Person", con);
                DataTable T = new DataTable();
                sda.Fill(T);

                String fname = txtfirstname.Text.ToString();

                int val = 0;
                foreach (DataRow row in T.Rows)
                {
                    if (row["Firstname"].ToString() == StudentDatagrid.Rows[e.RowIndex].Cells["Firstname"].FormattedValue.ToString() && row["Email"].ToString() == StudentDatagrid.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString())
                    {
                        id = Convert.ToInt32(row["Id"]);
                    }
                }
               
                string q2 = "Delete from Student where Student.Id='"+id+"'";
                SqlCommand cmd2 = new SqlCommand(q2, con);
                cmd2.ExecuteNonQuery();
                string q3 = "Delete from Person where Person.Id='" + id + "'";
                SqlCommand cmd3 = new SqlCommand(q3, con);
                cmd3.ExecuteNonQuery();
                MessageBox.Show("data has been deleted");
                grid();
            }
        }
        private void grid()
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                SqlDataAdapter sda1 = new SqlDataAdapter("Select Person.FirstName,Person.LastName,Person.Contact,Person.Email,Person.DateOfBirth,Person.Gender,Student.RegistrationNo from Person join Student on Person.id = Student.id", con);
                DataTable TT = new DataTable();
                sda1.Fill(TT);
                StudentDatagrid.DataSource = TT;
            }
            else
            {
                MessageBox.Show("connecton is not open");

            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            int gen = 2;
            if (con.State == System.Data.ConnectionState.Open)
            {
                if (txtgender.Text == "Male")
                {
                    gen = 1;
                }

                MessageBox.Show(email);
                string q1 = "update Person SET Person.FirstName='" + txtfirstname.Text.ToString() + "',Person.LastName='" + txtlastname.Text.ToString() + "',Person.Contact='" + txtcontact.Text.ToString() + "',Person.Email='" + txtemail.Text.ToString() + "',Person.DateOfBirth='" + Convert.ToDateTime(txtdatetime.Text) + "',Person.Gender='" + gen + "' where Person.Email='" + email + "' AND person.FirstName='" + fname + "' AND person.LastName='" + Lname + "' ";
                SqlCommand cmd1 = new SqlCommand(q1, con);
                cmd1.ExecuteNonQuery();
                grid();
                
            }
            else
            {
                MessageBox.Show("connecton is not open");
            }

        }
    }
}
