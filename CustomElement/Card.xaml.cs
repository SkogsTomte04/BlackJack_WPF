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
        


        protected override void OnInitialized(EventArgs e)
        {
            InitializeComponent();
            base.OnInitialized(e);
            SetSuit();
        }
        

        public void SetPath(string data, List<Path> paths)
        {
            foreach (var path in paths)
            {
                path.Data = Geometry.Parse(data);
            }
        }
        public void SetSuit()
        {
            List<Path> list = new List<Path>();
            list.Add(TopSymbol);
            list.Add(BottomSymbol);
            list.Add(CenterSymbol);

            switch (cardSuits)
            {
                case CardSuits.CLUBS:
                    {
                        SetPath(Clubs, list);
                        break;
                    }
                case CardSuits.HEARTS:
                    {
                        SetPath(Hearts, list);
                        break;
                    }
                case CardSuits.DIAMONDS:
                    {
                        SetPath(Diamonds, list);
                        break;
                    }
                case CardSuits.SPADES:
                    {
                        SetPath(Spades, list);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("deff");
                        break;
                    }

            }
            
        }

        private void mouseLeave(object sender, MouseEventArgs e)
        {
            MainGrid.Background = Brushes.AliceBlue;
        }
        private void mouseEnter(object sender, MouseEventArgs e)
        {
            MainGrid.Background = Brushes.Blue;
        }
        public CardSuits cardSuits
        {
            get { return (CardSuits)GetValue(cardSuitsProperty); }
            set { SetValue(cardSuitsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cardSuits.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty cardSuitsProperty =
            DependencyProperty.Register("cardSuits", typeof(CardSuits), typeof(UserControl), new PropertyMetadata(null));



        public bool Hidden
        {
            get { return (bool)GetValue(HiddenProperty); }
            set { SetValue(HiddenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hidden.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HiddenProperty =
            DependencyProperty.Register("Hidden", typeof(bool), typeof(Card), new PropertyMetadata(false));



        public string CardValue
        {
            get { return (string)GetValue(CardValueProperty); }
            set { SetValue(CardValueProperty, value); }
        }

        public static readonly DependencyProperty CardValueProperty = DependencyProperty.Register("CardValue", typeof(string), typeof(Card), new PropertyMetadata(null));

        private readonly string 
            Clubs = "M7,0.25A3.036,3.036,0,0,0,3.964,3.286C3.964,3.8459999999999996,4.116,4.4719999999999995,4.3759999999999994,5.0569999999999995A4.029,4.029,0,0,0,3.2860000000000005,4.893000000000001A3.036,3.036,0,0,0,3.2860000000000005,10.963999999999999C3.9080000000000004,10.963999999999999,4.614000000000001,10.777000000000001,5.253,10.459999999999999L4.646999999999999,13.450000000000001A0.25,0.25,0,0,0,4.8919999999999995,13.750000000000002L9.107999999999999,13.750000000000002A0.25,0.25,0,0,0,9.353,13.450000000000001L8.747,10.459999999999999C9.386,10.777000000000001,10.091999999999999,10.963999999999999,10.713999999999999,10.963999999999999A3.036,3.036,0,0,0,10.713999999999999,4.893000000000001C10.366999999999999,4.893000000000001 9.994,4.9510000000000005 9.623999999999999,5.0569999999999995 9.884,4.4719999999999995 10.036000000000001,3.8450000000000006 10.036000000000001,3.2860000000000005A3.036,3.036,0,0,0,7,0.25\r\n",
            Hearts = "M3.788,1.3139999999999998C4.776,1.3339999999999999 5.872999999999999,1.8039999999999998 7.002,2.8739999999999997 8.129,1.8070000000000002 9.225,1.3379999999999999 10.212,1.3190000000000002 11.251999999999999,1.2990000000000002 12.129999999999999,1.7790000000000001 12.748,2.4989999999999997 13.966,3.919 14.218,6.348999999999999 12.69,7.8759999999999994L12.689,7.877 8.442,12.084999999999999C7.632,12.886999999999999,6.372,12.886999999999999,5.561999999999999,12.084999999999999L1.3159999999999998,7.877C-0.217,6.343 0.032,3.913 1.25,2.491 1.867,1.7710000000000001 2.7449999999999997,1.2910000000000001 3.787,1.3130000000000002z\r\n",
            Diamonds = "M12,2.005C11.222999999999999,2.005,10.491999999999999,2.372,10.029,2.9949999999999997L4.667,9.889999999999999C3.7769999999999997,11.026,3.7769999999999997,12.972999999999999,4.667,14.116999999999999L10.042,21.028A2.457,2.457,0,0,0,13.972,21.011L19.333,14.116999999999999C20.223,12.981,20.223,11.033999999999999,19.333,9.889999999999999L13.957999999999998,2.978999999999999A2.4499999999999997,2.4499999999999997,0,0,0,12,2.005\r\n",
            Spades = "M8.436,0.814A2.105,2.105,0,0,0,5.568,0.814L1.321,4.7669999999999995C-0.056999999999999995,6.061999999999999 -0.002,8.039 0.8949999999999999,9.397 1.347,10.08 2.018,10.620999999999999 2.847,10.849 3.553,11.043000000000001 4.357,11.004999999999999 5.213,10.655L4.646,13.450999999999999A0.25,0.25,0,0,0,4.891,13.751L9.107,13.751A0.25,0.25,0,0,0,9.351999999999999,13.450999999999999L8.783999999999999,10.651C9.639,11.001 10.441999999999998,11.038 11.148,10.844 11.977,10.616 12.648,10.074 13.1,9.392 13.998,8.035 14.056999999999999,6.058999999999999 12.683,4.768999999999999L12.683,4.767999999999999z\r\n";


    }
}
