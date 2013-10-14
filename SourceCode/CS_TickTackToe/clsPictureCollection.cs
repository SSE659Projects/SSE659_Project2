// clsPictureCollection.cs - Class that contains methods for adding and removing
// square pictures on the Tic Tac Toe board, determine the actions of a square
// selection, evaluate the game's status, and clear the Tic Tac Toe board.
//
using System;
using System.Windows.Forms;

namespace CS_TickTackToe
{
	// Function that inherits from the Collection base class to add functionality
	// to this class.
	public class clsPictureCollection : System.Collections.CollectionBase
	{
		private clsGameplay clsGame;
		private PictureBox picX;
		private readonly Form frmHost;

		public StatusBar sbStatus;
        public int intPlayerScore = 0;
        public int intComputerOpponentScore = 0;

        // Function used as the constructor
		public clsPictureCollection(Form frmSetHost, clsGameplay clsCurrentGame,
			PictureBox picXHolder)
		{
			frmHost = frmSetHost;
			clsGame = clsCurrentGame;
			picX = picXHolder;
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

        // Function that removes the last Picturebox added to the array from the host form 
        // controls collection.
		public void RemovePicturebox()
		{
			if (this.Count > 0)
			{
				frmHost.Controls.Remove(this[this.Count -1]);
				this.List.RemoveAt(this.Count -1);
			}
		}

        // Function used for the actions of the square selections on the Tic Tac Toe board
        // and evaluates the status of the game
		public void Picture_Click(Object sender, System.EventArgs e)
		{
			PictureBox picBox = (PictureBox) sender;
			if (clsGame.bytCurrentPlayer == 1)
			{
				if (picBox.Image == null)
				{
					picBox.Image = picX.Image;
					string strDim = picBox.Name.Substring(3);
					clsGame.SetBoardPosition(1, Convert.ToInt32(strDim.Substring(0, 1)) - 1,
						Convert.ToInt32(strDim.Substring(1)) - 1);
				}
				else
				{
					return; // Exit prematurely as a result of a claimed block
				}

                CheckGameStatus();

				//Computer opponent's turn in the game
				clsGame.bytCurrentPlayer = 2;
				sbStatus.Panels[0].Text = "Computer's Move";
				clsGame.ComputerMoveAI();
				sbStatus.Panels[0].Text = "Your Move";

                CheckGameStatus();
			}
		}

        // Function for checking the status of the game
        public void CheckGameStatus()
        {
            if (clsGame.bytWinType == 1) // Check if the Player won the game
            {
                intPlayerScore++;
                sbStatus.Panels[1].Text = "You: " + intPlayerScore.ToString()
                    + " Computer: " + intComputerOpponentScore.ToString();
                MessageBox.Show("You won!");
                clsGame.NewGame();
            }
            else if (clsGame.bytWinType == 2) // Check if the Computer Opponent won the game
            {
                intComputerOpponentScore++;
                sbStatus.Panels[1].Text = "You: " + intPlayerScore.ToString()
                    + " Computer: " + intComputerOpponentScore.ToString();
                MessageBox.Show("You lost.");
                clsGame.NewGame();
            }
            else if (clsGame.CheckForTie() == true) // Check if the game is a tie
            {
                MessageBox.Show("The game resulted in a tie.");
                clsGame.NewGame();
            }
        }

        // Function used to clear the squares on the Tic Tac Toe board
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
