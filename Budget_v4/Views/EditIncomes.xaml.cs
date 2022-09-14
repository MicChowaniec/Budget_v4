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
    /// Logika interakcji dla klasy EditIncomes.xaml
    /// </summary>
    public partial class EditIncomes : Window
    {
        Budgetv2DatabaseEntities context = new Budgetv2DatabaseEntities();
        CollectionViewSource incViewSource;

        public EditIncomes()
        {
            InitializeComponent();
            incViewSource = ((CollectionViewSource)(FindResource("incomesViewSource")));
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            context.Incomes.Load();
            incViewSource.Source = context.Incomes.Local;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewIncome addNewIncome = new AddNewIncome();
            addNewIncome.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            
            context.Incomes.AddOrUpdate();
            context.Incomes.Load();
            incViewSource.Source = context.Incomes.Local;
        }
    }
}
