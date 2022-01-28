using Academy.Week7.EsercitazioneFinale.Core.Mock.Storage;
using Academy.Week7.EsercitazioneFinale.WPF.Messaging.Misc;
using Academy.Week7.EsercitazioneFinale.WPF.ViewModels;
using Academy.Week7.EsercitazioneFinale.WPF.Views;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Academy.Week7.EsercitazioneFinale.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Messenger.Default.Register<DialogMessage>(this, OnDialogMessageReceived);

            MockStorage.Initialize();

            HomeView view = new HomeView();
            HomeViewModel vm = new HomeViewModel();
            view.DataContext = vm;

            view.Show();

            base.OnStartup(e);
        }

        private void OnDialogMessageReceived(DialogMessage message)
        {
            MessageBoxResult result = MessageBox.Show(
                message.Content,
                message.Title,
                message.Buttons, message.Icon);

            if (message.Callback != null)
                message.Callback(result);
        }
    }
}
