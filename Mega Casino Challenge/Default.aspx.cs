using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mega_Casino_Challenge
{
    public partial class Default : System.Web.UI.Page
    {
        Random random = new Random();

        string reel1Image = "";
        string reel2Image = "";
        string reel3Image = "";

        int cherryCount = 0;
        int sevenCount = 0;
        int playerWinnings = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState.Add("Current Wallet", 100);
                moneyLabel.Text = String.Format("{0:C}", 100);
                spinReels();
            }
        }

        private void spinReels()
        {
            reel1Image = getRandomPic();
            reel2Image = getRandomPic();
            reel3Image = getRandomPic();
            reel1.ImageUrl = "./Images/" + reel1Image + ".png";
            reel2.ImageUrl = "./Images/" + reel2Image + ".png";
            reel3.ImageUrl = "./Images/" + reel3Image + ".png";
        }

        private string getRandomPic()
        {
            string[] imageArray = new string[] { "Strawberry", "Bar", "Lemon","Bell", "Clover",
                "Cherry", "Diamond", "Orange", "Seven", "HorseShoe", "Plum", "Watermelon" };
            return imageArray[random.Next(11)];
        }

        protected void leverButton_Click(object sender, EventArgs e)
        {
            spinReels();
            updateWallet(determineWinnings());
            if (checkWinState())
            {
                playerWon();
            }
            else
                playerLost();
        }        

        private int determineWinnings()
        {
            if ((countCherries(createReelArray())) > 0 && (!checkForBars(createReelArray())))
            {
                playerWinnings = (countCherries(createReelArray()) + 1) * int.Parse(playerBetTextBox.Text);
            }
            if (countSevens(createReelArray()) == 3)
            {
                playerWinnings = 100 * int.Parse(playerBetTextBox.Text);
            }
            return playerWinnings;
        }

        private void updateWallet(int playerWinnings)
        {
            int currentWallet = Convert.ToInt32(ViewState["Current Wallet"]);
            currentWallet -= int.Parse(playerBetTextBox.Text);
            currentWallet += playerWinnings;
            moneyLabel.Text = String.Format("{0:C}", currentWallet);
            ViewState["Current Wallet"] = currentWallet;
        }

        private bool checkWinState()
        {
            if (checkForBars(createReelArray()))
            {
                return false;
            }

            else if (((countCherries(createReelArray()) > 0) | (countSevens(createReelArray()) == 3)))
            {
                return true;
            }
            else
                return false;
        }

        private void playerWon()
        {
            resultLabel.Text = string.Format("You bet {0:C} and won {1:C}. ", int.Parse(playerBetTextBox.Text), playerWinnings);
        }

        private void playerLost()
        {
            resultLabel.Text = string.Format("Sorry, you lost {0:C}. Better luck next time!", int.Parse(playerBetTextBox.Text));
        }        

        private string[] createReelArray()
        {
            string[] reelArray = new string[] { reel1Image, reel2Image, reel3Image };
            return reelArray;     
        }

        private int countSevens(string[] reelArray)
        {
            for (int i = 0; i < reelArray.Length; i++)
            {
                sevenCount = 0;
                if (reelArray[i] == "Seven")
                {
                    sevenCount++;
                }
            }
            return sevenCount;
        }

        private bool checkForBars(string[] reelArray)
        {
            
                for (int i = 0; i < reelArray.Length; i++)
                    if (reelArray[i] == "Bar")
                {
                    return true;
                }
            return false;
        }

        private int countCherries(string[] reelArray)
        {
            cherryCount = 0;
            for (int i = 0; i < reelArray.Length; i++)
            {
                if (reelArray[i] == "Cherry")
                {
                    cherryCount++;
                }
            }
            return cherryCount;
        }
    }
}