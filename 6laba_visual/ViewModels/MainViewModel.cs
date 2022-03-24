using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _6laba_visual.Models;
using ReactiveUI;

namespace _6laba_visual.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Note newTitle;
        private DateTimeOffset? currentDate = DateTime.Today;
        private List<Note> allItems = new List<Note>();
        private List<Note> currentItems = new List<Note>();
        private ObservableCollection<Note> items;
        public MainViewModel()
        {
            Items = new ObservableCollection<Note>(allItems);
        }
        public ObservableCollection<Note> Items
        {
            get => items;
            set
            {
                this.RaiseAndSetIfChanged(ref items, value);
            }
        }
        public Note NewItem
        {
            get { return newTitle; }
            set
            {
                value.Date = currentDate;
                allItems.Add(value);
            }
        }
        public Note DeleteItem
        {
            set
            {
                Items.Remove(value);
            }
        }
        public DateTimeOffset? CurrentDate
        {
            get { return currentDate; }
            set
            {
                currentDate = value;
                currentItems.Clear();
                foreach (var item in allItems)
                {
                    if (item.Date == currentDate)
                    {
                        currentItems.Add(item);
                    }
                }
                this.RaiseAndSetIfChanged(ref currentDate, value);
                Items = new ObservableCollection<Note>(currentItems);
            }
        }
        private Note[] BuildArray()
        {
            return new Note[]
            {
                new Note("1", "2"),
                new Note("2", "2")
            };
        }
    }
}