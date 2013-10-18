using System;
using System.Windows.Forms;

namespace CS_TickTackToe
{
	/// <summary>
	/// Summary description for clsPictureCollection.
	/// </summary>
	//Inheret from the Collection base class to add functionality
	//to this class.
	public class clsPictureCollection : System.Collections.CollectionBase
	{
		private clsGameplay clsGame;
		private PictureBox picX;
		private readonly Form frmHost;

		public StatusBar sbStatus;

		public clsPictureCollection(Form frmSetHost, clsGameplay clsCurrentGame,
			PictureBox picXHolder)
		{
			//Hook this class up with all the information it
			//it needs to play the game!
			frmHost = frmSetHost;
			clsGame = clsCurrentGame;
			picX = picXHolder;
		}

		public PictureBox this [int Index]
		{
			get
			{
				return (PictureBox) this.List[Index];
			}
		}

		public void AddPicture(PictureBox picBox)
		{
			this.List.Add(picBox);
			picBox.Click += new System.EventHandler(Picture_Click);
		}

		public void RemovePicturebox()
		{
			if (this.Count > 0)
			{
				// Remove the last Picturebox added to the array from the host form 
				// controls collection.
				frmHost.Controls.Remove(this[this.Count -1]);
				this.List.RemoveAt(this.Count -1);
			}
		}

		public void Picture_Click(Object sender, System.EventArgs e)
		{
			PictureBox picBox = (PictureBox) sender;
			if (clsGame.bytCurrentPlayer == clsGameplay.HumansTurn)
			{
				if (picBox.Image == null)
				{
					picBox.Image = picX.Image;
					string strDim = picBox.Name.Substring(3);
					clsGame.SetPosition(1, Convert.ToInt32(strDim.Substring(0, 1)) - 1,
						Convert.ToInt32(strDim.Substring(1)) - 1);
				}
				else
				{
					//Exit premeturly do to claimed block
					return;
				}

				//Check the status of the game winner/tie/still going
				//this is done twice to make it as optimal as possible!
				if (clsGame.bytWin == 1)
				{
					clsGame.intHumanScore++;
					sbStatus.Panels[1].Text = "You: " + clsGame.intHumanScore.ToString()
						+ " Computer: " + clsGame.intCompScore.ToString();
					MessageBox.Show("You won!");
					clsGame.NewGame();
				}
				else if (clsGame.bytWin == 2)
				{
					clsGame.intCompScore++;
					sbStatus.Panels[1].Text = "You: " + clsGame.intHumanScore.ToString()
						+ " Computer: " + clsGame.intCompScore.ToString();
					MessageBox.Show("You lost.");
					clsGame.NewGame();
				}
				else if (clsGame.CheckTie() == true)
				{
					MessageBox.Show("The game resulted in a tie.");
					clsGame.NewGame();
				}

				//You took your turn so now it is the computers turn
				clsGame.bytCurrentPlayer = clsGameplay.ComputersTurn;
				sbStatus.Panels[0].Text = "Computer's Move";
				clsGame.MoveComputer();
				sbStatus.Panels[0].Text = "Your Move";

				//Check the status of the game winner/tie/still going
				//this is done twice to make it as optimal as possible!
				if (clsGame.bytWin == 1)
				{
					clsGame.intHumanScore++;
					sbStatus.Panels[1].Text = "You: " + clsGame.intHumanScore.ToString()
						+ " Computer: " + clsGame.intCompScore.ToString();
					MessageBox.Show("You won!");
					clsGame.NewGame();
				}
				else if (clsGame.bytWin == 2)
				{
					clsGame.intCompScore++;
					sbStatus.Panels[1].Text = "You: " + clsGame.intHumanScore.ToString()
						+ " Computer: " + clsGame.intCompScore.ToString();
					MessageBox.Show("You lost.");
					clsGame.NewGame();
				}
				else if (clsGame.CheckTie() == true)
				{
					MessageBox.Show("The game resulted in a tie.");
					clsGame.NewGame();
				}
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
