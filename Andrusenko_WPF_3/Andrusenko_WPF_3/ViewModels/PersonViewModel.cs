using Andrusenko_WPF_3.Tools;
using Andrusenko_WPF_3.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Andrusenko_WPF_3.Tools.Exceptions;

namespace Andrusenko_WPF_3.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {

        private bool _isLoading = false;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
                ((RelayCommand<object>)ProceedCommand).RaiseCanExecuteChanged();
            }
        }


        private readonly Person _person;

        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                OnPropertyChanged();
                CheckInputValidity();
            }
        }

        public string Surname
        {
            get => _person.Surname;
            set
            {
                _person.Surname = value;
                OnPropertyChanged();
                CheckInputValidity();
            }
        }

        public string Email
        {
            get => _person.Email;
            set
            {
                _person.Email = value;
                OnPropertyChanged();
                CheckInputValidity();
            }
        }

        public DateTime DateOfBirth
        {
            get => _person.DateOfBirth;
            set
            {
                _person.DateOfBirth = value;
                OnPropertyChanged();
                CheckInputValidity();
            }
        }

        private bool _isInputValid = false;
        public bool IsInputValid
        {
            get => _isInputValid;
            set
            {
                _isInputValid = value;
                OnPropertyChanged();
            }
        }

        public bool IsNotBlocked()
        {
            return IsInputValid && !IsLoading;
        }

        public ICommand ProceedCommand => new RelayCommand<object>(async _ => await ExecuteProceedCommandAsync(), _ => CanExecuteProceedCommand());

        public PersonViewModel()
        {
            _person = new Person("", "", "", DateTime.Today);
        }

        private bool CanExecuteProceedCommand() => IsInputValid;

        private void CheckInputValidity()
        {
            IsInputValid = !string.IsNullOrWhiteSpace(Name) &&
                           !string.IsNullOrWhiteSpace(Surname) &&
                           !string.IsNullOrWhiteSpace(Email) &&
                           DateOfBirth != default;
        }

        private async Task ExecuteProceedCommandAsync()
        {
            try
            {
                CheckIfPersonIsValid();

                IsLoading = true;

                MessageBox.Show(CalculateValues());

                DateTime today = DateTime.Today;

                bool hasBirthday = await Task.Run(() => _person.IsBirthday);

                if (hasBirthday)
                {
                    MessageBox.Show("Happy birthday!");
                }
                IsLoading = false;
            }
            catch(DateIsInFarPastException e)
            {
                MessageBox.Show(e.Message);
            }
            catch(DateIsInFutureException e)
            {
                MessageBox.Show(e.Message);
            }
            catch(InvalidEmailAddressException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CheckIfPersonIsValid()
        {
            if (!_person.CheckDateIsNotFuture())
            {
                throw new DateIsInFutureException("Date of birth is in future!");
            }
            if (!_person.CheckDateIsNotFarPast())
            {
                throw new DateIsInFutureException("You can't be older than 135 years old!");
            }
            if (!_person.CheckEmailValidity())
            {
                throw new DateIsInFutureException("Email is invalid!");
            }
        }


        private string CalculateValues()
        {
            return $@"Info.
Name: {Name}, Surname: {Surname}
Email: {Email}
Date of birth: {DateOfBirth}
Is adult: {_person.IsAdult}
Sun sign: {_person.SunSign}
Chinese sign: {_person.ChineseSign}
Is birthday: {_person.IsBirthday}
";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
