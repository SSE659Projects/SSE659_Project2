using System;
using System.Collections.Generic;
using System.Text;

namespace CS_TickTackToe
{
    public class clsNextMovePosition
    {
        private byte m_positionX;
        private byte m_positionY;

        public clsNextMovePosition()
        {
            PositionX = clsGameplay.UNDEFINED_MOVE;
            PositionY = clsGameplay.UNDEFINED_MOVE;
        }

        public byte PositionX
        {
            set { m_positionX = value; }
            get { return m_positionX; }
        }

        public byte PositionY
        {
            set { m_positionY = value; }
            get { return m_positionY; }
        }

        public bool IsNextMoveDefined()
        {
            return (PositionX != clsGameplay.UNDEFINED_MOVE && PositionY != clsGameplay.UNDEFINED_MOVE);
        }
    }
}
