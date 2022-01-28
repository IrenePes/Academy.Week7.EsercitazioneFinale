using Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCard;
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
    /// Interaction logic for EditorView.xaml
    /// </summary>
    public partial class EditorView : Window
    {
        public EditorView()
        {
            InitializeComponent();
            Messenger.Default.Register<ShowCreateGiftCardMessage>(this, OnShowCreateGiftCardExecuted);
        }

        private void OnShowCreateGiftCardExecuted(ShowCreateGiftCardMessage obj)
        {
            CreateView view = new CreateView();
            CreateViewModel vm = new CreateViewModel();
            view.DataContext = vm;

            view.ShowDialog();
        }
    }
}
