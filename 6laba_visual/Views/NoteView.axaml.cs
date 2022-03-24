using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using _6laba_visual.ViewModels;

namespace _6laba_visual.Views
{
    public partial class NoteView : UserControl
    {
        public NoteView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}