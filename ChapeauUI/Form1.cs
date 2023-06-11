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
            OpenPanel(pnlTableOverview);
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
        private void DisplayOrderOverview()
        {
            //Clearing the LV before displaying
            LVOrderOverview.Clear();

            //Filling the LV Column headers
            LVOrderOverview.View = View.Details; //Displays each item on a seperate line
            LVOrderOverview.Columns.Add("no.", 50);
            LVOrderOverview.Columns.Add("name", 200);
            LVOrderOverview.Columns.Add("price",LVOrderOverview.Width - 250);
        }

        private void LunchNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewLunch);
        }

        private void DinnerNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewDinner);
        }

        private void DrinksNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewDrinks);
        }
    }
}
