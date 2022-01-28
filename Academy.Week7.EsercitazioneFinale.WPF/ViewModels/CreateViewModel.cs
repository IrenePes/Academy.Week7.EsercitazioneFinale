using Academy.Week7.EsercitazioneFinale.Core.BusinessLayer;
using Academy.Week7.EsercitazioneFinale.Core.Entities;
using Academy.Week7.EsercitazioneFinale.Core.Mock.Repositories;
using Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCard;
using Academy.Week7.EsercitazioneFinale.WPF.Messaging.Misc;
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
    public class CreateViewModel : ViewModelBase
    {
        public ICommand CreateCommand { get; set; }

        private string _Mittente;
        public string Mittente
        {
            get { return _Mittente; }
            set
            {
                _Mittente = value;
                RaisePropertyChanged();
            }
        }

        private string _Destinatario;
        public string Destinatario
        {
            get { return _Destinatario; }
            set
            {
                _Destinatario = value;
                RaisePropertyChanged();
            }
        }

        private string _Messaggio;
        public string Messaggio
        {
            get { return _Messaggio; }
            set
            {
                _Messaggio = value;
                RaisePropertyChanged();
            }
        }

        private double _Importo;
        public double Importo
        {
            get { return _Importo; }
            set { _Importo = value; RaisePropertyChanged(); }
        }

        private DateTime _DataDiScadenza;
        public DateTime DataDiScadenza
        {
            get { return _DataDiScadenza; }
            set { _DataDiScadenza = value; RaisePropertyChanged(); }
        }

        public CreateViewModel()
        {
            CreateCommand = new RelayCommand(() => ExecuteCreate(), () => CanExecuteCreate());
            if (!IsInDesignMode)
            {
                PropertyChanged += (s, e) =>
                {
                    (CreateCommand as RelayCommand).RaiseCanExecuteChanged();
                };
            }
        }

        private bool CanExecuteCreate()
        {
            return !string.IsNullOrEmpty(Mittente) &&
                !string.IsNullOrEmpty(Destinatario) &&
                !string.IsNullOrEmpty(Messaggio) &&
                !string.IsNullOrEmpty(Importo.ToString()) &&
                !string.IsNullOrEmpty(DataDiScadenza.ToString());
        }

        private void ExecuteCreate()
        {
            var entity = new GiftCard
            {
                Mittente = Mittente,
                Destinatario = Destinatario,
                Messaggio = Messaggio,
                Importo = Importo,
                DataDiScadenza = DataDiScadenza

            };

            var mainBL = new MainBusinessLayer(new GiftCardRepositoryMock());
            var response = mainBL.CreateGiftCard(entity);
        
            if(response.Successo == false)
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Qualcosa è andato storto ...",
                    Content = response.Messaggio,
                    Icon = System.Windows.MessageBoxImage.Warning
                });
                return;
            }

            else
            {
                Messenger.Default.Send(new DialogMessage
                {
                    Title = "Creazione completata",
                    Content = response.Messaggio,
                    Icon=System.Windows.MessageBoxImage.Information
                });
            }
            Messenger.Default.Send(new CloseCreateGiftCardMessage());

        }
    }
}
