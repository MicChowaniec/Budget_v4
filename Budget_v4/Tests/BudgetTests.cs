using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using Budget_v4.Views;
using Budget_v4.Model;
using NUnit.Framework;

namespace Budget_v4.Tests
{
    class BudgetTests
    {
        public void CreatingNewIncome()
        {
            var income = new Incomes();



            Assert.NotNull(income);
        }
        public void GivinigAnId()
        {
            var income = new Incomes();

            long index = income.Id;


            Assert.AreEqual(index, income.Id);
        }
    }
}
