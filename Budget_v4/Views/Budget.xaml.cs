using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
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
using Budget_v4.Model;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Globalization;
using System.Security.Policy;

namespace Budget_v4.Views
{
    /// <summary>
    /// Logika interakcji dla klasy Budget.xaml
    /// </summary>
    public partial class Budget : Window
    {

        Budgetv2DatabaseEntities context = new Budgetv2DatabaseEntities();
        CollectionViewSource incViewSource;
        CollectionViewSource outViewSource;
        CollectionViewSource savViewSource;
        

        public Budget()
        {
            InitializeComponent();

            incViewSource = ((CollectionViewSource)(FindResource("incomesViewSource")));
            outViewSource = ((CollectionViewSource)(FindResource("outcomesViewSource")));
            savViewSource = ((CollectionViewSource)(FindResource("savingsViewSource")));

            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            context.Incomes.Load();
            context.Outcomes.Load();
            //context.Savings.Load();
            incViewSource.Source = context.Incomes.Local;
            outViewSource.Source = context.Outcomes.Local;
           // savViewSource.Source = context.Savings.Local;
            valueLabel.Content = SumUp();


            System.Windows.Data.CollectionViewSource savingsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("savingsViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // savingsViewSource.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource paydayViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("paydayViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // paydayViewSource.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource incomesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("incomesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // incomesViewSource.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource incomesViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("incomesViewSource1")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // incomesViewSource1.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource outcomesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("outcomesViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // outcomesViewSource.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource paydayViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("paydayViewSource1")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // paydayViewSource1.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource paydayViewSource2 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("paydayViewSource2")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // paydayViewSource2.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource savingsViewSource1 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("savingsViewSource1")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // savingsViewSource1.Źródło = [ogólne źródło danych]
            System.Windows.Data.CollectionViewSource savingsViewSource2 = ((System.Windows.Data.CollectionViewSource)(this.FindResource("savingsViewSource2")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // savingsViewSource2.Źródło = [ogólne źródło danych]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditIncomes editIncomes = new EditIncomes();
            editIncomes.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EditOutcomes editOutcomes = new EditOutcomes();
            editOutcomes.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ChangePayday changePayday = new ChangePayday();
            changePayday.Show();
        }

        /*private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ChangeSavings changeSavings = new ChangeSavings();
            changeSavings.Show();
        }*/

        private decimal SumUp()
        {
            using (var ctx = new Budgetv2DatabaseEntities())
            {
                decimal sum = 0;
                decimal sumout = 0;
                ///var savingsList = ctx.Savings.ToList();
               /// foreach (var saving in savingsList)
                ///{
                ///    sum += (decimal)saving.Value;
                ///}

                
                var incomestList = ctx.Incomes.ToList();
                foreach(var income in incomestList)
                {
                    sum += income.IncomeValue;
                }
                incomeValueLabel.Content = sum;
                var outcomestList = ctx.Outcomes.ToList();
                {
                    foreach (var outcome in outcomestList)
                    {
                        sumout+=outcome.OutcomeValue;
                        sum -= outcome.OutcomeValue;
                    }
                }
                outcomeValueLabel.Content = sumout;
                return (decimal)sum;
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            context.Incomes.Load();
            context.Outcomes.Load();
            //context.Savings.Load();
            incViewSource.Source = context.Incomes.Local;
            outViewSource.Source = context.Outcomes.Local;
            //savViewSource.Source = context.Savings.Local;
            SumUp();

        }
    }
}
