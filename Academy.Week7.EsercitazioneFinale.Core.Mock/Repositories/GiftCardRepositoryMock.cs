using Academy.Week7.EsercitazioneFinale.Core.Entities;
using Academy.Week7.EsercitazioneFinale.Core.Interfaces;
using Academy.Week7.EsercitazioneFinale.Core.Mock.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week7.EsercitazioneFinale.Core.Mock.Repositories
{
    public class GiftCardRepositoryMock : IGiftCardRepository
    {
        public void Create(GiftCard card)
        {
            int newId = MockStorage.GiftCards.Max(x => x.Id) + 1;
            card.Id = newId;
            MockStorage.GiftCards.Add(card);
        }

        public void Delete(GiftCard card)
        {
            GiftCard giftCard = MockStorage.GiftCards.FirstOrDefault(x => x.Id == card.Id);
            MockStorage.GiftCards.Remove(giftCard);
        }

        public IList<GiftCard> FetchAll()
        {
            return MockStorage.GiftCards.OrderBy(d => d.DataDiScadenza).ToList();
        }

        public void Update(GiftCard updatedCard)
        {
            GiftCard existingCard = MockStorage.GiftCards.FirstOrDefault(x => x.Id == updatedCard.Id);
            MockStorage.GiftCards.Remove(existingCard);
            MockStorage.GiftCards.Add(updatedCard);
        }
    }
}
