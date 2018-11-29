using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExampleCrash.Helpers
{
    /// <summary>
    /// Handler class for Popup handling
    /// </summary>
    /// <author>
    /// Bryce McLane
    /// </author>
    /// <date>
    /// 11/28/2018
    /// </date>
    public class PopupHelper
    {
        public event EventHandler PopUpOpened;
        public event EventHandler PopUpClosed;

        private readonly Dictionary<string, View> _popUps;
        private View _currentlyOpen;

        public bool PopUpOpen
        {
            get;
            private set;
        }

        public PopupHelper()
        {
            _popUps = new Dictionary<string, View>();
        }

        public void AddPopUp(string key, View viewToAdd)
        {
            _popUps.Add(key, viewToAdd);
        }

        /// <summary>
        /// Shows the pop up.
        /// </summary>
        /// <author>
        /// Bryce McLane
        /// </author>
        /// <date>
        /// 11/28/2018
        /// </date>
        public async Task ShowPopUpView(string key)
        {
            if (_popUps.Count == 0)
            {
                return;
            }

            if (!_popUps.ContainsKey(key))
            {
                return;
            }

            _currentlyOpen = _popUps[key];

            _currentlyOpen.IsVisible = true;
            _currentlyOpen.Opacity = 1;
            PopUpOpen = true;
            PopUpOpened?.Invoke(this, System.EventArgs.Empty);
        }

        /// <summary>
        /// Hides the pop up.
        /// </summary>
        /// <author>
        /// Aaron Coppock
        /// </author>
        /// <date>
        /// 11/28/2018
        /// </date>
        public async Task HidePopUpView()
        {
            if (_currentlyOpen == null)
            {
                return;
            }

            try
            {
                _currentlyOpen.Opacity = 0;
                _currentlyOpen.IsVisible = false;
                PopUpOpen = false;
                PopUpClosed?.Invoke(this, System.EventArgs.Empty);
                _currentlyOpen = null;
            }
            catch
            {
                // Swalllow
            }
        }
    }
}
