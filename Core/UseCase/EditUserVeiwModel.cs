using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    public class EditUserVeiwModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int Id { get; }
        private string firstName;
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string lastName;
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private int age;
        public int Age
        {
            get => age;
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private int points;
        public int Points
        {
            get => points;
            set
            {
                points = value;
                OnPropertyChanged(nameof(Points));
            }
        }


        public EditUserVeiwModel(Domain.Models.Core user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Age = user.Age;
            Points = user.Points;
        }

        protected void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}