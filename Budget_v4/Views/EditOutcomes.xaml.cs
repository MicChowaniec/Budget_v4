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
    /// Logika interakcji dla klasy EditOutcomes.xaml
    /// </summary>
    public partial class EditOutcomes : Window
    {

        Budgetv2DatabaseEntities context = new Budgetv2DatabaseEntities();
        CollectionViewSource outViewSource;
        
        public EditOutcomes()

        {

            InitializeComponent();

            outViewSource = ((CollectionViewSource)(FindResource("outcomesViewSource")));

            

            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Outcomes.Load();

            outViewSource.Source = context.Outcomes.Local;


            System.Windows.Data.CollectionViewSource outcomesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("outcomesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // outcomesViewSource.Źródło = [ogólne źródło danych]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddNewOutcome addNewOutcome = new AddNewOutcome();
            addNewOutcome.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            context.Outcomes.AddOrUpdate();
            context.Outcomes.Load();
            outViewSource.Source = context.Incomes.Local;
        }
    }
}
