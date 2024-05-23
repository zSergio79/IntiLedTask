using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using IntiLedTask.Dialogs;
using IntiLedTask.Models;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace IntiLedTask.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region Bindable Properties
        [ObservableProperty]
        private PeopleEditViewModel? peopleForEdit;
        [ObservableProperty]
        private ObservableCollection<PeopleEditViewModel> peopleForEditCollection = new();
        [ObservableProperty]
        private string status = string.Empty;
        #endregion

        #region Commands
        [RelayCommand]
        private void DeletePeople()
        {
            if(PeopleForEdit != null)
                PeopleForEditCollection.Remove(PeopleForEdit);
        }

        [RelayCommand]
        private async Task EditPeople(object parameter)
        {

            if (PeopleForEdit != null)
            {
                PeopleEditDialog dialog = new PeopleEditDialog();
                PeopleEditViewModel tempPeople = new()
                {
                    Name = PeopleForEdit.Name,
                    Surname = PeopleForEdit.Surname,
                    Age = PeopleForEdit.Age,
                    City = PeopleForEdit.City
                };
                var result = await dialog.Show(tempPeople);
                if(result != null)
                {
                    PeopleForEdit.Name = tempPeople.Name;
                    PeopleForEdit.Surname = tempPeople.Surname;
                    PeopleForEdit.Age = tempPeople.Age;
                    PeopleForEdit.City = tempPeople.City;
                }
            }
        }
        [RelayCommand]
        private async Task AddPeople()
        {
            PeopleEditDialog dialog = new PeopleEditDialog();
            var result = await dialog.Show(new PeopleEditViewModel());
            if(result != null)
            {
                PeopleForEditCollection.Add(result);
            }
        }
        #endregion

        #region Save/Load
        public async Task Save(string filename)
        {
            try
            {
                using (FileStream writer = new FileStream(filename, FileMode.Create))
                {
                    List<People> peoples = PeopleForEditCollection.Select(x => x.People).ToList();
                    await JsonSerializer.SerializeAsync(writer, peoples);
                }
            }
            catch { }
        }

        public async Task Load(string filename)
        {
            try
            {
                Status = "Загрузка данных.";
                using (FileStream reader = new FileStream(filename, FileMode.Open))
                {
                    List<People>? peoples = await JsonSerializer.DeserializeAsync<List<People>>(reader);
                    if (peoples != null)
                    {
                        PeopleForEditCollection = new ObservableCollection<PeopleEditViewModel>(peoples.Select(x => new PeopleEditViewModel(x)));
                    }
                }
                Status = "Данные загружены.";
            }
            catch 
            {
                Status = "Ошибка при загрузке данных.";
            }
        }
        #endregion

        #region .ctor
        public MainWindowViewModel()
        {
            PeopleForEdit = new PeopleEditViewModel(new Models.People() { Name = "Uasia", Age = 22, City = "SPB", Surname = "Pupkin" });
            PeopleForEditCollection = [PeopleForEdit];
        }

        public MainWindowViewModel(IEnumerable<People> peoples)
        {
            PeopleForEditCollection = new(peoples.Select(x => new PeopleEditViewModel(x)));
        }
        #endregion
    }
}
