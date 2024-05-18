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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (Card card in blackJack.GetPlayerHand())
            {
                PlayerHand.Children.Add(card);

            }
            foreach (Card card in blackJack.GetHouseHand())
            {
                HouseHand.Children.Add(card);

            }
            UpdateValue();


        }

        public void UpdateValue()
        {
            PlayerValue.Text = $"Hand Value: {blackJack.handValue(blackJack.GetPlayerHand())}";
            HouseValue.Text = $"Hand Value: {blackJack.handValue(blackJack.GetHouseHand())}";
        }







        //Event listeners below:
        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            Card playercard = blackJack.hit();
            PlayerHand.Children.Add(playercard);

            Card housecard = blackJack.houseTurn();
            if ( housecard != null)
            {
                HouseHand.Children.Add(housecard);
            }
            UpdateValue();


            if (blackJack.checkGameState() == false) 
            {
                GameEndUI.Visibility = Visibility.Visible;
                GameEndResult.Text = blackJack.getresult();
                foreach (Card card in HouseHand.Children) // make this a function christ
                {
                    if (card.Name == "Hidden")
                    {
                        if (card.Hidden == true)
                        {
                            card.Hidden = false;
                        }
                        else
                        {
                            card.Hidden = true;
                        }

                    }
                }
            }
        }
        

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            blackJack.PlayerFold();
        }
        
        private BlackJack blackJack = new BlackJack();
    }
}
