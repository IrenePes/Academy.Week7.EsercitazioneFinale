using Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCards;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Academy.Week7.EsercitazioneFinale.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ShowGiftCardsCommand { get; set; }

        public HomeViewModel()
        {
            ShowGiftCardsCommand = new RelayCommand(() => ExecuteShowGiftCards());
        }

        private void ExecuteShowGiftCards()
        {
            Messenger.Default.Send(new ShowGiftCardMessage());
        }
    }
}
