using System;
using System.Collections.Generic;
using System.Text;

namespace VacationDaysTracker
{
    class Day
    {
        private DateTime date { get; set; }
        private int vacationBalance { get; set; }
        private int accrualRate { get; set; }
        private int vacationUsed { get; set; }

        public Day(DateTime date, int startBalance, int accrualRate)
        {
            //initiate variables
            this.date = date;
            vacationBalance = startBalance;
            vacationUsed = 0;
            this.accrualRate = accrualRate;
            //Check if it is a pay day and add vacation if it is
            if (date.Day == 15 || date.Day == 28)
            {
                vacationBalance = vacationBalance + accrualRate;
            }
        }

        //Adds vacation to day and removes from vacation balance
        public void AddVacation(int hours)
        {
            vacationUsed = hours;
            vacationBalance = vacationBalance - hours;
        }

        //Remove vacation set on day and add back to vacation balance
        public void RemoveVacation()
        {
            vacationBalance = vacationBalance + vacationUsed;
            vacationUsed = 0;
        }

        //Get vacation balance of this date
        public int GetBalance()
        {
            return vacationBalance;
        }

        //Get date
        public DateTime GetDate()
        {
            return date;
        }

        //Get used vacation
        public int GetVacationUsed()
        {
            return vacationUsed;
        }
    }
}
