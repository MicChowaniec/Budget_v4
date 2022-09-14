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
using System.Windows.Shapes;
using Budget_v4.ViewModel;
using Budget_v4;
using Budget_v4.Model;
using System.Xml.Linq;
using System.Globalization;
using System.Data.Entity;

namespace Budget_v4.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddNewIncome.xaml
    /// </summary>
    public partial class AddNewIncome : Window
    {
        Budgetv2DatabaseEntities context = new Budgetv2DatabaseEntities();
        CollectionViewSource incViewSource;

        public AddNewIncome()
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
            Incomes income = new Incomes();
            income.Date = (DateTime)dateDatePicker.SelectedDate;
            
            Decimal.TryParse(incomeValueTextBox.Text,NumberStyles.Any, CultureInfo.InvariantCulture,out decimal incomveValue) ;
            income.IncomeValue = incomveValue;
            income.IsMonthly = (bool)(isMonthlyCheckBox.IsChecked);
            income.Name = nameTextBox.Text;
            income.UserId = Convert.ToInt64( userIdTextBox.Text);

            context.Incomes.Local.Add(income);
            context.SaveChanges();
            Close();



        }

        
    }
}
