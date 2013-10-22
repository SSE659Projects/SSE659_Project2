using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NUnit.Framework;

namespace CS_TickTackToe.Tests
{
    public class TickTackToeTest
    {
        [TestCase(0, clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(1, clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(2, clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(0, clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        [TestCase(1, clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        [TestCase(2, clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        public clsGameplay.EPlayer checkHorizontalWin(byte sidePosition, clsGameplay.EPlayer playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.SetBoardPosition(playerType, sidePosition, 0, false);
            clsGame.SetBoardPosition(playerType, sidePosition, 1, false);
            clsGame.SetBoardPosition(playerType, sidePosition, 2, false);

            return clsGame.CheckForWinner(); 
	    }


        [TestCase(0, clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(1, clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(2, clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(0, clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        [TestCase(1, clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        [TestCase(2, clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        public clsGameplay.EPlayer checkVerticalWin(byte sidePosition, clsGameplay.EPlayer playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.SetBoardPosition(playerType, 0, sidePosition, false);
            clsGame.SetBoardPosition(playerType, 1, sidePosition, false);
            clsGame.SetBoardPosition(playerType, 2, sidePosition, false);

            return clsGame.CheckForWinner();
	    }

        [TestCase(clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        public clsGameplay.EPlayer checkDiagonalDownWin(clsGameplay.EPlayer playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            return clsGame.CheckForWinner();
	    }

        [TestCase(clsGameplay.EPlayer.E_HUMAN, ExpectedResult = clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = clsGameplay.EPlayer.E_COMPUTER)]
        public clsGameplay.EPlayer checkDiagonalUpWin(clsGameplay.EPlayer playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.SetBoardPosition(playerType, 0, 2, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 0, false);

            return clsGame.CheckForWinner();
	    }

        [TestCase(clsGameplay.EPlayer.E_HUMAN, ExpectedResult = true)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER, ExpectedResult = true)]
        [TestCase(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, ExpectedResult = false)]
        public bool checkGameTie(clsGameplay.EPlayer playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            for (int i = 0; i <= 2; i++)
            {
                for (int ii = 0; ii <= 2; ii++)
                {
                    clsGame.SetBoardPosition(playerType, i, ii, false);
                }
            }

            return clsGame.CheckForTie();
	    }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkHortizontalSequenceFirstRow(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 0, 1, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 1, false);
            clsGame.SetBoardPosition(playerType, 0, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 0, 1, false);
            clsGame.SetBoardPosition(playerType, 0, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkHortizontalSequenceSecondRow(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 1, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.SetBoardPosition(playerType, 1, 0, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 1, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 1, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkHortizontalSequenceThirdRow(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 2, 0, false);
            clsGame.SetBoardPosition(playerType, 2, 1, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.SetBoardPosition(playerType, 2, 0, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 0, false);
            clsGame.SetBoardPosition(playerType, 2, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkVerticalSequenceFirstColumn(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 0, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 0, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 0);

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 0, false);
            clsGame.SetBoardPosition(playerType, 2, 0, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 0);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 0, false);
            clsGame.SetBoardPosition(playerType, 2, 0, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkVerticalSequenceSecondColumn(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 0, 1, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 1, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.SetBoardPosition(playerType, 0, 1, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 1, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 1, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 1, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 1);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkVerticalSequenceThirdColumn(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 0, 2, false);
            clsGame.SetBoardPosition(playerType, 1, 2, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.SetBoardPosition(playerType, 0, 2, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 2, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 2, false);
            clsGame.SetBoardPosition(playerType, 1, 2, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 2);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkDiagonalUpSequence(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 0, 2, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 0, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 0);

            clsGame.SetBoardPosition(playerType, 0, 2, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 0, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 2, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 0, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 2);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkDiagonalDownSequence(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.SetBoardPosition(clsGameplay.EPlayer.E_NOT_SET_OR_DEFINED, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(clsGameplay.EPlayer.E_HUMAN)]
        [TestCase(clsGameplay.EPlayer.E_COMPUTER)]
        public void checkNoSequence(clsGameplay.EPlayer playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.SetBoardPosition(playerType, 0, 0, false);
            clsGame.SetBoardPosition(playerType, 1, 1, false);
            clsGame.SetBoardPosition(playerType, 2, 2, false);

            clsGame.FindTwoInSequence(nextMovePosition, (byte)playerType);
            Assert.AreEqual(nextMovePosition.PositionX, clsGameplay.UNDEFINED_MOVE);
            Assert.AreEqual(nextMovePosition.PositionY, clsGameplay.UNDEFINED_MOVE);
        }
         
    }
}
