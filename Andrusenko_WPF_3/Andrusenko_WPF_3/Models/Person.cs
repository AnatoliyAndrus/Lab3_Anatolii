using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Andrusenko_WPF_3.Tools.Exceptions;

namespace Andrusenko_WPF_3.Models
{
    public class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _dateOfBirth;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
            }
        }
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
            }
        }

        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth.Date > today.AddYears(-age))
                    age--;
                return age;
            }
        }


        public bool IsAdult => CalculateIsAdult();
        public string SunSign => CalculateSunSign();
        public string ChineseSign => CalculateChineseSign();
        public bool IsBirthday => CalculateIsBirthday();


        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            Name = name;
            Surname = surname;
            Email = email;
            DateOfBirth = dateOfBirth;
        }
        public Person(string name, string surname, string email)
            : this(name, surname, email, DateTime.MinValue)
        {
        }
        public Person(string name, string surname, DateTime dateOfBirth)
            : this(name, surname, null, dateOfBirth)
        {
        }

        

        private bool CalculateIsAdult()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
        private string CalculateSunSign()
        {
            if (DateTime.Compare(new DateTime(DateOfBirth.Year, 1, 21), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 2, 19), DateOfBirth) >= 0)
            {
                return "Aquarius";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 2, 20), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 3, 20), DateOfBirth) >= 0)
            {
                return "Pisces";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 3, 21), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 4, 20), DateOfBirth) >= 0)
            {
                return "Aries";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 4, 21), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 5, 21), DateOfBirth) >= 0)
            {
                return "Taurus";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 5, 22), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 6, 21), DateOfBirth) >= 0)
            {
                return "Gemini";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 6, 22), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 7, 23), DateOfBirth) >= 0)
            {
                return "Cancer";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 7, 24), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 8, 23), DateOfBirth) >= 0)
            {
                return "Leo";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 8, 24), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 9, 23), DateOfBirth) >= 0)
            {
                return "Virgo";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 9, 24), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 10, 23), DateOfBirth) >= 0)
            {
                return "Libra";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 10, 24), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 11, 22), DateOfBirth) >= 0)
            {
                return "Scorpio";
            }
            else if (DateTime.Compare(new DateTime(DateOfBirth.Year, 11, 23), DateOfBirth) <= 0 && DateTime.Compare(new DateTime(DateOfBirth.Year, 12, 21), DateOfBirth) >= 0)
            {
                return "Sagittarius";
            }
            else
            {
                return "Capricorn";
            }
        }
        private string CalculateChineseSign()
        {
            switch (DateOfBirth.Year % 12)
            {
                case 0:
                    return "Monkey";
                case 1:
                    return "Rooster";
                case 2:
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                default:
                    return "Goat";
            }
        }
        private bool CalculateIsBirthday()
        {
            return DateOfBirth.Month == DateTime.Today.Month && DateOfBirth.Day == DateTime.Today.Day;
        }

        private bool CanExecute(object obj)
        {
            return true;
        }

        public bool CheckEmailValidity()
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(Email);
        }

        public bool CheckDateIsNotFarPast()
        {
            return Age <= 135;
        }

        public bool CheckDateIsNotFuture()
        {
            return Age >= 0;
        }


    }
}
