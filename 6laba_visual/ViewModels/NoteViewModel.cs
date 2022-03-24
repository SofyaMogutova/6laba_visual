using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using _6laba_visual.Models;

namespace _6laba_visual.ViewModels
{
    public class NoteViewModel : ViewModelBase
    {
        private string title;
        private string description;
        private Note lastItem = new Note("", "");
        public Note Item = new Note("", "");
        public NoteViewModel(Note item) : this()
        {
            Item = item;
            lastItem = (Note)item.Clone();
            Title = Item.Title;
            Description = Item.Description;
        }
        public NoteViewModel()
        {
            var msgEnabled = this.WhenAnyValue(
                msg => msg.Title,
                msg => !string.IsNullOrWhiteSpace(msg)
            );

            Send = ReactiveCommand.Create(() => new Note(Title, Description), msgEnabled);
            Cancel = ReactiveCommand.Create(() => {
                Item.Title = lastItem.Title;
                Item.Description = lastItem.Description;
            });
        }
        public ReactiveCommand<Unit, Note> Send { get; set; }
        public ReactiveCommand<Unit, Unit> Cancel { get; set; }

        public string Title
        {
            get => title;
            set
            {
                Item.Title = value;
                this.RaiseAndSetIfChanged(ref title, value);
            }
        }
        public string Description
        {
            get => description;
            set
            {
                Item.Description = value;
                this.RaiseAndSetIfChanged(ref description, value);
            }
        }

    }
}