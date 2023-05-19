using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Session1.DataSet1TableAdapters;
using static Session1.Helper;

namespace Session1
{
    public partial class MainWindow : Window
    {
        DataSet1 dataSet = new DataSet1();
        MainTableAdapter mainTableAdapter = new MainTableAdapter();
        public MainWindow()
        {
            InitializeComponent();

            mainTableAdapter.Fill(dataSet.Main);
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int s = Convert.ToInt32(txtStationID.Text);
                if (s >= 1 && s <= 99)
                {
                    SaveThings.StationID = int.Parse(txtStationID.Text);
                    Management_GAS window = new Management_GAS();
                    window.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("STATION_ID может принимать значение от 1 до 99");
                    txtStationID.Clear();
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Вы ввели символ! Пожалуйста,введите цифрy");
                txtStationID.Clear();
            }

        }
    }
}
