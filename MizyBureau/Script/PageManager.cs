using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MizyBureau.Script
{
    class PageManager
    {
        public static PageManager instance;

        public Connection ConnectionPage;
        public Home HomePage;
        public Inscription InscriptionPage;


        public enum ListPage { HOME, CONNECTION, INSCRIPTION }

        private enum ListWindows { MAIN, HOME }

        private ListWindows ActiveWindows;

        public PageManager()
        {
            instance = this;
            ConnectionPage = new Connection();
            HomePage = new Home();
            InscriptionPage = new Inscription();
            ActiveWindows = ListWindows.MAIN;
        }

        public void ChangePage(ListPage toPage)
        {
            switch (toPage)
            {
                case ListPage.HOME:
                    TrySwitchWindows(ListWindows.HOME);
                    break;
                case ListPage.CONNECTION:
                    TrySwitchWindows(ListWindows.MAIN);
                    MainWindow.instance._NavigationFrame.Navigate(ConnectionPage);
                    break;
                case ListPage.INSCRIPTION:
                    MainWindow.instance._NavigationFrame.Navigate(InscriptionPage);
                    break;
            }
        }

        private void TrySwitchWindows(ListWindows win)
        {
            switch (win)
            {
                case ListWindows.HOME:
                    if (ActiveWindows != ListWindows.HOME)
                    {
                        ActiveWindows = ListWindows.HOME;
                        MainWindow.instance.Hide();
                        HomePage.Show();                        
                    }
                    break;
                case ListWindows.MAIN:
                    if (ActiveWindows != ListWindows.MAIN)
                    {
                        ActiveWindows = ListWindows.MAIN;
                        HomePage.Hide();
                        MainWindow.instance.Show();
                    }
                    break;
            }
        }


        //Window w = Window.GetWindow(this);
        //User t = new User("toto", true, true);
        //SocketClient s = new SocketClient();
        //s._isStateOk = true;
        //Home home = new Home(u);

        //App.Current.MainWindow = home;
        //w.Close();
        //home.Show();
    }
}
