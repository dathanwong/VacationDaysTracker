using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VacationDaysTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewPage : ContentPage
	{

        String[] months = new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        DateTime currrentMonth = new DateTime(2019, 1, 1);

		public NewPage ()
		{
			InitializeComponent ();
		}

        //Show previous month in calendar
        private void PreviousMonthButton_Clicked(object sender, EventArgs e)
        {
            String month = monthLabel.Text;
            DateTime previousMonth = currrentMonth.AddMonths(-1);
            currrentMonth = previousMonth;
            monthLabel.Text = currrentMonth.ToString("Y");

            //switch (month)
            //{
            //    case "January":
            //        monthLabel.Text = "December";
            //        break;
            //    case "February":
            //        monthLabel.Text = "January";
            //        break;
            //    case "March":
            //        monthLabel.Text = "February";
            //        break;
            //    case "April":
            //        monthLabel.Text = "March";
            //        break;
            //    case "May":
            //        monthLabel.Text = "April";
            //        break;
            //    case "June":
            //        monthLabel.Text = "May";
            //        break;
            //    case "July":
            //        monthLabel.Text = "June";
            //        break;
            //    case "August":
            //        monthLabel.Text = "July";
            //        break;
            //    case "September":
            //        monthLabel.Text = "August";
            //        break;
            //    case "October":
            //        monthLabel.Text = "September";
            //        break;
            //    case "November":
            //        monthLabel.Text = "October";
            //        break;
            //    case "December":
            //        monthLabel.Text = "November";
            //        break;
            //    default:
            //        Debug.WriteLine("Unknown month in calendar???");
            //        return;
            //}
            //currrentMonth.AddMonths(-1);
        }

        //Show next month in calendar
        private void NextMonthButton_Clicked(object sender, EventArgs e)
        {
            String month = monthLabel.Text;
            DateTime nextMonth = currrentMonth.AddMonths(1);
            currrentMonth = nextMonth;
            monthLabel.Text = currrentMonth.ToString("Y");
            //switch (month)
            //{
            //    case "January":
            //        monthLabel.Text = "February";
            //        break;
            //    case "February":
            //        monthLabel.Text = "March";
            //        break;
            //    case "March":
            //        monthLabel.Text = "April";
            //        break;
            //    case "April":
            //        monthLabel.Text = "May";
            //        break;
            //    case "May":
            //        monthLabel.Text = "June";
            //        break;
            //    case "June":
            //        monthLabel.Text = "July";
            //        break;
            //    case "July":
            //        monthLabel.Text = "August";
            //        break;
            //    case "August":
            //        monthLabel.Text = "September";
            //        break;
            //    case "September":
            //        monthLabel.Text = "October";
            //        break;
            //    case "October":
            //        monthLabel.Text = "November";
            //        break;
            //    case "November":
            //        monthLabel.Text = "December";
            //        break;
            //    case "December":
            //        monthLabel.Text = "January";
            //        break;
            //    default:
            //        Debug.WriteLine("Unknown month in calendar???");
            //        return;
            //}
            //currrentMonth.AddMonths(1);
        }

        private void PopulateCalendarDates()
        {
            //Check what month it is
           
        }

    }
}