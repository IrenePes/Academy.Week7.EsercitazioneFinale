using Academy.Week7.EsercitazioneFinale.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Week7.EsercitazioneFinale.Core.Interfaces
{
    public interface IGiftCardRepository
    {
        IList<GiftCard> FetchAll();
        void Create(GiftCard card);
        void Update(GiftCard card);
        void Delete(GiftCard card);
    }
}
