// clsPictureCollection.cs - Class that contains methods for adding and removing
// square pictures on the Tic Tac Toe board, determine the actions of a square
// selection, evaluate the game's status, and clear the Tic Tac Toe board.
using System;
using System.Windows.Forms;

namespace CS_TickTackToe
{
	//Inherits from the Collection base class to add functionality
	//to this class.
	public class clsPictureCollection : System.Collections.CollectionBase
	{
		private clsGameplay clsGame;
		private PictureBox picX;
		private readonly Form frmHost;
		public StatusBar sbStatus;

        private int m_HumanScore = 0;
        private int m_ComputerScore = 0;
		
        // Function used as the clsPictureCollection constructor
		public clsPictureCollection(Form frmSetHost, clsGameplay clsCurrentGame,
			PictureBox picXHolder)
		{
			frmHost = frmSetHost;
			clsGame = clsCurrentGame;
			picX = picXHolder;
		}

        public int HumanScore
        {
            set { m_HumanScore = value; }
            get { return m_HumanScore; }
        }

        public int ComputerScore
        {
            set { m_ComputerScore = value; }
            get { return m_ComputerScore; }
        }
        
		// Function used as the get method for the PictureBox
		public PictureBox this [int Index]
		{
			get
			{
				return (PictureBox) this.List[Index];
			}
		}

        // Function used to add the squares to the Tic Tac Toe board
		public void AddPicture(PictureBox picBox)
		{
			this.List.Add(picBox);
			picBox.Click += new System.EventHandler(Picture_Click);
		}

        // Function that removes the last Picturebox added to the array from 
        // host form controls collection
		public void RemovePicturebox()
		{
			if (this.Count > 0)
			{
				frmHost.Controls.Remove(this[this.Count -1]);
				this.List.RemoveAt(this.Count -1);
			}
		}

        // Function used for the actions of the square selections on the Tic 
        // Tac Toe board and evaluates the status of the game
		public void Picture_Click(Object sender, System.EventArgs e)
		{
			PictureBox picBox = (PictureBox) sender;
            if (clsGame.Player == clsGameplay.EPlayer.E_HUMAN)
			{
				if (picBox.Image == null)
				{
					picBox.Image = picX.Image;
					string strDim = picBox.Name.Substring(3);
                    clsGame.SetBoardPosition(clsGameplay.EPlayer.E_HUMAN, Convert.ToInt32(strDim.Substring(0, 1)),
						Convert.ToInt32(strDim.Substring(1)));
				}
				else
				{
					// Exit prematurely as a result of a claimed block
					return;
				}

				//Check the status of the game winner/tie/still going
				//this is done twice to make it as optimal as possible!
                CheckGameStatus();

				//Computer's turn for board move
                clsGame.Player = clsGameplay.EPlayer.E_COMPUTER;
				sbStatus.Panels[0].Text = "Computer's Move";
                clsGame.ComputerMoveAI();
                clsGame.Player = clsGameplay.EPlayer.E_HUMAN;
				sbStatus.Panels[0].Text = "Your Move";

				//Check the status of the game winner/tie/still going
				//this is done twice to make it as optimal as possible!
                CheckGameStatus();
			}
		}

        private void CheckGameStatus()
        {
            if (clsGame.GameWinner == clsGameplay.EPlayer.E_HUMAN)
            {
                HumanScore++;
                sbStatus.Panels[1].Text = "You: " + HumanScore.ToString()
                    + " Computer: " + ComputerScore.ToString();
                MessageBox.Show("You won!");
                clsGame.NewGame();
            }
            else if (clsGame.GameWinner == clsGameplay.EPlayer.E_COMPUTER)
            {
                ComputerScore++;
                sbStatus.Panels[1].Text = "You: " + HumanScore.ToString()
                    + " Computer: " + ComputerScore.ToString();
                MessageBox.Show("You lost.");
                clsGame.NewGame();
            }
            else if (clsGame.CheckForTie() == true)
            {
                MessageBox.Show("The game resulted in a tie.");
                clsGame.NewGame();
            }
        }

		public void Clear_Pictures()
		{
			for (int i = 0; i < this.List.Count; i++)
			{
				PictureBox picBox = (PictureBox) this.List[i];
				picBox.Image = null;
			}
		}
	}
}
