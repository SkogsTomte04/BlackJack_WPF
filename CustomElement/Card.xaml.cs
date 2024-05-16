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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomElement
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>

    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }


        public char CardValue
        {
            get { return (char)GetValue(CardValueProperty); }
            set { SetValue(CardValueProperty, value); }
        }

        public static readonly DependencyProperty CardValueProperty = DependencyProperty.Register("CardValue", typeof(char), typeof(Card), new PropertyMetadata(null));



        public string Symbol
        {
            get { return (string)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(string), typeof(Card), new PropertyMetadata(string.Empty));


    }
}
