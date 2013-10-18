using System;
using System.Windows.Forms;

namespace CS_TickTackToe
{
	/// <summary>
	/// Summary description for clsGameplay.
	/// </summary>
	
	public class clsGameplay
	{
		//1 = human 2 = comp
		public byte bytCurrentPlayer = 1;
		public int intHumanScore = 0;
		public int intCompScore = 0;
		public clsPictureCollection clsPicCol;
		public byte bytWin = 0;
		
        public const int Easy = 0;
        public const int Medium = 1;
        public const int Hard = 2;
        //default to Easy
        public byte bytDifficulty = Easy;


		public PictureBox picO;
		//Jagged array that corresponds to the pictures
		//0 = not set, 1 = human, 2 = computer
		public byte[,] bytCurrentPositions = new byte[3,3];

		public clsGameplay(PictureBox picOHolder)
		{
			picO = picOHolder;
		}
		public void NewGame()
		{
			//Rest all of the variables
			for (int i = 0; i <= 2; i++)
			{
				for (int ii = 0; ii <= 2; ii++)
				{
					bytCurrentPositions[i, ii] = 0;			
				}				
			}
			//Reset the pictures
			clsPicCol.Clear_Pictures();
		}

		public void SetPosition(byte bytPlayer, int intDim1, int intDim2)
		{
			bytCurrentPositions[intDim1, intDim2] = bytPlayer;

			//Check for a win
			bytWin = CheckWin();
		}

		public void MoveComputer()
		{
			if (bytDifficulty == Easy)
			{
#region Easy
				//Wierd ai, but just pic
				//two random numbers between
				//0 and 2 and check if the spot
				//is taken, if not take it
				try
				{
					System.Random rnd = new System.Random();
					int pos1 = rnd.Next(1, 4);
					int pos2 = rnd.Next(1, 4);
					System.GC.Collect();

					if (bytCurrentPositions[pos1 - 1, pos2 - 1] == 0)
					{
						//No one is using it so good to go
						SetPosition(2, pos1 - 1, pos2 - 1);
						int i;
						for (i = 0; i < clsPicCol.Count; i++)
						{
							if (clsPicCol[i].Name.Equals("pic" + pos1.ToString() 
								+ pos2.ToString()))
							{
								clsPicCol[i].Image = picO.Image;
							}
						}
					}
					else
					{
						//Recursively try again
						MoveComputer();
					}
				}
				catch (System.Exception e)
				{
					clsPicCol.sbStatus.Panels[1].Text = e.Message;
					clsPicCol.sbStatus.Panels[1].ToolTipText = e.Message;
				}
#endregion
			}
			else if (bytDifficulty == Medium)
			{
#region Medium
				//A defensive algorithm
				//that only blindly moves
				//if no defensive move
				byte[] bytMove = TwoInSequence(1);
				if (bytMove[0] != 10 && bytMove[1] != 10)
				{
					SetPosition(2, Convert.ToInt32(bytMove[0]),
						Convert.ToInt32(bytMove[1]));
					bytMove[0]++;
					bytMove[1]++;
					int i;
					for (i = 0; i < clsPicCol.Count; i++)
					{
						if (clsPicCol[i].Name.Equals("pic" + bytMove[0].ToString() 
							+ bytMove[1].ToString()))
						{
							clsPicCol[i].Image = picO.Image;
						}
					}
				}
				else
				{
					//If no defensive move then
					//go random again
					System.Random rnd = new System.Random();
				RetryRandom:
					int pos1 = rnd.Next(1, 4);
					int pos2 = rnd.Next(1, 4);

					if (bytCurrentPositions[pos1 - 1, pos2 - 1] == 0)
					{
						//No one is using it so good to go
						SetPosition(2, pos1 - 1, pos2 - 1);
						int i;
						for (i = 0; i < clsPicCol.Count; i++)
						{
							if (clsPicCol[i].Name.Equals("pic" + pos1.ToString() 
								+ pos2.ToString()))
							{
								clsPicCol[i].Image = picO.Image;
							}
						}
					}
					else
					{
						//Retry that random number generation
						goto RetryRandom;
					}
				}
#endregion
			}
			else if (bytDifficulty == Hard)
			{
#region Hard
				//This algorithm looks for an offensive
				//move to make, if there is no offensive
				//move to make it makes a defensive move
				//if there is no offensive move and
				//no defensive more it makes a random move
				byte[] bytMove = TwoInSequence(2);
				byte[] bytMove2 = TwoInSequence(1);
				if (bytMove[0] != 10 && bytMove[1] != 10)
				{
					SetPosition(2, Convert.ToInt32(bytMove[0]),
						Convert.ToInt32(bytMove[1]));
					bytMove[0]++;
					bytMove[1]++;
					int i;
					for (i = 0; i < clsPicCol.Count; i++)
					{
						if (clsPicCol[i].Name.Equals("pic" + bytMove[0].ToString() 
							+ bytMove[1].ToString()))
						{
							clsPicCol[i].Image = picO.Image;
						}
					}
				}
				else if (bytMove2[0] != 10 && bytMove2[1] != 10)
				{
					SetPosition(2, Convert.ToInt32(bytMove2[0]),
						Convert.ToInt32(bytMove2[1]));
					bytMove2[0]++;
					bytMove2[1]++;
					int i;
					for (i = 0; i < clsPicCol.Count; i++)
					{
						if (clsPicCol[i].Name.Equals("pic" + bytMove2[0].ToString() 
							+ bytMove2[1].ToString()))
						{
							clsPicCol[i].Image = picO.Image;
						}
					}
				}
				else
				{
					//If no defensive or offensive move so
					//go random again
					System.Random rnd = new System.Random();
				RetryRandom2:
					int pos1 = rnd.Next(1, 4);
					int pos2 = rnd.Next(1, 4);

					if (bytCurrentPositions[pos1 - 1, pos2 - 1] == 0)
					{
						//No one is using it so good to go
						SetPosition(2, pos1 - 1, pos2 - 1);
						int i;
						for (i = 0; i < clsPicCol.Count; i++)
						{
							if (clsPicCol[i].Name.Equals("pic" + pos1.ToString() 
								+ pos2.ToString()))
							{
								clsPicCol[i].Image = picO.Image;
							}
						}
					}
					else
					{
						//Retry that random number generation
						goto RetryRandom2;
					}
				}
#endregion
			}
			bytCurrentPlayer = 1;
		}

