using Academy.Week7.EsercitazioneFinale.Core.BusinessLayer;
using Academy.Week7.EsercitazioneFinale.Core.Entities;
using Academy.Week7.EsercitazioneFinale.Core.Mock.Repositories;
using Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCards;
using Academy.Week7.EsercitazioneFinale.WPF.Messaging.Misc;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Academy.Week7.EsercitazioneFinale.WPF.ViewModels
{
    public class GiftCardRowViewModel : ViewModelBase
    {
        private GiftCard item;

        private string _Destinatario;
        public string Destinatario
        {
            get { return _Destinatario; }
            set { _Destinatario = value; RaisePropertyChanged(); }
        }

        private double _Importo;
        public double Importo
        {
            get { return _Importo; }
            set { _Importo = value; RaisePropertyChanged(); }
        }

        public ICommand UpdateCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public GiftCardRowViewModel()
        {
            UpdateCommand = new RelayCommand(() => ExecuteUpdateCommand());
            DeleteCommand = new RelayCommand(() => ExecuteDeleteCommand());
        }

        public GiftCardRowViewModel(GiftCard item) : this()
        {
            this.item = item;
            Destinatario = item.Destinatario;
            Importo = item.Importo;
        }

        private void ExecuteDeleteCommand()
        {
            Messenger.Default.Send(new DialogMessage
            {
                Title = "Conferma cancellazione",
                Content = "Sei sicuro di voler procedere?",
                Icon = System.Windows.MessageBoxImage.Question,
                Buttons = System.Windows.MessageBoxButton.YesNo,
                Callback = OnMessageBoxResultReceived
            });
        }

        private void OnMessageBoxResultReceived(MessageBoxResult result)
        {
            if(result == MessageBoxResult.Yes)
            {
                var mainBL = new MainBusinessLayer(new GiftCardRepositoryMock());
                var response = mainBL.DeleteGiftCard(item);

                if(response.Successo == false)
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Errore",
                        Content = response.Messaggio,
                        Icon = System.Windows.MessageBoxImage.Error,
                        Buttons = MessageBoxButton.OK
                    });
                    return;
                }
                else
                {
                    Messenger.Default.Send(new DialogMessage
                    {
                        Title = "Cancellazione confermata",
                        Content = response.Messaggio,
                        Icon= System.Windows.MessageBoxImage.Information
                    });
                }
            }
        }

        private void ExecuteUpdateCommand()
        {
            Messenger.Default.Send(new ShowUpdateGiftCardMessage { SelectedGiftCard = item});
        }
    }
}
