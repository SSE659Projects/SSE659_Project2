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
		//0 = easy, 1 = medium, 2 = hard
		public byte bytDifficulty = 0;

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

		public void SetBoardPosition(byte bytPlayer, int intDim1, int intDim2)
		{
			bytCurrentPositions[intDim1, intDim2] = bytPlayer;

			//Check for a win
			bytWin = CheckForWin();
		}

		public void ComputerMoveAI()
		{
			if (bytDifficulty == 0)
			{
				//Wierd ai, but just pic
				//two random numbers between
				//0 and 2 and check if the spot
				//is taken, if not take it
				try
				{
					System.Random rnd = new System.Random();
					System.GC.Collect();

                    RandomComputerMove(rnd);
				}
				catch (System.Exception e)
				{
					clsPicCol.sbStatus.Panels[1].Text = e.Message;
					clsPicCol.sbStatus.Panels[1].ToolTipText = e.Message;
				}
			}
			else if (bytDifficulty == 1)
			{
				//A defensive algorithm
				//that only blindly moves
				//if no defensive move
                byte[] bytMove = FindTwoInSequence(1);
				if (bytMove[0] != 10 && bytMove[1] != 10)
				{
                    ComputerMoveSequence(bytMove);
				}
				else
				{
					//If no defensive move then
					//go random again
					System.Random rnd = new System.Random();
                    RandomComputerMove(rnd);
				}
			}
			else if (bytDifficulty == 2)
			{
				//This algorithm looks for an offensive
				//move to make, if there is no offensive
				//move to make it makes a defensive move
				//if there is no offensive move and
				//no defensive more it makes a random move
                byte[] bytMove = FindTwoInSequence(2);
                byte[] bytMove2 = FindTwoInSequence(1);
				if (bytMove[0] != 10 && bytMove[1] != 10)
				{
                    ComputerMoveSequence(bytMove);
				}
				else if (bytMove2[0] != 10 && bytMove2[1] != 10)
				{
                    ComputerMoveSequence(bytMove2);
				}
				else
				{
					//If no defensive or offensive move so
					//go random again
					System.Random rnd = new System.Random();
                    RandomComputerMove(rnd);
				}
			}
			bytCurrentPlayer = 1;
		}

        public void RandomComputerMove(Random randomNumber)
        {
            int pos1 = randomNumber.Next(1, 4);
            int pos2 = randomNumber.Next(1, 4);

            if (bytCurrentPositions[pos1 - 1, pos2 - 1] == 0)
            {
                SetBoardPosition(2, pos1 - 1, pos2 - 1);
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
                //Retry random number generation
                RandomComputerMove(randomNumber);
            }
        }

        public void ComputerMoveSequence(byte[] bytMoveArray)
        {
            SetBoardPosition(2, Convert.ToInt32(bytMoveArray[0]),
                        Convert.ToInt32(bytMoveArray[1]));
            bytMoveArray[0]++;
            bytMoveArray[1]++;
            int i;
            for (i = 0; i < clsPicCol.Count; i++)
            {
                if (clsPicCol[i].Name.Equals("pic" +
                    bytMoveArray[0].ToString()
                    + bytMoveArray[1].ToString()))
                {
                    clsPicCol[i].Image = picO.Image;
                }
            }
        }

		//0 = no win
		//1 = human won
		//2 = comp one
		public byte CheckForWin()
		{
            //Check for a horizontal win
            for (int i = 0; i <= 2; i++)
            {
                for (byte ii = 1; ii <= 2; ii++)
                {
                    if (bytCurrentPositions[i, 0] == ii &&
                        bytCurrentPositions[i, 1] == ii &&
                        bytCurrentPositions[i, 2] == ii)
                    {
                        return ii;
                    }
                }
            }

            //Check for a vertical win
            for (int i = 0; i <= 2; i++)
            {
                for (byte ii = 1; ii <= 2; ii++)
                {
                    if (bytCurrentPositions[0, i] == ii &&
                        bytCurrentPositions[1, i] == ii &&
                        bytCurrentPositions[2, i] == ii)
                    {
                        return ii;
                    }
                }
            }

            //Check for diagonal negative slope win
            for (int i = 0; i <= 2; i++)
            {
                for (byte ii = 1; ii <= 2; ii++)
                {
                    if (bytCurrentPositions[0, 0] == ii &&
                        bytCurrentPositions[1, 1] == ii &&
                        bytCurrentPositions[2, 2] == ii)
                    {
                        return ii;
                    }
                }
            }

            //Check for diagonal positive slope win
            for (int i = 0; i <= 2; i++)
            {
                for (byte ii = 1; ii <= 2; ii++)
                {
                    if (bytCurrentPositions[0, 2] == ii &&
                        bytCurrentPositions[1, 1] == ii &&
                        bytCurrentPositions[2, 0] == ii)
                    {
                        return ii;
                    }
                }
            }

            return 0; //No winner
		}

		public bool CheckForTie()
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
		public byte[] FindTwoInSequence(byte bytPlayer)
		{
            byte[] bytMove = new byte[2];

            if (FoundHorizontalSequence(bytMove, bytPlayer))
                return bytMove;
            else if (FoundVerticalSequence(bytMove, bytPlayer))
                return bytMove;
            else if (FoundDiagonalNegativeSlopeSequence(bytMove, bytPlayer))
                return bytMove;
            else if (FoundDiagonalPositiveSlopeSequence(bytMove, bytPlayer))
                return bytMove;
            else
            {
                bytMove[0] = 10;
                bytMove[1] = 10;
                return bytMove;
            }
		}

        public bool FoundHorizontalSequence(byte[] bytMoveArray, byte bytPlayer)
        {
            for (byte i = 0; i <= 2; i++)
            {
                if (bytCurrentPositions[i, 0] == bytPlayer &&
                    bytCurrentPositions[i, 1] == bytPlayer &&
                    bytCurrentPositions[i, 2] == 0)
                {
                    bytMoveArray[0] = i;
                    bytMoveArray[1] = 2;
                    return true;
                }

                else if (bytCurrentPositions[i, 0] == bytPlayer &&
                    bytCurrentPositions[i, 2] == bytPlayer &&
                    bytCurrentPositions[i, 1] == 0)
                {
                    bytMoveArray[0] = i;
                    bytMoveArray[1] = 1;
                    return true;
                }

                else if (bytCurrentPositions[i, 1] == bytPlayer &&
                    bytCurrentPositions[i, 2] == bytPlayer &&
                    bytCurrentPositions[i, 0] == 0)
                {
                    bytMoveArray[0] = i;
                    bytMoveArray[1] = 0;
                    return true;
                }
            }
            return false;
        }

        public bool FoundVerticalSequence(byte[] bytMoveArray, byte bytPlayer)
        {
            for (byte i = 0; i <= 2; i++)
            {
                if (bytCurrentPositions[0, i] == bytPlayer &&
                    bytCurrentPositions[1, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == 0)
                {
                    bytMoveArray[0] = 2;
                    bytMoveArray[1] = i;
                    return true;
                }

                else if (bytCurrentPositions[0, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == bytPlayer &&
                    bytCurrentPositions[1, i] == 0)
                {
                    bytMoveArray[0] = 1;
                    bytMoveArray[1] = i;
                    return true;
                }

                else if (bytCurrentPositions[1, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == bytPlayer &&
                    bytCurrentPositions[0, i] == 0)
                {
                    bytMoveArray[0] = 0;
                    bytMoveArray[1] = i;
                    return true;
                }
            }
            return false;
        }

        public bool FoundDiagonalPositiveSlopeSequence(byte[] bytMoveArray, byte bytPlayer)
        {
            if (bytCurrentPositions[0, 2] == bytPlayer &&
                bytCurrentPositions[1, 1] == bytPlayer &&
                 bytCurrentPositions[2, 0] == 0)
            {
                bytMoveArray[0] = 2;
                bytMoveArray[1] = 0;
                return true;
            }

            else if (bytCurrentPositions[0, 2] == bytPlayer &&
                bytCurrentPositions[2, 0] == bytPlayer &&
                bytCurrentPositions[1, 1] == 0)
            {
                bytMoveArray[0] = 1;
                bytMoveArray[1] = 1;
                return true;
            }

            else if (bytCurrentPositions[1, 1] == bytPlayer &&
                 bytCurrentPositions[2, 0] == bytPlayer &&
                 bytCurrentPositions[0, 2] == 0)
            {
                bytMoveArray[0] = 0;
                bytMoveArray[1] = 2;
                return true;
            }

            else
                return false;
        }

        public bool FoundDiagonalNegativeSlopeSequence(byte[] bytMoveArray, byte bytPlayer)
        {
            if (bytCurrentPositions[0, 0] == bytPlayer &&
                bytCurrentPositions[1, 1] == bytPlayer &&
                bytCurrentPositions[2, 2] == 0)
            {
                bytMoveArray[0] = 2;
                bytMoveArray[1] = 2;
                return true;
            }

            else if (bytCurrentPositions[0, 0] == bytPlayer &&
                bytCurrentPositions[2, 2] == bytPlayer &&
                bytCurrentPositions[1, 1] == 0)
            {
                bytMoveArray[0] = 1;
                bytMoveArray[1] = 1;
                return true;
            }

            else if (bytCurrentPositions[1, 1] == bytPlayer &&
                bytCurrentPositions[2, 2] == bytPlayer &&
                bytCurrentPositions[0, 0] == 0)
            {
                bytMoveArray[0] = 0;
                bytMoveArray[1] = 0;
                return true;
            }

            else
                return false;
        }
	}//End class
}//End Namespace
