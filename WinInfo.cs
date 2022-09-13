

namespace TicTacToeGame
{
    public class WinInfo
    {

        public enum WinType
        {
            row, col, mainDiag, antiDiag
        }

        public Player Winner { get; set; }
        public int WinTypeNum { get; set; }
        public WinType WinTypeKey { get; set; }

    }
}
