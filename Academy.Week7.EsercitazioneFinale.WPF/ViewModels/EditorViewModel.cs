using Academy.Week7.EsercitazioneFinale.Core.BusinessLayer;
using Academy.Week7.EsercitazioneFinale.Core.Interfaces;
using Academy.Week7.EsercitazioneFinale.Core.Mock.Repositories;
using Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCard;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Academy.Week7.EsercitazioneFinale.WPF.ViewModels
{
    public class EditorViewModel : ViewModelBase
    {
        public ICommand CreateGiftCardCommand { get; set; }

        public ObservableCollection<GiftCardRowViewModel> _GiftCardSource;
        private ICollectionView _GiftCards;
        public ICollectionView GiftCards
        {
            get { return _GiftCards; }
            set { _GiftCards = value; RaisePropertyChanged(); }
        }

        public ICommand LoadGiftCardCommand { get; set; }
        public EditorViewModel()
        {
            CreateGiftCardCommand = new RelayCommand(() => ExecuteShowCreateGiftCard());
            LoadGiftCardCommand = new RelayCommand(() => ExecuteLoadGiftCard());

            _GiftCardSource = new ObservableCollection<GiftCardRowViewModel>();
            _GiftCards = new CollectionView(_GiftCardSource);

            LoadGiftCardCommand.Execute(null);
        }

        private void ExecuteLoadGiftCard()
        {
            IGiftCardRepository repo = new GiftCardRepositoryMock();
            MainBusinessLayer mainBL = new MainBusinessLayer(repo);

            var giftcards = mainBL.FetchAllGiftCards();

            _GiftCardSource.Clear();

            foreach(var giftcard in giftcards)
            {
                var vmGiftCardRow = new GiftCardRowViewModel(giftcard);
                _GiftCardSource.Add(vmGiftCardRow);

            }
        }

        private void ExecuteShowCreateGiftCard()
        {
            Messenger.Default.Send(new ShowCreateGiftCardMessage());
        }

        private bool _IsChecked = true;
        public bool IsChecked
        {
            get { return _IsChecked; }
            set { _IsChecked = value; RaisePropertyChanged(); }
        }
    }
}
