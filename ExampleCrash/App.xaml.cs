using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FreshMvvm;
using ExampleCrash.PageModels;
using Xamarin.Forms;

namespace ExampleCrash
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            SetupStartPage();
        }

        /// <summary>
        /// Application developers override this method to perform actions when the application resumes from a sleeping state.
        /// </summary>
        /// <author>
        /// Aaron Coppock
        /// </author>
        /// <date>
        /// 5/29/2018
        /// </date>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnResume()
        {
            // Handle when your app resumes
            SetupStartPage();
        }

        /// <summary>
        /// Setups the start page.
        /// </summary>
        /// <author>
        /// Aaron Coppock
        /// </author>
        /// <date>
        /// 5/29/2018
        /// </date>
        private void SetupStartPage()
        {

            Page mainPage = FreshPageModelResolver.ResolvePageModel<MainPageModel>();

            FreshNavigationContainer navContainer = new FreshNavigationContainer(mainPage)
            {
                BarTextColor = Color.White
            };

            FreshIOC.Container.Register(navContainer.Navigation);

            MainPage = navContainer;
        }

    }
}
