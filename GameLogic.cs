

using TicTacToe;

namespace TicTacToe
{
    public class GameLogic
    {

        public Player[,] GameGrid { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public int TurnPassed { get; private set; }
        public bool GameOver { get; private set; }
        public int CoRow { get; private set; }
        public int CoColumn { get; private set; }
        ComputerPlayer CoAlgorithm;
        WinInfo winInfo;
        GameResult gameResult;


        public GameLogic()
        {
            CoAlgorithm = new ComputerPlayer();
            GameGrid = new Player[3, 3];
            winInfo = new WinInfo();
            gameResult = new GameResult();

            CurrentPlayer = Player.X;
            TurnPassed = 0;
            GameOver = false;
        }


        public GameResult GetGameResult()
        {
            return gameResult;
        }


        public void Reset()
        {
            CoAlgorithm = new ComputerPlayer();
            GameGrid = new Player[3, 3];
            winInfo = new WinInfo();
            gameResult = new GameResult();

            CurrentPlayer = Player.X;
            TurnPassed = 0;
            GameOver = false;
        }


        public void CoMakeMove()
        {
            (int, int) coordinates = CoAlgorithm.MakeBestMove(GameGrid, TurnPassed);
            int row = coordinates.Item1;
            int col = coordinates.Item2;

            if (!(row == -1 && col == -1))
            {
                CoRow = row;
                CoColumn = col;
                GameGrid[row, col] = CurrentPlayer;
                TurnPassed++;
            }

            if (DidMoveEndGame(row, col, ref gameResult))
            {
                GameOver = true;
            }
            else
            {
                SwitchPlayer();
            }
        }


        public bool PlayerMakeMove(int r, int c)
        {
            if (!CanMakeMove(r, c))
            {
                return false;
            }

            GameGrid[r, c] = CurrentPlayer;
            TurnPassed++;

            if (DidMoveEndGame(r, c, ref gameResult))
            {
                GameOver = true;
            }
            else
            {
                SwitchPlayer();
            }

            return true;
        }


        private bool CanMakeMove(int r, int c)
        {
            return GameGrid[r, c] == Player.None && !GameOver;
        }


        private bool IsGridFull()
        {
            return TurnPassed == 9;
        }


        private void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Player.X ? CurrentPlayer = Player.O : CurrentPlayer = Player.X);
        }


        private bool AreSquaresMarked((int, int)[] WinningCombo, Player player)
        {
            foreach ((int r, int c) in WinningCombo)
            {
                if (GameGrid[r, c] != player)
                {
                    return false;
                }
            }
            return true;
        }


        private bool DidMoveWin(int r, int c, ref WinInfo winInfo)
        {
            (int, int)[] row = new[] { (r, 0), (r, 1), (r, 2) };
            (int, int)[] col = new[] { (0, c), (1, c), (2, c) };
            (int, int)[] mainDiag = new[] { (0, 0), (1, 1), (2, 2) };
            (int, int)[] antiDiag = new[] { (0, 2), (1, 1), (2, 0) };

            if (AreSquaresMarked(row, CurrentPlayer))
            {
                winInfo = new WinInfo { Winner = CurrentPlayer, WinTypeNum = r, WinTypeKey = WinInfo.WinType.row };
                return true;
            }
            if (AreSquaresMarked(col, CurrentPlayer))
            {
                winInfo = new WinInfo { Winner = CurrentPlayer, WinTypeNum = c, WinTypeKey = WinInfo.WinType.col };
                return true;
            }
            if (AreSquaresMarked(mainDiag, CurrentPlayer))
            {
                winInfo = new WinInfo { Winner = CurrentPlayer, WinTypeKey = WinInfo.WinType.mainDiag };
                return true;
            }
            if (AreSquaresMarked(antiDiag, CurrentPlayer))
            {
                winInfo = new WinInfo { Winner = CurrentPlayer, WinTypeKey = WinInfo.WinType.antiDiag };
                return true;
            }

            return false;
        }


        private bool DidMoveEndGame(int r, int c, ref GameResult gameResult)
        {
            if (DidMoveWin(r, c, ref winInfo))
            {
                gameResult.WinInfo = winInfo;
                gameResult.GameWinner = CurrentPlayer;
                return true;
            }
            if (IsGridFull())
            {
                gameResult.GameWinner = Player.None;
                return true;
            }

            return false;
        }

    }
}














