using Academy.Week7.EsercitazioneFinale.Core.Entities;
using Academy.Week7.EsercitazioneFinale.Core.Interfaces;
using Academy.Week7.EsercitazioneFinale.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week7.EsercitazioneFinale.Core.BusinessLayer
{
    public class MainBusinessLayer
    {
        private IGiftCardRepository _giftCardRepo;

        public MainBusinessLayer(IGiftCardRepository giftCardRepo)
        {
            _giftCardRepo = giftCardRepo;
        }

        public IList<GiftCard> FetchAllGiftCards()
        {
            return _giftCardRepo.FetchAll();
        }

        public Response CreateGiftCard(GiftCard giftCard)
        {
            if(giftCard == null)
                return new Response { Successo = false, Messaggio = "Entità non valida"};
            if (giftCard.Importo < 0.0)
                return new Response { Successo = false, Messaggio = "L'importo della GiftCard deve essere positivo" };
            if (giftCard.DataDiScadenza < DateTime.Now)
                return new Response { Successo = false, Messaggio = "La data di scadenza deve essere successiva alla data odierna" };

            _giftCardRepo.Create(giftCard);
            return new Response { Successo = true, Messaggio = "Nuova GiftCard inserita correttamente" };

        }

        public Response DeleteGiftCard(GiftCard giftCard)
        {
            if (giftCard == null)
                return new Response { Successo = false, Messaggio = "Entità non valida" };
            var giftCardToDelete = FetchAllGiftCards().FirstOrDefault(g => g.Id == giftCard.Id);
            if (giftCardToDelete == null)
                return new Response { Successo = false, Messaggio = $"Non esiste GiftCard con ID = {giftCard.Id}"};
            _giftCardRepo.Delete(giftCardToDelete);
            return new Response { Successo = true, Messaggio = $"GiftCard con ID = {giftCard.Id} rimossa correttamente" };

        }

        public Response UpdateGiftCard(GiftCard giftCard)
        {
            if (giftCard == null)
                return new Response { Successo = false, Messaggio = "Entità non valida" };
            var giftCardToUpdate = FetchAllGiftCards().FirstOrDefault(g => g.Id == giftCard.Id);
            if (giftCardToUpdate == null)
                return new Response { Successo = false, Messaggio = $"Non esiste GiftCard con ID = {giftCard.Id}" };
            _giftCardRepo.Update(giftCardToUpdate);
            return new Response { Successo = true, Messaggio = $"GiftCard con ID = {giftCard.Id} modificata correttamente" };
        }
    }
}
