using System.Collections.Generic;
using FreshMvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ExampleCrash.PageModels.PopUps;
using ExampleCrash.Views.PopUps;
using ExampleCrash.Helpers;

namespace ExampleCrash.PageModels
{
    /// <summary>
    /// View Model for Main Page
    /// </summary>
    /// <author>
    /// Bryce McLane
    /// </author>
    /// <date>
    /// 11/28/2018
    /// </date>
    public class MainPageModel : FreshBasePageModel
    {
        private ICommand _closePopUpCommand;
        private View _viewForPopUp;

        public ICommand OpenCommand => new Command(async () =>
        {
            // Show Item Selection
            SelectItemViewModel viewModel = new SelectItemViewModel(PopupHelper);

            ViewForPopUp = new SelectItemView
            {
                BindingContext = viewModel
            };

            await PopupHelper.ShowPopUpView("PopUp");

            while (PopupHelper.PopUpOpen)
            {
                await Task.Delay(50);
            }

        });

        public ICommand ClosePopUpCommand => _closePopUpCommand ?? (_closePopUpCommand = new Command(async () =>
        {
            await PopupHelper.HidePopUpView();
        }));

        public PopupHelper PopupHelper
        {
            get;
            set;
        }

        public View ViewForPopUp
        {
            get
            {
                return _viewForPopUp;
            }
            set
            {
                _viewForPopUp = value;
                RaisePropertyChanged();
            }
        }

    }
}
