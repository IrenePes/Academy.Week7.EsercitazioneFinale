using Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCards;
using Academy.Week7.EsercitazioneFinale.WPF.ViewModels;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Academy.Week7.EsercitazioneFinale.WPF.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowGiftCardMessage>(this, OnShowGiftCardMessageReceived);
        }

        private void OnShowGiftCardMessageReceived(ShowGiftCardMessage obj)
        {
            EditorView view = new EditorView();
            EditorViewModel vm = new EditorViewModel();
            view.DataContext = vm;

            view.Show();
        }
    }
}
