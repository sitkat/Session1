using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Session1.DataSet1TableAdapters;
using static Session1.Helper;

namespace Session1
{
    public partial class Management_GAS : Window
    {
        DataSet1 dataSet = new DataSet1();
        MainTableAdapter mainTableAdapter = new MainTableAdapter();
        bool isHas = false;
        public Management_GAS()
        {
            InitializeComponent();
            mainTableAdapter.Fill(dataSet.Main);

            for (int i = 0; i < dataSet.Tables["Main"].Rows.Count; i++)
            {
                if (SaveThings.StationID == int.Parse(dataSet.Tables["Main"].Rows[i]["Station_ID"].ToString()) && "92" == dataSet.Tables["Main"].Rows[i]["Name"].ToString())
                {
                    isHas = true;
                    tbAddress.Text = dataSet.Tables["Main"].Rows[i]["Address"].ToString();
                    txt92Price.Text = dataSet.Tables["Main"].Rows[i]["Price"].ToString();
                    txt92Lost.Text = dataSet.Tables["Main"].Rows[i]["AmountOfFuel"].ToString();
                }
                if (SaveThings.StationID == int.Parse(dataSet.Tables["Main"].Rows[i]["Station_ID"].ToString()) && "95" == dataSet.Tables["Main"].Rows[i]["Name"].ToString())
                {
                    tbAddress.Text = dataSet.Tables["Main"].Rows[i]["Address"].ToString();
                    txt95Price.Text = dataSet.Tables["Main"].Rows[i]["Price"].ToString();
                    txt95Lost.Text = dataSet.Tables["Main"].Rows[i]["AmountOfFuel"].ToString();
                }
                if (SaveThings.StationID == int.Parse(dataSet.Tables["Main"].Rows[i]["Station_ID"].ToString()) && "98" == dataSet.Tables["Main"].Rows[i]["Name"].ToString())
                {
                    tbAddress.Text = dataSet.Tables["Main"].Rows[i]["Address"].ToString();
                    txt98Price.Text = dataSet.Tables["Main"].Rows[i]["Price"].ToString();
                    txt98Lost.Text = dataSet.Tables["Main"].Rows[i]["AmountOfFuel"].ToString();
                }
                if (SaveThings.StationID == int.Parse(dataSet.Tables["Main"].Rows[i]["Station_ID"].ToString()) && "Disel Fuel" == dataSet.Tables["Main"].Rows[i]["Name"].ToString())
                {
                    tbAddress.Text = dataSet.Tables["Main"].Rows[i]["Address"].ToString();
                    txtDTPrice.Text = dataSet.Tables["Main"].Rows[i]["Price"].ToString();
                    txtDTLost.Text = dataSet.Tables["Main"].Rows[i]["AmountOfFuel"].ToString();
                }


            }
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            if (isHas)
            {
                mainTableAdapter.UpdateQuery(tbAddress.Text, double.Parse(txt92Price.Text), double.Parse(txt92Lost.Text), SaveThings.StationID, "92");
                mainTableAdapter.UpdateQuery(tbAddress.Text, double.Parse(txt95Price.Text), double.Parse(txt95Lost.Text), SaveThings.StationID, "95");
                mainTableAdapter.UpdateQuery(tbAddress.Text, double.Parse(txt98Price.Text), double.Parse(txt98Lost.Text), SaveThings.StationID, "98");
                mainTableAdapter.UpdateQuery(tbAddress.Text, double.Parse(txtDTPrice.Text), double.Parse(txtDTLost.Text), SaveThings.StationID, "Disel Fuel");
                mainTableAdapter.Fill(dataSet.Main);
            }
            else
            {
                mainTableAdapter.InsertQuery(tbAddress.Text, SaveThings.StationID, "92", double.Parse(txt92Price.Text), double.Parse(txt92Lost.Text));
                mainTableAdapter.InsertQuery(tbAddress.Text, SaveThings.StationID, "95", double.Parse(txt95Price.Text), double.Parse(txt95Lost.Text));
                mainTableAdapter.InsertQuery(tbAddress.Text, SaveThings.StationID, "98", double.Parse(txt98Price.Text), double.Parse(txt98Lost.Text));
                mainTableAdapter.InsertQuery(tbAddress.Text, SaveThings.StationID, "Disel Fuel", double.Parse(txtDTPrice.Text), double.Parse(txtDTLost.Text));
                mainTableAdapter.Fill(dataSet.Main);
            }
            MainWindow window = new MainWindow();
            window.Show();
            Hide();
        }
    }
}
