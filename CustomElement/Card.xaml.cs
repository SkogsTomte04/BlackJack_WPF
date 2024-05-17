using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomElement
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>

    public partial class Card : UserControl
    {
        public enum CardSuits
        {
            CLUBS,
            HEARTS,
            DIAMONDS,
            SPADES
        }


        public Card()
        {
            InitializeComponent();
            SetSuit();
        }


        public void SetSuit()
        {
            List<Path> list = new List<Path>();
            list.Add(TopSymbol);
            list.Add(BottomSymbol);
            list.Add(CenterSymbol);
        }
        public string ConvertData(string data)
        {
            return data.Replace('.', ',');
        }



        public CardSuits cardSuits
        {
            get { return (CardSuits)GetValue(cardSuitsProperty); }
            set { SetValue(cardSuitsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cardSuits.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty cardSuitsProperty =
            DependencyProperty.Register("cardSuits", typeof(CardSuits), typeof(UserControl), new PropertyMetadata(null));



        public char CardValue
        {
            get { return (char)GetValue(CardValueProperty); }
            set { SetValue(CardValueProperty, value); }
        }

        public static readonly DependencyProperty CardValueProperty = DependencyProperty.Register("CardValue", typeof(char), typeof(Card), new PropertyMetadata(null));



        public string Symbol
        {
            get { return (string)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value);  }
        }
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));

        private readonly string 
            Clubs = "M7 .25a3.036 3.036 0 0 0-3.036 3.036c0 .56.152 1.186.412 1.771a4.029 4.029 0 0 0-1.09-.164a3.036 3.036 0 0 0 0 6.071c.622 0 1.328-.187 1.967-.504l-.606 2.99a.25.25 0 0 0 .245.3h4.216a.25.25 0 0 0 .245-.3l-.606-2.99c.639.317 1.345.504 1.967.504a3.036 3.036 0 0 0 0-6.071c-.347 0-.72.058-1.09.164c.26-.585.412-1.212.412-1.771A3.036 3.036 0 0 0 7 .25",
            Hearts = "M3.788 1.314c.988.02 2.085.49 3.214 1.56c1.127-1.067 2.223-1.536 3.21-1.555c1.04-.02 1.918.46 2.536 1.18c1.218 1.42 1.47 3.85-.058 5.377l-.001.001l-4.247 4.208c-.81.802-2.07.802-2.88 0L1.316 7.877C-.217 6.343.032 3.913 1.25 2.491c.617-.72 1.495-1.2 2.537-1.178Z",
            Diamonds = "M12 2.005c-.777 0-1.508.367-1.971.99L4.667 9.89c-.89 1.136-.89 3.083 0 4.227l5.375 6.911a2.457 2.457 0 0 0 3.93-.017l5.361-6.894c.89-1.136.89-3.083 0-4.227l-5.375-6.911A2.45 2.45 0 0 0 12 2.005",
            Spades = "M8.436.814a2.105 2.105 0 0 0-2.868 0L1.321 4.767C-.057 6.062-.002 8.039.895 9.397c.452.683 1.123 1.224 1.952 1.452c.706.194 1.51.156 2.366-.194l-.567 2.796a.25.25 0 0 0 .245.3h4.216a.25.25 0 0 0 .245-.3l-.568-2.8c.855.35 1.658.387 2.364.193c.829-.228 1.5-.77 1.952-1.452c.898-1.357.957-3.333-.417-4.623v-.001z";


    }
}
