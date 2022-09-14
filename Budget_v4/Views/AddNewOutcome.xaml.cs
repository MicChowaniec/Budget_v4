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
    /// Logika interakcji dla klasy AddNewOutcome.xaml
    /// </summary>
    public partial class AddNewOutcome : Window
    {
        Budgetv2DatabaseEntities context = new Budgetv2DatabaseEntities();
        CollectionViewSource incViewSource;

        public AddNewOutcome()
        {
            InitializeComponent();

            incViewSource = ((CollectionViewSource)(FindResource("outcomesViewSource")));

            DataContext = this;

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context.Outcomes.Load();
            incViewSource.Source = context.Outcomes.Local;


            System.Windows.Data.CollectionViewSource goalsViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("goalsViewSource")));
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // goalsViewSource.Źródło = [ogólne źródło danych]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Outcomes Outcome = new Outcomes();
            Outcome.Date = (DateTime)dateDatePicker.SelectedDate;
            
            Decimal.TryParse(OutcomeValueTextBox.Text,NumberStyles.Any, CultureInfo.InvariantCulture,out decimal incomveValue) ;
            Outcome.OutcomeValue = incomveValue;
            Outcome.IsMonthly = (bool)(isMonthlyCheckBox.IsChecked);
            Outcome.Name = nameTextBox.Text;
            Outcome.UserId = Convert.ToInt64( userIdTextBox.Text);

            context.Outcomes.Local.Add(Outcome);
            context.SaveChanges();
            Close();



        }

        
    }
}
