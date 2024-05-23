using Avalonia.Controls.ApplicationLifetimes;

using IntiLedTask.ViewModels;
using IntiLedTask.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiLedTask.Dialogs
{
    public class PeopleEditDialog
    {
        public PeopleEditDialog() { }
        public async Task<PeopleEditViewModel?> Show(PeopleEditViewModel people)
        {
            PeopleEditViewDialog dialog = new PeopleEditViewDialog();
            dialog.DataContext = people;
            var desktop = App.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime;

            if (desktop != null)
            {
               var result = await dialog.ShowDialog<PeopleEditViewModel>(desktop.MainWindow);
               return result;
            }
            return null;
        }
    }
}
