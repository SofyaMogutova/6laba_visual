using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using _6laba_visual.Models;
using System.Reactive;
using ReactiveUI;
using System.Reactive.Linq;

namespace _6laba_visual.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase list;
        public MainWindowViewModel()
        {
            List = Fv = new MainViewModel();

        }
        public ViewModelBase List
        {
            get => list;
            set => this.RaiseAndSetIfChanged(ref list, value);
        }
        public MainViewModel Fv
        {
            get;
        }
        public void DeleteItem(Note item)
        {
            Fv.DeleteItem = item;
        }
        public void ChangeViewOnItem(Note item)
        {
            if (list is MainViewModel)
            {
                var vm = new NoteViewModel(item);

                Observable.Merge(vm.Send, vm.Cancel.Select(_ => (Note)null))
                    .Take(1)
                    .Subscribe(msg =>
                    {
                        List = Fv;
                    }
                );
                List = vm;
            }
            else if (list is NoteViewModel)
            {
                List = new MainViewModel();
            }
        }
        public void ChangeView()
        {
            if (list is MainViewModel)
            {
                var vm = new NoteViewModel();

                Observable.Merge(vm.Send, vm.Cancel.Select(_ => (Note)null))
                    .Take(1)
                    .Subscribe(msg =>
                    {
                        if (msg != null)
                        {
                            Fv.NewItem = msg;
                        }
                        List = Fv;
                    }
                );
                List = vm;
            }
            else if (list is NoteViewModel)
            {
                List = new MainViewModel();
            }
        }
    }
}