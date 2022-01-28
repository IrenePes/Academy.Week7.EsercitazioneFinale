using Academy.Week7.EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week7.EsercitazioneFinale.Core.Mock.Storage
{
    public class MockStorage
    {
        public static IList<GiftCard> GiftCards { get; set; }

        public static void Initialize()
        {
            GiftCards = new List<GiftCard>();

            GiftCards.Add(new GiftCard
            {
                Id = 1,
                Mittente = "Irene Pescatori",
                Destinatario = "Roberto Bolle",
                Messaggio = "Buon anno nuovo!",
                Importo = 80,
                DataDiScadenza = new DateTime(2022, 12, 29)

            });

            GiftCards.Add(new GiftCard
            {
                Id = 2,
                Mittente = "Irene Pescatori",
                Destinatario = "Luciano Ligabue",
                Messaggio = "Grazie di esistere!",
                Importo = 500,
                DataDiScadenza = new DateTime(2021, 1, 15)

            });

            GiftCards.Add(new GiftCard
            {
                Id = 3,
                Mittente = "Irene Pescatori",
                Destinatario = "Stefano Guerrera",
                Messaggio = "Auguri di pronta guarigione!",
                Importo = 50,
                DataDiScadenza = new DateTime(2022, 2, 10)

            });

            GiftCards.Add(new GiftCard
            {
                Id = 4,
                Mittente = "Irene Pescatori",
                Destinatario = "Antonino Canavacciuolo",
                Messaggio = "Grazie della cena!",
                Importo = 200,
                DataDiScadenza = new DateTime(2022, 9, 18)

            });

        }
    }
}
