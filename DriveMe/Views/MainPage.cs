using System;

using Xamarin.Forms;

namespace DriveMe
{
    public class MainPage : TabbedPage
    {
        public MainPage()
        {
            Page itemsPage, aboutPage, splashScreen = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    splashScreen = new NavigationPage(new SplashScreen())
                    {
                        Title = "Splash"
                    };

                    itemsPage = new NavigationPage(new ItemsPage())
                    {
                        Title = "Browse"
                    };

                    aboutPage = new NavigationPage(new AboutPage())
                    {
                        Title = "About"
                    };
                    itemsPage.Icon = "tab_feed.png";
                    aboutPage.Icon = "tab_about.png";
                    break;
                default:
                    splashScreen = new SplashScreen()
                    {
                        Title = "Splash"
                    };

                    itemsPage = new ItemsPage()
                    {
                        Title = "Browse"
                    };

                    aboutPage = new AboutPage()
                    {
                        Title = "About"
                    };
                    break;
            }

            Children.Add(itemsPage);
            Children.Add(aboutPage);

            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}
