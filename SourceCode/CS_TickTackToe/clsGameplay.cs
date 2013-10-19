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
        const int UNDEFINED_MOVE = 10;
		
        public enum EPlayer
        {
            E_NOT_SET_OR_DEFINED,
            E_HUMAN,
            E_COMPUTER
        };

        private EPlayer m_Player = EPlayer.E_HUMAN;
		public clsPictureCollection clsPicCol;
		private EPlayer m_Winner = EPlayer.E_NOT_SET_OR_DEFINED;

        public enum EGameDifficulty
        {
            E_EASY,
            E_MEDIUM,
            E_HARD
        };

        private EGameDifficulty m_GameDifficulty = EGameDifficulty.E_EASY;
		private PictureBox picO;
        public byte[,] bytCurrentPositions = new byte[3, 3];

        public EPlayer GameWinner
        {
            get { return m_Winner; }
        }

        public EPlayer Player
        {
            get { return m_Player; }
            set { m_Player = value; }
        }
        public EGameDifficulty GameDifficulty
        {
            set { m_GameDifficulty = value; }
        }

        // Constructor for clsGameplay
		public clsGameplay(PictureBox picOHolder)
		{
			picO = picOHolder;
		}

        // Function for resetting the Tic Tac Toe board for a new game
		public void NewGame()
		{
			//Sets all board positions to zero
			for (int i = 0; i <= 2; i++)
			{
				for (int ii = 0; ii <= 2; ii++)
				{
                    bytCurrentPositions[i, ii] = (byte)EPlayer.E_NOT_SET_OR_DEFINED;		
				}				
			}
			clsPicCol.Clear_Pictures(); // Resets the Tic Tac Toe board
		}

        // Function for setting the board positions
		public void SetBoardPosition(EPlayer player, int intDim1, int intDim2)
		{
            bytCurrentPositions[intDim1, intDim2] = (byte)player;

            m_Winner = CheckForWinner();
		}

        // Function for determining the Computer opponent AI based on human's position
		public void ComputerMoveAI()
		{
            if (m_GameDifficulty == EGameDifficulty.E_EASY)
			{
                // Computer Random Move
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
            else if (m_GameDifficulty == EGameDifficulty.E_MEDIUM)
			{
				// Computer Defensive Move
                byte[] bytMove = FindTwoInSequence((byte)EPlayer.E_HUMAN);
                if (bytMove[0] != UNDEFINED_MOVE && bytMove[1] != UNDEFINED_MOVE)
				{
                    SetComputerPosition(Convert.ToInt32(bytMove[0]), Convert.ToInt32(bytMove[1]));
				}

                // Computer Random Move
				else
				{
					System.Random rnd = new System.Random();
                    RandomComputerMove(rnd);
				}
			}
            else if (m_GameDifficulty == EGameDifficulty.E_HARD)
			{
				byte[] bytMove = FindTwoInSequence((byte)EPlayer.E_COMPUTER);
                byte[] bytMove2 = FindTwoInSequence((byte)EPlayer.E_HUMAN);
                
                // Computer Offensive Move
                if (bytMove[0] != UNDEFINED_MOVE && bytMove[1] != UNDEFINED_MOVE)
				{
                    SetComputerPosition(Convert.ToInt32(bytMove[0]), Convert.ToInt32(bytMove[1]));
				}

                // Computer Defensive Move
                else if (bytMove2[0] != UNDEFINED_MOVE && bytMove2[1] != UNDEFINED_MOVE)
				{
                    SetComputerPosition(Convert.ToInt32(bytMove2[0]), Convert.ToInt32(bytMove2[1]));
				}

                // Computer Random Move
				else
				{
					System.Random rnd = new System.Random();
					RandomComputerMove(rnd);
				}
			}
            m_Player = EPlayer.E_HUMAN;
		}

        // Function for positioning the computer's random move
		public void RandomComputerMove(Random randomNumber)
        {
            int positionX = randomNumber.Next(0, 3);
            int positionY = randomNumber.Next(0, 3);

            if (bytCurrentPositions[positionX, positionY] == 0)
            {
                SetBoardPosition(EPlayer.E_COMPUTER, positionX, positionY);
                int i;
                for (i = 0; i < clsPicCol.Count; i++)
                {
                    if (clsPicCol[i].Name.Equals("pic" + positionX.ToString()
                        + positionY.ToString()))
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

        // Function for setting the computer's position on the board
        private void SetComputerPosition(int positionX, int positionY)
        {
            SetBoardPosition(EPlayer.E_COMPUTER, positionX, positionY);
            int i;
            for (i = 0; i < clsPicCol.Count; i++)
            {
                if (clsPicCol[i].Name.Equals("pic" + positionX.ToString()
                    + positionY.ToString()))
                {
                    clsPicCol[i].Image = picO.Image;
                }
            }
        }

        // Function for checking if the there is a win on the board
		public EPlayer CheckForWinner()
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
                        return (EPlayer)ii;
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
                        return (EPlayer)ii;
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
                        return (EPlayer)ii;
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
                        return (EPlayer)ii;
                    }
                }
            }

            return (EPlayer)0; //No winner
		}

        // Function for checking if the game has ended in a tie
		public bool CheckForTie()
		{
            // Checks if there are no zero positions, game is tied
			for (int i = 0; i <= 2; i++)
			{
				for (int ii = 0; ii <= 2; ii++)
				{
					if (bytCurrentPositions[i, ii] == (byte)EPlayer.E_NOT_SET_OR_DEFINED)
					{
						return false;
					}
				}				
			}
			return true;
		}

        // Function for finding two choices on the board in sequence
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
            	bytMove[0] = UNDEFINED_MOVE;
            	bytMove[1] = UNDEFINED_MOVE;
                return bytMove;
            }
		}

        // Function used to find a horizontal sequence on the board
        public bool FoundHorizontalSequence(byte[] bytMoveArray, byte bytPlayer)
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
        public bool FoundVerticalSequence(byte[] bytMoveArray, byte bytPlayer)
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

        // Function used to find a diagonal positive slope sequence on the board
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

        // Function used to find a diagonal negative slope sequence on the board
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
