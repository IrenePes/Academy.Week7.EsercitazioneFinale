using Academy.Week7.EsercitazioneFinale.Core.BusinessLayer;
using Academy.Week7.EsercitazioneFinale.Core.Entities;
using Academy.Week7.EsercitazioneFinale.Core.Interfaces;
using Academy.Week7.EsercitazioneFinale.Core.Mock.Repositories;
using Academy.Week7.EsercitazioneFinale.Core.Mock.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace Academy.Week7.EsercitazioneFinale.WPF.Tests
{
    public class GiftCardTests
    {
        [Fact]
        public void ShouldCreateGiftCardReturnsIncrementedElements()
        {
            //*** ARRANGE

            GiftCard giftCard = new GiftCard
            {
                Mittente = "Irene Pescatori",
                Destinatario = "Gianluca Pescatori",
                Messaggio = "Buona festa del papa'",
                Importo = 100,
                DataDiScadenza = new DateTime(2022, 12, 29)
            };

            MockStorage.Initialize();

            IGiftCardRepository giftCardRepo = new GiftCardRepositoryMock();
            MainBusinessLayer layer = new MainBusinessLayer(giftCardRepo);

            
            int countBefore = MockStorage.GiftCards.Count;

            //*** ACT

            var response = layer.CreateGiftCard(giftCard);

            //*** ASSERT

            int countAfter = MockStorage.GiftCards.Count;
            Assert.Equal(countBefore + 1, countAfter);
        }

    }
}