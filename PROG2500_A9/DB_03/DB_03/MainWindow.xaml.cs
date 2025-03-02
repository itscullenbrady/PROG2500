using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;

namespace DB_03
{
    public partial class MainWindow : Window
    {
        string connstr = DB_03.Utility.GetConnectionString();
        DataTable dt;
        int current_primary_key = 0;

        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {                                                     // added facemaker options to the data grid 
            string CmdString = "SELECT Id, fname, lname, address, Hair, Eyes, Mouth, Nose FROM Person";
            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable("gridPerson");
                sda.Fill(dt);
                gridPerson.ItemsSource = dt.DefaultView;
            }
        }

        private void b_Add_Click(object sender, RoutedEventArgs e)
        {
            String fn = tb_first.Text;
            String ln = tb_last.Text;
            String address = tb_address.Text;

            if (fn != "" && ln != "" && address != "")
            {
                addPerson(fn, ln, address);
            }
            else
            {
                MessageBox.Show("A field is empty...enter all fields");
            }

            FillDataGrid();
        }

        private void addPerson(String fn, String ln, String address)
        {
            String cmd_Text = "INSERT INTO Person(fname, lname, address) VALUES('" + fn + "', '" + ln + "', '" + address + "');";
            Trace.Write(cmd_Text);

            using (SqlConnection con = new SqlConnection(connstr))
            {
                SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: con);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private void delPerson(int pkey)
        {
            String cmd_Text = "DELETE FROM Person WHERE Id = " + pkey + ";";
            Trace.Write(cmd_Text);

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("DB Delete Exception");
                }
            }
        }

        private void upPerson(int pkey, String fn, String ln, String address)
        {
            String cmd_Text = "UPDATE Person SET fname = '" + fn + "', lname = '" + ln + "', address = '" + address + "' WHERE Id = " + pkey + ";";
            Trace.Write(cmd_Text);

            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    SqlCommand command = new SqlCommand(cmdText: cmd_Text, connection: conn);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("DB Update Exception");
                }
            }
        }

        private void gridPerson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if ((gridPerson.SelectedItem as DataRowView) != null)
                {
                    current_primary_key = (int)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[0];
                    tb_first.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[1];
                    tb_last.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[2];
                    tb_address.Text = (string)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[3];

                    Trace.WriteLine("Selected = " + current_primary_key + tb_first.Text + tb_last.Text);
                }
                else
                {
                    current_primary_key = -1;
                    tb_first.Text = ":(";
                    tb_last.Text = ":(";
                    tb_address.Text = ":(";
                }
            }
            catch
            {
                Trace.WriteLine("No Row (deleted?)...default record used");
                current_primary_key = -1;
                tb_first.Text = ":(";
                tb_last.Text = ":(";
                tb_address.Text = ":(";
            }
        }

        private void b_delete_Click(object sender, RoutedEventArgs e)
        {
            if (gridPerson.SelectedItem != null)
            {
                int key = (int)(gridPerson.SelectedItem as DataRowView).Row.ItemArray[0];
                delPerson(key);
                dt.Rows.Remove((gridPerson.SelectedItem as DataRowView).Row);
                dt.AcceptChanges();
            }
        }

        private void b_update_Click(object sender, RoutedEventArgs e)
        {
            if (current_primary_key > -1)
            {
                upPerson(current_primary_key, tb_first.Text, tb_last.Text, tb_address.Text);
                FillDataGrid();
            }
        }

        private void b_cancel_Click(object sender, RoutedEventArgs e)
        {
            tb_first.Text = "";
            tb_last.Text = "";
            tb_address.Text = "";
        }

        private void b_prev_Click(object sender, RoutedEventArgs e)
        {
            if (gridPerson.SelectedIndex > 0)
            {
                gridPerson.SelectedIndex--;
            }
        }

        private void b_next_Click(object sender, RoutedEventArgs e)
        {
            if (gridPerson.SelectedIndex < gridPerson.Items.Count - 1)
            {
                gridPerson.SelectedIndex++;
            }
        }

        private void b_search_Click(object sender, RoutedEventArgs e)
        {
            string searchLastName = tb_search.Text;
            DataRow[] foundRows = dt.Select($"lname = '{searchLastName}'");

            if (foundRows.Length > 0)
            {
                DataRow row = foundRows[0];
                current_primary_key = (int)row["Id"];
                tb_first.Text = (string)row["fname"];
                tb_last.Text = (string)row["lname"];
                tb_address.Text = (string)row["address"];
                gridPerson.SelectedItem = row;
            }
            else
            {
                MessageBox.Show("Person not found.");
            }
        }
    }
}

