using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ExampleCrash.PageModels;
using ExampleCrash.Helpers;

namespace ExampleCrash.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetHasNavigationBar(this, false);

            BindingContextChanged += (sender, args) =>
            {
                MainPageModel vm = BindingContext as  MainPageModel;

                if (vm == null)
                {
                    return;
                }

                vm.PopupHelper = new PopupHelper();
                vm.PopupHelper.AddPopUp("PopUp", _popUp);
            };
        }
    }
}
