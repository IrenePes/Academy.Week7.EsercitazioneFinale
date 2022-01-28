using Academy.Week7.EsercitazioneFinale.WPF.Messaging.GiftCard;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Academy.Week7.EsercitazioneFinale.WPF.Views
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateView : Window
    {
        public CreateView()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseCreateGiftCardMessage>(this, _ => Close());

            Closing += (s, e) =>
            {
                Messenger.Default.Unregister(this);
                Messenger.Default.Unregister(DataContext);
            };
        }
    }
}
