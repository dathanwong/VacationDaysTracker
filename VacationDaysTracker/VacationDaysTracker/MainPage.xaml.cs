using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using Xamarin.Forms.Xaml;

namespace VacationDaysTracker
{
	public partial class MainPage : ContentPage
	{
        DataAccess dataAccess;

		public MainPage()
		{
			InitializeComponent();
            //Establish SQLite Connection
            dataAccess = new DataAccess(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Vacations.db3"));
		}

        protected override async void OnAppearing()
        {
            List<Vacation> vacations = new List<Vacation>();
            vacations = await dataAccess.GetVacations();
            VacationsListView.ItemsSource = vacations;
            base.OnAppearing();
        }

        //Add a vacation to the calendar
        private async void AddVacation_Clicked(object sender, EventArgs e)
        {
            Vacation vacation = new Vacation();
            vacation.VacationStart = startDatePicker.Date;
            vacation.VacationEnd = endDatePicker.Date;
            await dataAccess.AddVacationAsync(vacation);
            VacationsListView.ItemsSource = await dataAccess.GetVacations();
        }


        //Clear all added vacations from SQL table
        private void ClearVacation_Clicked(object sender, EventArgs e)
        {
            dataAccess.DeleteAllVacations();
            VacationsListView.ItemsSource = null;
        }

        private void CalculateBalance_Clicked(object sender, EventArgs e)
        {
            Day[] calendar = CreateCalendar();
            
            //var test = CalculateBalanceAsync();
            //vacationBalanceLabel.Text = CalculateBalanceAsync().ToString();
        }

        ////////////////////////////////////////////////////////////////
        ///
        //Create 500 days of calendar
        private Day[] CreateCalendar()
        {
            DateTime startDate = new DateTime(2019, 1, 1);
            int startBalance = int.Parse(startBalanceEntry.Text);
            int currentBalance = startBalance;
            int accrualRate = int.Parse(accrualRateEntry.Text);
            Day[] calendar = new Day[500];
            calendar[0] = new Day(startDate, startBalance, accrualRate);
            for (int i = 1; i <500; i++)
            {
                currentBalance = calendar[i - 1].GetBalance();
                calendar[i] = new Day(calendar[i-1].GetDate().AddDays(1), currentBalance, accrualRate);
            }
            return calendar;
        }
    }
}
