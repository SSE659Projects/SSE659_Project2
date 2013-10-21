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
        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(2, 1, ExpectedResult = 1)]
        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(1, 2, ExpectedResult = 2)]
        [TestCase(2, 2, ExpectedResult = 2)]
        public byte checkHorizontalWin(byte sidePosition, byte playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.bytCurrentPositions[sidePosition, 0] = playerType;
            clsGame.bytCurrentPositions[sidePosition, 1] = playerType;
            clsGame.bytCurrentPositions[sidePosition, 2] = playerType;

            clsGameplay.EPlayer player = clsGame.CheckForWinner();
		    return (byte)player;
	    }

        [TestCase(0, 1, ExpectedResult = 1)]
        [TestCase(1, 1, ExpectedResult = 1)]
        [TestCase(2, 1, ExpectedResult = 1)]
        [TestCase(0, 2, ExpectedResult = 2)]
        [TestCase(1, 2, ExpectedResult = 2)]
        [TestCase(2, 2, ExpectedResult = 2)]
        public byte checkVerticalWin(byte sidePosition, byte playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.bytCurrentPositions[0, sidePosition] = playerType;
            clsGame.bytCurrentPositions[1, sidePosition] = playerType;
            clsGame.bytCurrentPositions[2, sidePosition] = playerType;

            clsGameplay.EPlayer player = clsGame.CheckForWinner();
            return (byte)player;
	    }

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        public byte checkDiagonalDownWin(byte playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGameplay.EPlayer player = clsGame.CheckForWinner();
            return (byte)player;
	    }

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        public byte checkDiagonalUpWin(byte playerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsGame.bytCurrentPositions[0, 2] = playerType;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 0] = playerType;

            clsGameplay.EPlayer player = clsGame.CheckForWinner();
            return (byte)player;
	    }

        [TestCase(1, ExpectedResult = true)]
        [TestCase(2, ExpectedResult = true)]
        [TestCase(0, ExpectedResult = false)]
        public bool checkGameTie(byte positionPlayerType)
	    {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            for (int i = 0; i <= 2; i++)
            {
                for (int ii = 0; ii <= 2; ii++)
                {
                    clsGame.bytCurrentPositions[i, ii] = positionPlayerType;
                }
            }

            bool isGameTie = clsGame.CheckForTie();
		    return isGameTie;
	    }

        [TestCase(1)]
        [TestCase(2)]
        public void checkHortizontalSequenceFirstRow(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[0, 1] = playerType;
            clsGame.bytCurrentPositions[0, 2] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[0, 1] = 0;
            clsGame.bytCurrentPositions[0, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.bytCurrentPositions[0, 0] = 0;
            clsGame.bytCurrentPositions[0, 1] = playerType;
            clsGame.bytCurrentPositions[0, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkHortizontalSequenceSecondRow(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[1, 0] = playerType;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[1, 2] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.bytCurrentPositions[1, 0] = playerType;
            clsGame.bytCurrentPositions[1, 1] = 0;
            clsGame.bytCurrentPositions[1, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.bytCurrentPositions[1, 0] = 0;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[1, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkHortizontalSequenceThirdRow(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[2, 0] = playerType;
            clsGame.bytCurrentPositions[2, 1] = playerType;
            clsGame.bytCurrentPositions[2, 2] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.bytCurrentPositions[2, 0] = playerType;
            clsGame.bytCurrentPositions[2, 1] = 0;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.bytCurrentPositions[2, 0] = 0;
            clsGame.bytCurrentPositions[2, 1] = playerType;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkVerticalSequenceFirstColumn(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[1, 0] = playerType;
            clsGame.bytCurrentPositions[2, 0] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 0);

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[1, 0] = 0;
            clsGame.bytCurrentPositions[2, 0] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 0);

            clsGame.bytCurrentPositions[0, 0] = 0;
            clsGame.bytCurrentPositions[1, 0] = playerType;
            clsGame.bytCurrentPositions[2, 0] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkVerticalSequenceSecondColumn(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[0, 1] = playerType;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 1] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.bytCurrentPositions[0, 1] = playerType;
            clsGame.bytCurrentPositions[1, 1] = 0;
            clsGame.bytCurrentPositions[2, 1] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.bytCurrentPositions[0, 1] = 0;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 1] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 1);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkVerticalSequenceThirdColumn(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[0, 2] = playerType;
            clsGame.bytCurrentPositions[1, 2] = playerType;
            clsGame.bytCurrentPositions[2, 2] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.bytCurrentPositions[0, 2] = playerType;
            clsGame.bytCurrentPositions[1, 2] = 0;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.bytCurrentPositions[0, 2] = 0;
            clsGame.bytCurrentPositions[1, 2] = playerType;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 2);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkDiagonalUpSequence(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[0, 2] = playerType;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 0] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 0);

            clsGame.bytCurrentPositions[0, 2] = playerType;
            clsGame.bytCurrentPositions[1, 1] = 0;
            clsGame.bytCurrentPositions[2, 0] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.bytCurrentPositions[0, 2] = 0;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 0] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 2);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkDiagonalDownSequence(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 2] = 0;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 2);
            Assert.AreEqual(nextMovePosition.PositionY, 2);

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[1, 1] = 0;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 1);
            Assert.AreEqual(nextMovePosition.PositionY, 1);

            clsGame.bytCurrentPositions[0, 0] = 0;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, 0);
            Assert.AreEqual(nextMovePosition.PositionY, 0);
        }

        [TestCase(1)]
        [TestCase(2)]
        public void checkNoSequence(byte playerType)
        {
            PictureBox picO = new PictureBox();
            clsGameplay clsGame;
            clsGame = new clsGameplay(picO);

            clsNextMovePosition nextMovePosition = new clsNextMovePosition();

            clsGame.bytCurrentPositions[0, 0] = playerType;
            clsGame.bytCurrentPositions[1, 1] = playerType;
            clsGame.bytCurrentPositions[2, 2] = playerType;

            clsGame.FindTwoInSequence(nextMovePosition, playerType);
            Assert.AreEqual(nextMovePosition.PositionX, clsGameplay.UNDEFINED_MOVE);
            Assert.AreEqual(nextMovePosition.PositionY, clsGameplay.UNDEFINED_MOVE);
        }
    }
}