		//0 = no win
		//1 = human won
		//2 = comp one
		public byte CheckWin()
		{
#region Check for a win
			//Check for a horizontal win
			for (int i = 0; i <= 2; i++)
			{
				if (bytCurrentPositions[i,0] == 1 &&
					bytCurrentPositions[i,1] == 1 &&
					bytCurrentPositions[i,2] == 1)
				{
					//Human won
					return 1;
				}
			}

			for (int i = 0; i <= 2; i++)
			{
				if (bytCurrentPositions[i,0] == 2 &&
					bytCurrentPositions[i,1] == 2 &&
					bytCurrentPositions[i,2] == 2)
				{
					//Computer won
					return 2;
				}
			}

			//Check for a vertical win
			for (int i = 0; i <= 2; i++)
			{
				if (bytCurrentPositions[0,i] == 1 &&
					bytCurrentPositions[1,i] == 1 &&
					bytCurrentPositions[2,i] == 1)
				{
					//Human won
					return 1;
				}
			}

			for (int i = 0; i <= 2; i++)
			{
				if (bytCurrentPositions[0,i] == 2 &&
					bytCurrentPositions[1,i] == 2 &&
					bytCurrentPositions[2,i] == 2)
				{
					//Computer won
					return 2;
				}
			}

			//Check for diagnol win
			if (bytCurrentPositions[0,0] == 1 &&
				bytCurrentPositions[1,1] == 1 &&
				bytCurrentPositions[2,2] == 1)
			{
				//Human won
				return 1;
			}

			if (bytCurrentPositions[0,2] == 1 &&
				bytCurrentPositions[1,1] == 1 &&
				bytCurrentPositions[2,0] == 1)
			{
				//Human won
				return 1;
			}

			if (bytCurrentPositions[0,0] == 2 &&
				bytCurrentPositions[1,1] == 2 &&
				bytCurrentPositions[2,2] == 2)
			{
				//Computer won
				return 2;
			}

			if (bytCurrentPositions[0,2] == 2 &&
				bytCurrentPositions[1,1] == 2 &&
				bytCurrentPositions[2,0] == 2)
			{
				//Computer won
				return 2;
			}
			return 0;
#endregion
		}

		public bool CheckTie()
		{
			//Loop through all of the positions
			//and check their status, if even 
			//one is not taken there is not a 
			//tie, if we get to the end and there
			//is no position marked with a 0
			//there is a tie.
			for (int i = 0; i <= 2; i++)
			{
				for (int ii = 0; ii <= 2; ii++)
				{
					if (bytCurrentPositions[i, ii] == 0)
					{
						return false;
					}
				}				
			}
			return true;
		}

