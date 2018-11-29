using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using ExampleCrash.Helpers;
using Xamarin.Forms;
using FreshMvvm;

namespace ExampleCrash.PageModels.PopUps
{
    /// <summary>
    /// View Model for Selecting an Item
    /// </summary>
    /// <author>
    /// Bryce McLane
    /// </author>
    /// <date>
    /// 11/28/2018
    /// </date>
    public class SelectItemViewModel : FreshBasePageModel
    {
        public PopupHelper PopupHelper
        {
            get;
            set;
        }

        public List<Item> Items
        {
            get;
            set;
        }

        public SelectItemViewModel(PopupHelper popUpHelper)
        {
            PopupHelper = popUpHelper;
            Items = new List<Item>()
            {
                new Item("Item 1"),
                new Item("Item 2"),
                new Item("Item 3")

            };
        }
    }
}
