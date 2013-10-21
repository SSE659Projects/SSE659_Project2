using System;
using System.Windows.Forms;

namespace CS_TickTackToe
{
	/// <summary>
	/// Summary description for clsGameplay.
	/// </summary>
	
	public class clsGameplay
	{
        public const int UNDEFINED_MOVE = 10;
		
        public enum EPlayer
        {
            E_NOT_SET_OR_DEFINED,
            E_HUMAN,
            E_COMPUTER
        };

        private EPlayer m_Player = EPlayer.E_HUMAN;

		public int intHumanScore = 0;
		public int intCompScore = 0;
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
		//Jagged array that corresponds to the pictures
		//0 = not set, 1 = human, 2 = computer
        private byte[,] bytCurrentPositions = new byte[3, 3];

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
                    bytCurrentPositions[i, ii] = (byte)EPlayer.E_NOT_SET_OR_DEFINED;		
				}				
			}
			//Reset the pictures
			clsPicCol.Clear_Pictures();
		}

		public void SetBoardPosition(EPlayer player, int intDim1, int intDim2, bool bCheckForWinner=true)
		{
            bytCurrentPositions[intDim1, intDim2] = (byte)player;

            if (bCheckForWinner)
                m_Winner = CheckForWinner();
		}

		public void ComputerMoveAI()
		{
            if (m_GameDifficulty == EGameDifficulty.E_EASY)
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
            else if (m_GameDifficulty == EGameDifficulty.E_MEDIUM)
			{
				//A defensive algorithm
				//that only blindly moves
				//if no defensive move
                clsNextMovePosition nextDefensiveMovePosition = new clsNextMovePosition();
                FindTwoInSequence(nextDefensiveMovePosition, (byte)EPlayer.E_HUMAN);
                if (nextDefensiveMovePosition.IsNextMoveDefined())
				{
                    SetComputerPosition(Convert.ToInt32(nextDefensiveMovePosition.PositionX), Convert.ToInt32(nextDefensiveMovePosition.PositionY));
				}
				else
				{
					//If no defensive move then
					//go random again
					System.Random rnd = new System.Random();
                    RandomComputerMove(rnd);
				}
			}
            else if (m_GameDifficulty == EGameDifficulty.E_HARD)
			{
				//This algorithm looks for an offensive
				//move to make, if there is no offensive
				//move to make it makes a defensive move
				//if there is no offensive move and
				//no defensive more it makes a random move

                clsNextMovePosition nextOffensiveMovePosition = new clsNextMovePosition();
                clsNextMovePosition nextDefensiveMovePosition = new clsNextMovePosition();
				FindTwoInSequence(nextOffensiveMovePosition, (byte)EPlayer.E_COMPUTER);
                FindTwoInSequence(nextDefensiveMovePosition, (byte)EPlayer.E_HUMAN);
                if (nextOffensiveMovePosition.IsNextMoveDefined())
				{
                    SetComputerPosition(Convert.ToInt32(nextOffensiveMovePosition.PositionX), Convert.ToInt32(nextOffensiveMovePosition.PositionY));
				}
                else if (nextDefensiveMovePosition.IsNextMoveDefined())
				{
                    SetComputerPosition(Convert.ToInt32(nextDefensiveMovePosition.PositionX), Convert.ToInt32(nextDefensiveMovePosition.PositionY));
				}
				else
				{
					//If no defensive or offensive move so
					//go random again
					System.Random rnd = new System.Random();
					RandomComputerMove(rnd);
				}
			}
            m_Player = EPlayer.E_HUMAN;
		}
		
		public void RandomComputerMove(Random randomNumber)
        {
            int positionX = randomNumber.Next(0, 3);
            int positionY = randomNumber.Next(0, 3);

            if (bytCurrentPositions[positionX, positionY] == (byte)EPlayer.E_NOT_SET_OR_DEFINED)
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
					if (bytCurrentPositions[i, ii] == (byte)EPlayer.E_NOT_SET_OR_DEFINED)
					{
						return false;
					}
				}				
			}
			return true;
		}

		//Checks if the current player has
		//two in a sequence, if so it
		//returns the coordinates needed for
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
		//or negatively sloped like (\)
		// x| |     x| |      | |
		//  | |      |x|      |x|
		//  | |x     | |      | |x
		public void FindTwoInSequence(clsNextMovePosition nextMovePosition, byte bytPlayer)
		{
            if (FoundHorizontalSequence(nextMovePosition, bytPlayer))
                return;
            else if (FoundVerticalSequence(nextMovePosition, bytPlayer))
                return;
            else if (FoundDiagonalNegativeSlopeSequence(nextMovePosition, bytPlayer))
                return;
            else if (FoundDiagonalPositiveSlopeSequence(nextMovePosition, bytPlayer))
                return;
            else
            {
                nextMovePosition.PositionX = UNDEFINED_MOVE;
                nextMovePosition.PositionY = UNDEFINED_MOVE;
                return;
            }
		}

        public bool FoundHorizontalSequence(clsNextMovePosition nextMovePosition, byte bytPlayer)
        {
            for (byte i = 0; i <= 2; i++)
            {
                if (bytCurrentPositions[i, 0] == bytPlayer &&
                    bytCurrentPositions[i, 1] == bytPlayer &&
                    bytCurrentPositions[i, 2] == 0)
                {
                    //bytMoveArray[0] = i;
                    //bytMoveArray[1] = 2;
                    nextMovePosition.PositionX = i;
                    nextMovePosition.PositionY = 2;
                    return true;
                }

                else if (bytCurrentPositions[i, 0] == bytPlayer &&
                    bytCurrentPositions[i, 2] == bytPlayer &&
                    bytCurrentPositions[i, 1] == 0)
                {
                    //bytMoveArray[0] = i;
                    //bytMoveArray[1] = 1;
                    nextMovePosition.PositionX = i;
                    nextMovePosition.PositionY = 1;
                    return true;
                }

                else if (bytCurrentPositions[i, 1] == bytPlayer &&
                    bytCurrentPositions[i, 2] == bytPlayer &&
                    bytCurrentPositions[i, 0] == 0)
                {
                    //bytMoveArray[0] = i;
                    //bytMoveArray[1] = 0;
                    nextMovePosition.PositionX = i;
                    nextMovePosition.PositionY = 0;
                    return true;
                }
            }
            return false;
        }

        public bool FoundVerticalSequence(clsNextMovePosition nextMovePosition, byte bytPlayer)
        {
            for (byte i = 0; i <= 2; i++)
            {
                if (bytCurrentPositions[0, i] == bytPlayer &&
                    bytCurrentPositions[1, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == 0)
                {
                    //bytMoveArray[0] = 2;
                    //bytMoveArray[1] = i;
                    nextMovePosition.PositionX = 2;
                    nextMovePosition.PositionY = i;
                    return true;
                }

                else if (bytCurrentPositions[0, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == bytPlayer &&
                    bytCurrentPositions[1, i] == 0)
                {
                    //bytMoveArray[0] = 1;
                    //bytMoveArray[1] = i;
                    nextMovePosition.PositionX = 1;
                    nextMovePosition.PositionY = i;
                    return true;
                }

                else if (bytCurrentPositions[1, i] == bytPlayer &&
                    bytCurrentPositions[2, i] == bytPlayer &&
                    bytCurrentPositions[0, i] == 0)
                {
                    //bytMoveArray[0] = 0;
                    //bytMoveArray[1] = i;
                    nextMovePosition.PositionX = 0;
                    nextMovePosition.PositionY = i;
                    return true;
                }
            }
            return false;
        }

        public bool FoundDiagonalPositiveSlopeSequence(clsNextMovePosition nextMovePosition, byte bytPlayer)
        {
            if (bytCurrentPositions[0, 2] == bytPlayer &&
                bytCurrentPositions[1, 1] == bytPlayer &&
                 bytCurrentPositions[2, 0] == 0)
            {
                //bytMoveArray[0] = 2;
                //bytMoveArray[1] = 0;
                nextMovePosition.PositionX = 2;
                nextMovePosition.PositionY = 0;
                return true;
            }

            else if (bytCurrentPositions[0, 2] == bytPlayer &&
                bytCurrentPositions[2, 0] == bytPlayer &&
                bytCurrentPositions[1, 1] == 0)
            {
                //bytMoveArray[0] = 1;
                //bytMoveArray[1] = 1;
                nextMovePosition.PositionX = 1;
                nextMovePosition.PositionY = 1;
                return true;
            }

            else if (bytCurrentPositions[1, 1] == bytPlayer &&
                 bytCurrentPositions[2, 0] == bytPlayer &&
                 bytCurrentPositions[0, 2] == 0)
            {
                //bytMoveArray[0] = 0;
                //bytMoveArray[1] = 2;
                nextMovePosition.PositionX = 0;
                nextMovePosition.PositionY = 2;
                return true;
            }

            else
                return false;
        }

        public bool FoundDiagonalNegativeSlopeSequence(clsNextMovePosition nextMovePosition, byte bytPlayer)
        {
            if (bytCurrentPositions[0, 0] == bytPlayer &&
                bytCurrentPositions[1, 1] == bytPlayer &&
                bytCurrentPositions[2, 2] == 0)
            {
                //bytMoveArray[0] = 2;
                //bytMoveArray[1] = 2;
                nextMovePosition.PositionX = 2;
                nextMovePosition.PositionY = 2;
                return true;
            }

            else if (bytCurrentPositions[0, 0] == bytPlayer &&
                bytCurrentPositions[2, 2] == bytPlayer &&
                bytCurrentPositions[1, 1] == 0)
            {
                //bytMoveArray[0] = 1;
                //bytMoveArray[1] = 1;
                nextMovePosition.PositionX = 1;
                nextMovePosition.PositionY = 1;
                return true;
            }

            else if (bytCurrentPositions[1, 1] == bytPlayer &&
                bytCurrentPositions[2, 2] == bytPlayer &&
                bytCurrentPositions[0, 0] == 0)
            {
                //bytMoveArray[0] = 0;
                //bytMoveArray[1] = 0;
                nextMovePosition.PositionX = 0;
                nextMovePosition.PositionY = 0;
                return true;
            }

            else
                return false;
        }
	}//End class
}//End Namespace
