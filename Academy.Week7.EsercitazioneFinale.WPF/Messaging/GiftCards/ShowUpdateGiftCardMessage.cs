using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Week7.EsercitazioneFinale.Core.Entities;

namespace Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCards
{
    public class ShowUpdateGiftCardMessage
    {
        public Academy.Week7.EsercitazioneFinale.Core.Entities.GiftCard SelectedGiftCard { get; set; }
    }
}
