using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleCrash.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUp : ContentView
    {
        public static readonly BindableProperty CloseCommandProperty =
            BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(PopUp), null, BindingMode.TwoWay);

        public static readonly BindableProperty PopUpContentProperty =
            BindableProperty.Create(nameof(PopUpContent), typeof(ContentView), typeof(PopUp), null, BindingMode.TwoWay);

        public ICommand CloseCommand
        {
            get
            {
                return (ICommand)GetValue(CloseCommandProperty);
            }
            set
            {
                SetValue(CloseCommandProperty, value);
            }
        }

        public ContentView PopUpContent
        {
            get
            {
                return (ContentView)GetValue(PopUpContentProperty);
            }
            set
            {
                SetValue(PopUpContentProperty, value);
            }
        }

        public PopUp()
        {
            InitializeComponent();
        }
    }
}
