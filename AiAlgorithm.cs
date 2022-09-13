using System;
using System.Collections.Generic;


namespace TicTacToeGame
{
    public class AiAlgorithm
    {
        private int Row;
        private int Column;

        private readonly Dictionary<Player, int> scores = new Dictionary<Player, int>
        {
            { Player.X , 10 },
            { Player.O , -10 },
            { Player.None , 0 }
        };


        public (int, int) MakeBestMove(Player[,] GameGrid, int turnPassed)
        {
            double eval;
            double maxEval = double.NegativeInfinity;
            if (turnPassed == 9)
            {
                return (-1, -1);
            }
            else
            {
                for (int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        if (GameGrid[r, c] == Player.None)
                        {
                            GameGrid[r, c] = Player.X;
                            eval = MiniMax(GameGrid, turnPassed, false, double.NegativeInfinity, double.PositiveInfinity, 0);
                            GameGrid[r, c] = Player.None;

                            if (eval > maxEval)
                            {
                                maxEval = eval;
                                Row = r;
                                Column = c;
                            }
                        }
                    }
                }
                return (Row, Column);
            }
        }


        private double MiniMax(Player[,] GameGrid, int turnPassed, bool maximizinPlayer, double alpha, double beta, double depth)
        {

            Player winner = WinnerCheck(GameGrid);
            double eval;

            if (turnPassed == 9 || winner != Player.None)
            {
                return scores[winner];
            }

            if (maximizinPlayer)
            {
                double maxEval = double.NegativeInfinity;
                for (int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        if (GameGrid[r, c] == Player.None)
                        {
                            GameGrid[r, c] = Player.X;
                            eval = MiniMax(GameGrid, turnPassed + 1, false, alpha, beta, depth + 1);
                            GameGrid[r, c] = Player.None;
                            maxEval = Math.Max(eval, maxEval);
                            alpha = Math.Max(eval, alpha);
                            if (beta <= alpha) { break; }
                        }
                    }
                }
                return maxEval - depth;
            }
            else
            {
                double minEval = double.PositiveInfinity;
                for (int r = 0; r < 3; r++)
                {
                    for (int c = 0; c < 3; c++)
                    {
                        if (GameGrid[r, c] == Player.None)
                        {
                            GameGrid[r, c] = Player.O;
                            eval = MiniMax(GameGrid, turnPassed + 1, true, alpha, beta, depth + 1);
                            GameGrid[r, c] = Player.None;
                            minEval = Math.Min(minEval, eval);
                            alpha = Math.Min(eval, alpha);
                            if (beta <= alpha) { break; }
                        }
                    }
                }
                return minEval - depth;
            }
        }


        private Player WinnerCheck(Player[,] GameGrid)
        {

            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    if (GameGrid[r, 0] == GameGrid[r, 1] && GameGrid[r, 1] == GameGrid[r, 2])
                    {
                        return GameGrid[r, 0];
                    }
                    else if (GameGrid[0, c] == GameGrid[1, c] && GameGrid[1, c] == GameGrid[2, c])
                    {
                        return GameGrid[0, c];
                    }
                    else if (GameGrid[0, 0] == GameGrid[1, 1] && GameGrid[1, 1] == GameGrid[2, 2])
                    {
                        return GameGrid[0, 0];
                    }
                    else if (GameGrid[0, 2] == GameGrid[1, 1] && GameGrid[1, 1] == GameGrid[2, 0])
                    {
                        return GameGrid[0, 2];
                    }
                }
            }

            return Player.None;
        }
    }
}
