using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using ChapeauModel;
using ChapeauDAL;
using ChapeauService;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ChapeauUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            ShowOrderOverviewPnl();
        }
        private void OpenPanel(Control panelToOpen) // closes all panels except for the panel in the argument and the default Menu panel
        {
            foreach (Control control in Controls)
            {
                if (control is Panel panel && panel != panelToOpen && panel != pnlMenu)
                {
                    panel.Hide();
                    panelToOpen.Show();
                }
            }
            
        }
        private void ShowOrderOverviewPnl()
        {
            OpenPanel(pnlTableOverview); //Opens the OrderOverviewPNL

            using (SqlConnection connection = new SqlConnection("Data Source=somerenit1bt2.database.windows.net; Initial Catalog=Project_SomerenIT1BT2; User=SomerenTeam2; Password=ProjectT3Team2"))
            {
                connection.Open();

                string query = "SELECT T.Table_Num, E.Last_Name, O.Total_Price " +
                    "FROM[Table] AS T " +
                    "JOIN[Order] AS O ON T.TableID = O.TableID " +
                    "JOIN Employee AS E ON O.EmployeeID = E.EmployeeID";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    ListViewItem item = new ListViewItem(row["Table_Num"].ToString());
                    item.SubItems.Add(row["Last_Name"].ToString());
                    item.SubItems.Add(row["Total_Price"].ToString());

                    LVOrderOverview.Items.Add(item);
                }
            }

           /* try
            {
                List<Table> tableNumber = GetTables();
                List<Employee> employeeName = GetEmployeeNames();
                DisplayTableOrderOverview(tableNumber, employeeName);
            }
            catch (Exception e)
            {
                MessageBox.Show("Whoops, the order overview could not be loaded.\n" +
                    "Please try to restart the application or contact your manager. " + e.Message);
            } */

        }
        public List<Table> GetTables()
        {
            TableService tableService = new TableService();
            List<Table> tables = tableService.GetTables();
            return tables;
        }
        public List<Employee> GetEmployeeNames()
        {
            EmployeeService employeeService = new EmployeeService();
            List<Employee> employee = employeeService.GetEmployees();
            return employee;
        }
        private void DisplayTableOrderOverview(List<Table> tables, List<Employee> employees)
        {
            //Clearing the LV before displaying
            LVOrderOverview.Clear();

            //Filling the LV Column headers
            LVOrderOverview.View = View.Details; //Displays each item on a seperate line
            LVOrderOverview.Columns.Add("no.", 50);
            LVOrderOverview.Columns.Add("name", 200);
            LVOrderOverview.Columns.Add("price",LVOrderOverview.Width - 250);

            foreach (Table table in tables)
            {
                ListViewItem item = new ListViewItem(table.Table_Num.ToString());
                item.Tag = table;   // link table object to listview item
                LVOrderOverview.Items.Add(item);
            }
        }
        


        //
        //
        //
        //
        // NAV
        private void LunchNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewLunch);

            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = true;
            LunchNavButton.Enabled = false;

            string Originalbackcolor = LunchNavButton.BackColor.ToString();
            LunchNavButton.BackColor = Color.LightGray;
            DinnerNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGreen;
        }

        private void DinnerNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewDinner);

            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = false;
            LunchNavButton.Enabled = true;

            DinnerNavButton.BackColor = Color.LightGray;
            LunchNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGreen;
        }

        private void DrinksNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewDrinks);

            DrinksNavButton.Enabled = false;
            DinnerNavButton.Enabled = true;
            LunchNavButton.Enabled = true;

            DrinksNavButton.BackColor = Color.LightGray;
            LunchNavButton.BackColor = Color.LightGreen;
            DinnerNavButton.BackColor = Color.LightGreen;
        }
    }
}
