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
        private const string nameErrorSpace = "��� �� ����� ��������� �������.";
        private const string surnameErrorSpace = "������� �� ����� ��������� �������.";
        private const string ageErrorRange = "������� ������ ��������� � �������� �� 0 �� 100.";
        #endregion

        #region Model People
        private People people;
        public People People { get=>people;}
        #endregion

        #region Bindable Properties
        /// <summary>
        /// ��� ������������
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "��� �� ����� ���� ������.")]
        [SpaceStringValidator(ErrorMessage = nameErrorSpace)]
        public string Name
        {
            get => people.Name;
            set => SetProperty(people.Name, value, (o) => { people.Name = o; });
        }

        /// <summary>
        /// �������
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "������� �� ����� ���� ������.")]
        [SpaceStringValidator(ErrorMessage = surnameErrorSpace)]
        public string Surname
        {
            get => people.Surname;
            set => SetProperty(people.Surname, value, (o) => { people.Surname = o; });
        }

        /// <summary>
        /// �������
        /// </summary>
        [Required]
        [Range(typeof(int), "0", "100", ErrorMessage = ageErrorRange)]
        public int? Age
        {
            get => people.Age;
            set { SetProperty(people.Age, value ?? 0, (o) => { people.Age = o; });  }
        }

        /// <summary>
        /// ����� ����������
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