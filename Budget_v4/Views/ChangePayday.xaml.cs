using Budget_v4.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

namespace Budget_v4.Views
{

    
    /// <summary>
    /// Logika interakcji dla klasy ChangePayday.xaml
    /// </summary>
    public partial class ChangePayday : Window
    {
        Budgetv2DatabaseEntities context = new Budgetv2DatabaseEntities();
        CollectionViewSource payViewSource;

        public ChangePayday()
        {
            
            InitializeComponent();

            payViewSource = ((CollectionViewSource)(FindResource("paydayViewSource")));

            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Payday.Load();
            

            System.Windows.Data.CollectionViewSource paydayViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("paydayViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // paydayViewSource.Źródło = [ogólne źródło danych]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Payday payday = new Payday();
            payday.Day = (DateTime)(dayDatePicker.SelectedDate);
            context.Payday.AddOrUpdate();
            context.SaveChanges();
            Close();

        }
    }
}
