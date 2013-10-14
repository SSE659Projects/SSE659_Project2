// clsGameplay.cs - Class that contains methods for starting a new game,
// setting the positions on the Tic Tac Toe board, the logic method for
// the computer opponent's AI, determining winning combinations, and 
// checking for a tied game.
using System;
using System.Windows.Forms;

namespace CS_TickTackToe
{
	public class clsGameplay
	{
		public byte bytCurrentPlayer = 1; // 1 = Player (Default), 2 = Computer Opponent
		public clsPictureCollection clsPicCol;
		public byte bytWin = 0;
		public byte bytDifficulty = 0; // 0 = Easy (Default), 1 = Medium, 2 = Hard

		public PictureBox picO;
		public byte[,] bytCurrentPositions = new byte[3,3]; // 0 = Not set, 1 = Player, 2 = Computer Opponent

        // Function for setting up the PictureBox
		public clsGameplay(PictureBox picOHolder)
		{
			picO = picOHolder;
		}

        // Function for resetting the Tic Tac Toe board
		public void NewGame()
		{
			//Sets all the positions to zero
			for (int i = 0; i <= 2; i++)
			{
				for (int ii = 0; ii <= 2; ii++)
				{
					bytCurrentPositions[i, ii] = 0;			
				}				
			}
			clsPicCol.Clear_Pictures(); // Resets the Tic Tac Toe Board
		}

        // Function for setting the board positions
		public void SetBoardPosition(byte bytPlayer, int intDim1, int intDim2)
		{
			bytCurrentPositions[intDim1, intDim2] = bytPlayer;
			bytWin = CheckForWin(); 
		}

        // Function for determining the Computer opponent AI based on player's choice
		public void ComputerMoveAI()
		{
			if (bytDifficulty == 0) // Difficulty set to Easy
			{
				try
				{
					System.GC.Collect();
                    System.Random rnd = new System.Random();
                    RetryRandomComputerMove(rnd);
				}
				catch (System.Exception e)
				{
					clsPicCol.sbStatus.Panels[1].Text = e.Message;
					clsPicCol.sbStatus.Panels[1].ToolTipText = e.Message;
				}
			}
			else if (bytDifficulty == 1) // Difficulty set to Medium
			{
				byte[] bytMove = FindTwoInSequence(1);
				if (bytMove[0] != 10 && bytMove[1] != 10)
				{
                    ComputerMoveSequence(bytMove);
				}
				else
				{
                    System.Random rnd = new System.Random();
                    RetryRandomComputerMove(rnd);
				}
			}
			else if (bytDifficulty == 2) // Difficulty set to Hard
			{
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
                    System.Random rnd = new System.Random();
                    RetryRandomComputerMove(rnd);
				}
			}
			bytCurrentPlayer = 1;
		}

        // Function for retrying the computer's random move
        public void RetryRandomComputerMove(Random randomNumber)
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
                RetryRandomComputerMove(randomNumber); //Retry random number generation
            }
        }

        // Function for making the computer's move sequence
        public void ComputerMoveSequence(byte [] bytMoveArray)
        {
            SetBoardPosition(2, Convert.ToInt32(bytMoveArray[0]),
                        Convert.ToInt32(bytMoveArray[1]));
            bytMoveArray[0]++;
            bytMoveArray[1]++;
            int i;
            for (i = 0; i < clsPicCol.Count; i++)
            {
                if (clsPicCol[i].Name.Equals("pic" + bytMoveArray[0].ToString()
                    + bytMoveArray[1].ToString()))
                {
                    clsPicCol[i].Image = picO.Image;
                }
            }
        }

        // Function for checking if there is a win
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

            //Check for diagonal down win
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
            
            //Check for diagonal up win
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

        // Function for checking if the game has ended in a tie
		public bool CheckForTie()
		{
			// Checks if there are no zero positions, game is tied
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

        // Function for finding two choices in sequence on the board
		public byte[] FindTwoInSequence(byte bytPlayer)
		{
			byte[] bytMove = new byte[2];

            if (FoundHorizontalSequence(bytMove, bytPlayer))
                return bytMove;
            else if (FoundVerticalSequence(bytMove, bytPlayer))
                return bytMove;
            else if (FoundDiagonalDownSequence(bytMove, bytPlayer))
                return bytMove;
            else if (FoundDiagonalUpSequence(bytMove, bytPlayer))
                return bytMove;
            else
            {
                bytMove[0] = 10;
                bytMove[1] = 10;
                return bytMove;
            }
		}

        // Function used to find a horizontal sequence on the board
        public bool FoundHorizontalSequence(byte [] bytMoveArray, byte bytPlayer)
        {
            for (byte i = 0; i <= 2; i++)
            {
                // Checks if there is a sequence in the last row
                if (bytCurrentPositions[i, 0] == bytPlayer &&
                    bytCurrentPositions[i, 1] == bytPlayer &&
                    bytCurrentPositions[i, 2] == 0)
                {
                    bytMoveArray[0] = i;
                    bytMoveArray[1] = 2;
                    return true;
                }

                // Checks if there is a sequence in the middle row
                else if (bytCurrentPositions[i, 0] == bytPlayer &&
                    bytCurrentPositions[i, 2] == bytPlayer &&
                    bytCurrentPositions[i, 1] == 0)
                {
                    bytMoveArray[0] = i;
                    bytMoveArray[1] = 1;
                    return true;
                }

                // Checks if there is a sequence in the first row
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

        // Function used to find a vertical sequence on the board
        public bool FoundVerticalSequence(byte [] bytMoveArray, byte bytPlayer)
        {
            for (byte i = 0; i <= 2; i++)
            {
                // Checks if there is a sequence in the last column
                if (bytCurrentPositions[0, i] == bytPlayer &&
                    bytCurrentPositions[1, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == 0)
                {
                    bytMoveArray[0] = 2;
                    bytMoveArray[1] = i;
                    return true;
                }

                // Checks if there is a sequence in the middle column
                else if (bytCurrentPositions[0, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == bytPlayer &&
                    bytCurrentPositions[1, i] == 0)
                {
                    bytMoveArray[0] = 1;
                    bytMoveArray[1] = i;
                    return true;
                }

                // Checks if there is a sequence in the first column
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

        // Function used to find a diagonal up sequence on the board
        public bool FoundDiagonalUpSequence(byte [] bytMoveArray, byte bytPlayer)
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

        // Function used to find a diagonal down sequence on the board
        public bool FoundDiagonalDownSequence(byte[] bytMoveArray, byte bytPlayer)
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
