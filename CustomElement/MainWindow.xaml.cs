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
            
            StartGame();

        }

        public void StartGame()
        {
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

        public async Task Turn()
        {
            await flipHiddenCard();
            while (!blackJack.housefold)
            {

                Card housecard = blackJack.houseTurn();
                if (housecard != null)
                {
                    HouseHand.Children.Add(housecard);
                    UpdateValue();
                    await Task.Delay(1000);
                }


            }


            CheckIfEnd();

            
            
        }

        public async Task flipHiddenCard()
        {
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
            await Task.Delay(1000);
        }

        public void CheckIfEnd()
        {
            
            if (blackJack.checkGameState() == false)
            {

                GameEndUI.Visibility = Visibility.Visible;
                GameEndResult.Text = blackJack.getresult();
            }
        }

        public void RestartGame()
        {
            blackJack = new BlackJack();

            PlayerHand.Children.Clear();
            HouseHand.Children.Clear();

            GameEndUI.Visibility = Visibility.Hidden;

            StartGame();


        }



        //Event listeners below:
        private void AddCardButton_Click(object sender, RoutedEventArgs e)
        {
            if (blackJack.playerfold == true)
            {
                return;
            }

            Card playercard = blackJack.hit();
            PlayerHand.Children.Add(playercard);
            UpdateValue();
            if (blackJack.handValue(blackJack.GetPlayerHand()) > 21)
            {
                MessageBox.Show("Auto fold!");
                blackJack.PlayerFold();
                Turn();
            }
            return;
        }
        
        

        private void StandButton_Click(object sender, RoutedEventArgs e)
        {
            blackJack.PlayerFold();
            Turn();
        }
        
        private BlackJack blackJack = new BlackJack();

        private void ReplayButton_Click(object sender, RoutedEventArgs e)
        {
            RestartGame();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
