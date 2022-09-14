using Budget_v4.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Globalization;
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
    /// Logika interakcji dla klasy ChangeSavings.xaml
    /// </summary>
    /// 



    public partial class ChangeSavings : Window
    {
        Budgetv2DatabaseEntities context = new Budgetv2DatabaseEntities();
        CollectionViewSource savViewSource;

        public ChangeSavings()
        {
            InitializeComponent();

            savViewSource = ((CollectionViewSource)(FindResource("savingsViewSource")));

            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            context.Savings.Load();
            savViewSource.Source = context.Savings.Local;

        }

        /* private void Button_Click(object sender, RoutedEventArgs e)
        {



            Savings saving = new Savings();
            Decimal.TryParse(valueTextBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal savValue);
            saving.Value = savValue;

           
            context.Savings.AddOrUpdate(saving);
            context.SaveChanges();
            Close();


        }
        */
    }

}