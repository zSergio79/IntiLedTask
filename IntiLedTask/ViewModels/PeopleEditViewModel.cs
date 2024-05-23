using CommunityToolkit.Mvvm.ComponentModel;

using IntiLedTask.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace IntiLedTask.ViewModels
{
    public class PeopleEditViewModel: ViewModelBase
    {
        #region consts
        private const string nameErrorSpace = "Имя не может содержать пробелы.";
        private const string surnameErrorSpace = "Фамилия не может содержать пробелы.";
        private const string ageErrorRange = "Возраст должен находится в пределах от 0 до 100.";
        #endregion

        #region Model People
        private People people;
        public People People { get=>people;}
        #endregion

        #region Bindable Properties
        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя не может быть пустым.")]
        [SpaceStringValidator(ErrorMessage = nameErrorSpace)]
        public string Name
        {
            get => people.Name;
            set => SetProperty(people.Name, value, (o) => { people.Name = o; });
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия не может быть пустой.")]
        [SpaceStringValidator(ErrorMessage = surnameErrorSpace)]
        public string Surname
        {
            get => people.Surname;
            set => SetProperty(people.Surname, value, (o) => { people.Surname = o; });
        }

        /// <summary>
        /// Возраст
        /// </summary>
        [Required]
        [Range(typeof(int), "0", "100", ErrorMessage = ageErrorRange)]
        public int? Age
        {
            get => people.Age;
            set { SetProperty(people.Age, value ?? 0, (o) => { people.Age = o; });  }
        }

        /// <summary>
        /// Город проживания
        /// </summary>
        public string City
        {
            get => people.City;
            set => SetProperty(people.City, value, (o) => { people.City = o;});
        }
        #endregion

        #region .ctor
        public PeopleEditViewModel()
        {
              people = new People();
        }

        public PeopleEditViewModel(People peop)
        {
            people = peop;
        }
        #endregion
    }
}