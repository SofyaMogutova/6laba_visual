using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using _6laba_visual.ViewModels;

namespace _6laba_visual.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            this.FindControl<DatePicker>("DataPicker").SelectedDateChanged += delegate
            {
                DateTimeOffset? selectedDate = this.FindControl<DatePicker>("DataPicker").SelectedDate;
                var context = this.DataContext as MainViewModel;
                if (context != null)
                    context.CurrentDate = selectedDate;
            };
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}