		//Checks if the current player has
		//two in a sequence, if so it
		//returns the corrodinates needed for
		//the player to get three in a row
		//or the opponent to block.

		//A sequence counts as two in any
		//row or column for the specified
		//player for example:

		//The x's can be in any row and still
		//work
		// x| |x     |x|x    x|x|  
		//  | |      | |      | |
		//  | |      | |      | |

		//The x's can be in any column and still
		//work
		// x| |     x| |      | |  
		//  | |     x| |     x| |
		// x| |      | |     x| |

		//The x's can be in either a positively (/)
		//or negitively sloped like (\)
		// x| |     x| |      | |
		//  | |      |x|      |x|
		//  | |x     | |      | |x
		public byte[] TwoInSequence(byte bytPlayer)
		{
			byte[] bytMove = new byte[2];

#region Check for a sequence horizontally
			for (byte i = 0; i <= 2; i++)
			{
				if (bytCurrentPositions[i,0] == bytPlayer &&
					bytCurrentPositions[i,1] == bytPlayer &&
					bytCurrentPositions[i,2] == 0)
				{
					bytMove[0] = i;
					bytMove[1] = 2;
					return bytMove;
				}

				if (bytCurrentPositions[i,0] == bytPlayer &&
					bytCurrentPositions[i,2] == bytPlayer &&
					bytCurrentPositions[i,1] == 0)
				{
					bytMove[0] = i;
					bytMove[1] = 1;
					return bytMove;
				}

				if (bytCurrentPositions[i,1] == bytPlayer &&
					bytCurrentPositions[i,2] == bytPlayer &&
					bytCurrentPositions[i,0] == 0)
				{
					bytMove[0] = i;
					bytMove[1] = 0;
					return bytMove;
				}
			}	
#endregion

#region Check for a sequence verically
			for (byte i = 0; i <= 2; i++)
			{
				if (bytCurrentPositions[0,i] == bytPlayer &&
					bytCurrentPositions[1,i] == bytPlayer &&
					bytCurrentPositions[2,i] == 0)
				{
					bytMove[0] = 2;
					bytMove[1] = i;
					return bytMove;
				}

				if (bytCurrentPositions[0,i] == bytPlayer &&
					bytCurrentPositions[2,i] == bytPlayer &&
					bytCurrentPositions[1,i] == 0)
				{
					bytMove[0] = 1;
					bytMove[1] = i;
					return bytMove;
				}

				if (bytCurrentPositions[1,i] == bytPlayer &&
					bytCurrentPositions[2,i] == bytPlayer &&
					bytCurrentPositions[0,i] == 0)
				{
					bytMove[0] = 0;
					bytMove[1] = i;
					return bytMove;
				}
			}	
#endregion

#region Check for a sequence Diagonally
			//Diagonally with negative slope
			if (bytCurrentPositions[0,0] == bytPlayer &&
				bytCurrentPositions[1,1] == bytPlayer &&
				bytCurrentPositions[2,2] == 0)
			{
				bytMove[0] = 2;
				bytMove[1] = 2;
				return bytMove;
			}

			if (bytCurrentPositions[0,0] == bytPlayer &&
				bytCurrentPositions[2,2] == bytPlayer &&
				bytCurrentPositions[1,1] == 0)
			{
				bytMove[0] = 1;
				bytMove[1] = 1;
				return bytMove;
			}

			if (bytCurrentPositions[1,1] == bytPlayer &&
				bytCurrentPositions[2,2] == bytPlayer &&
				bytCurrentPositions[0,0] == 0)
			{
				bytMove[0] = 0;
				bytMove[1] = 0;
				return bytMove;
			}

			//Diagonally with positive slope
			if (bytCurrentPositions[0,2] == bytPlayer &&
				bytCurrentPositions[1,1] == bytPlayer &&
				bytCurrentPositions[2,0] == 0)
			{
				bytMove[0] = 2;
				bytMove[1] = 0;
				return bytMove;
			}

			if (bytCurrentPositions[0,2] == bytPlayer &&
				bytCurrentPositions[2,0] == bytPlayer &&
				bytCurrentPositions[1,1] == 0)
			{
				bytMove[0] = 1;
				bytMove[1] = 1;
				return bytMove;
			}

			if (bytCurrentPositions[1,1] == bytPlayer &&
				bytCurrentPositions[2,0] == bytPlayer &&
				bytCurrentPositions[0,2] == 0)
			{
				bytMove[0] = 0;
				bytMove[1] = 2;
				return bytMove;
			}
#endregion

			bytMove[0] = 10;
			bytMove[1] = 10;
			return bytMove;
		}
	}//End class
}//End Namespace
