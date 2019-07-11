using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gagan_Dog_Race
{
    public partial class Form1 : Form
    {
        //global variable for the game 
        int gagan_Amount = 50, harman_Amount = 50, gultaj_Amount = 50,winner=0;
        int player1 = 0, player2 = 0, player3 = 0;
        int dog1 = 0, dog2 = 0, dog3 = 0;
        int bet1_value = 0, bet2_value = 0, bet3_value = 0;

        private void Player2_Click(object sender, EventArgs e)
        {

        }

        private void Player3_Click(object sender, EventArgs e)
        {

        }

        private void lblPlayer1_Click(object sender, EventArgs e)
        {

        }

        private void nmAmount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbPlayer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbDog_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Player1_Click(object sender, EventArgs e)
        {

        }

        //random class object for the increment
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        // this event is used to start the timmer to start the race
        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // this is used to run the game
        private void timer1_Tick(object sender, EventArgs e)
        {
            //move the player of the game
            Player1.Left = Player1.Left + rnd.Next(1,20);
            Player2.Left = Player2.Left + rnd.Next(1, 20);
            Player3.Left = Player3.Left + rnd.Next(1, 20);


            if (Player1.Left>=788) {
                timer1.Stop();
                winner = 1;
                find_Winner();
                reset();
            }

            else if (Player2.Left >= 788)
            {
                winner = 2;
                timer1.Stop();
                find_Winner();
                reset();
            }

            else if (Player3.Left >= 788)
            {
                winner = 3;
                timer1.Stop();
                find_Winner();
                reset();
            }
        }
        /// this method is used to reset the whole game so the player can play again;
        public void reset() {
            player1 = 0;
            player2 = 0;
            player3 = 0;
            dog1 = 0;
            dog2 = 0;
            dog3 = 0;
            bet1_value = 0;
            bet2_value = 0;
            bet3_value = 0;
            winner = 0;
            btnPlay.Enabled = false;
            Player1.Left = 0;
            Player2.Left = 0;
            Player3.Left =0;
            lblPlayer1.Text = "First Player";
            lblPlayer2.Text = "Second Player";
            lblPlayer3.Text = "Third Player";

        }
        //this method is used to fetch the winner of the game 
        public void find_Winner() {
            if (player1 == 1)
            {
                ///remove the text and generate the new text
                cbPlayer.Items.RemoveAt(0);
                if (dog1==winner) {
                    // increment the bet amount
                    gagan_Amount = gagan_Amount+ bet1_value ;
                    cbPlayer.Items.Insert(0, "Gagan has "+ gagan_Amount +" dollar for the bet ");
                    MessageBox.Show("Congratulations you won the Bet ");
                }
                else {
                    // decrement the bet amount
                    gagan_Amount = gagan_Amount - bet1_value;
                    cbPlayer.Items.Insert(0, "Gagan has " + gagan_Amount + " dollar for the bet ");
                    MessageBox.Show("sorry you lose the Bet ");
                }
            }
            

            if (player2 == 1)
            {
                ///remove the text and generate the new text
                cbPlayer.Items.RemoveAt(1);
                if (dog2==winner) {
                    // increment the bet amount
                   harman_Amount = harman_Amount + bet2_value;
                    cbPlayer.Items.Insert(1, "Harman has " + harman_Amount + " dollar for the bet ");
                    MessageBox.Show("Congratulations you won the Bet ");
                }
                else {
                    // increment the bet amount
                    harman_Amount = harman_Amount - bet2_value;
                    cbPlayer.Items.Insert(1, "Harman has " + harman_Amount + " dollar for the bet ");
                    MessageBox.Show("sorry you lose the Bet ");

                }

            }

            if (player3==1) {
                ///remove the text and generate the new text
                cbPlayer.Items.RemoveAt(2);
                if (dog3==winner) {
                    // increment the bet amount
                    gultaj_Amount = gultaj_Amount + bet3_value;
                    cbPlayer.Items.Insert(2, "Gultaj has " + gultaj_Amount + " dollar for the bet ");
                    MessageBox.Show("Congratulations you won the Bet ");
                }
                else {
                    // increment the bet amount
                    gultaj_Amount = gultaj_Amount - bet3_value;
                    cbPlayer.Items.Insert(2, "Gultaj has " + gultaj_Amount + " dollar for the bet ");
                    MessageBox.Show("Sorry you lose the Bet ");
                }   
            }

        }

        // this is the post define method that is used to get the index of the selected player from the combo box and set the bet amount and display in the screen
        public void setBet(int id) {
            //get the index and check the condition and generate the message for the display

            if (id == 1 && gagan_Amount <= 50)
            {
                lblPlayer1.Text = nmAmount.Value + " Dollar Gagan set the bet at "+ cbDog.SelectedItem;
                btnPlay.Enabled = true;
                player1 = 1;
                dog1 = Convert.ToInt32(cbDog.SelectedItem);
                bet1_value =Convert.ToInt32( nmAmount.Value);
                

            }
            else if (id == 2 && harman_Amount <= 50)
            {
                lblPlayer2.Text = nmAmount.Value + " Dollar Harman set the bet at "+ cbDog.SelectedItem;
                btnPlay.Enabled = true;
                player2 = 1;
                dog2 = Convert.ToInt32(cbDog.SelectedItem);
                bet2_value = Convert.ToInt32(nmAmount.Value);
            }
            else if (id == 3 && gultaj_Amount <= 50)
            {
                lblPlayer3.Text = nmAmount.Value + " Dollar Gultaj set the Bet at "+ cbDog.SelectedItem;
                btnPlay.Enabled = true;
                player3 = 1;
                dog3 = Convert.ToInt32(cbDog.SelectedItem);
                bet3_value = Convert.ToInt32(nmAmount.Value);
            }
            else {
                MessageBox.Show("Sorry you don't have enough money for the bet");
            }
                
        }
        private void btnBet_Click(object sender, EventArgs e)
        {
            //calling the method for the bet   amount of the player 
            /// this  method is used to get the index from the combo box of  the player and pass to the user define method for the player so the method can get the index and generate the recuired label and display the message
            setBet(cbPlayer.SelectedIndex+1);
        }
    }
}
