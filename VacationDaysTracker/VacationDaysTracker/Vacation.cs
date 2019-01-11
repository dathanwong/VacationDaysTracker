using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.ComponentModel;

namespace VacationDaysTracker
{
    [Table("Vacations")]
    public class Vacation : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private DateTime _vacationStart;
        [NotNull]
        public DateTime VacationStart
        {
            get
            {
                return _vacationStart;
            }
            set
            {
                this._vacationStart = value;
                OnPropertyChanged(nameof(VacationStart));
            }
        }

        private DateTime _vacationEnd;
        [NotNull]
        public DateTime VacationEnd
        {
            get
            {
                return _vacationEnd;
            }
            set
            {
                this._vacationEnd = value;
                OnPropertyChanged(nameof(VacationEnd));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Duration
        {
            get
            {
                TimeSpan duration = VacationEnd - VacationStart;
                return duration.Days;
            }
        }
    }
}
