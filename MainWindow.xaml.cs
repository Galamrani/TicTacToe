using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;


namespace TicTacToeGame
{



    public partial class MainWindow : Window
    {

        private readonly Dictionary<Player, ImageSource> imageSources = new Dictionary<Player, ImageSource>
        {
            { Player.X , new BitmapImage(new Uri("pack://application:,,,/Images/X15.png")) },
            { Player.O , new BitmapImage(new Uri("pack://application:,,,/Images/O15.png")) },
            { Player.None, null }
        };

        private readonly Dictionary<Player, ObjectAnimationUsingKeyFrames> animations = new Dictionary<Player, ObjectAnimationUsingKeyFrames>
        {
            { Player.X , new ObjectAnimationUsingKeyFrames() },
            { Player.O , new ObjectAnimationUsingKeyFrames() },
        };

        private readonly Image[,] imageControlsArry = new Image[3, 3];
        private readonly GameLogic gameLogic = new GameLogic();



        public MainWindow()
        {
            InitializeComponent();
            SetUpGameGrid();
            SetUpAnimations();
            OnGameRestart();
        }


        private void SetUpAnimations()
        {
            animations[Player.X].Duration = TimeSpan.FromSeconds(.25);
            animations[Player.O].Duration = TimeSpan.FromSeconds(.25);

            for (int i = 0; i < 16; i++)
            {
                Uri xUri = new Uri($"pack://application:,,,/Images/X{i}.png");
                BitmapImage xImg = new BitmapImage(xUri);
                DiscreteObjectKeyFrame xKeyFrame = new DiscreteObjectKeyFrame(xImg);
                animations[Player.X].KeyFrames.Add(xKeyFrame);

                Uri oUri = new Uri($"pack://application:,,,/Images/O{i}.png");
                BitmapImage oImg = new BitmapImage(oUri);
                DiscreteObjectKeyFrame oKeyFrame = new DiscreteObjectKeyFrame(oImg);
                animations[Player.O].KeyFrames.Add(oKeyFrame);
            }
        }


        private async void GameFlow(int r, int c)
        {
            if (gameLogic.PlayerMakeMove(r, c) && !gameLogic.GameOver)
            {
                OnMoveMade(r, c);
                await Task.Delay(400);
                gameLogic.AiMakeMove();
                if (!gameLogic.GameOver)
                {
                    OnMoveMade(gameLogic.AiRow, gameLogic.AiColumn);
                }
                else
                {
                    OnMoveMade(gameLogic.AiRow, gameLogic.AiColumn);
                    OnGameEnded(gameLogic.GetGameResult());
                }
            }
            else if (gameLogic.GameOver)
            {
                OnMoveMade(r, c);
                OnGameEnded(gameLogic.GetGameResult());
            }
        }


        private void GameGrid_Click(object sender, MouseButtonEventArgs e)
        {
            if (gameLogic.CurrentPlayer != Player.O) { return; }

            double squareSize = GameGrid.Width / 3;
            Point clickPosition = e.GetPosition(GameGrid);
            int row = (int)(clickPosition.Y / squareSize);
            int col = (int)(clickPosition.X / squareSize);

            GameFlow(row, col);
        }


        private (Point, Point) FindLinePoints(WinInfo winInfo)
        {
            double squareSize = GameGrid.Width / 3;
            double margin = squareSize / 2;

            if (winInfo.WinTypeKey == WinInfo.WinType.row)
            {
                double y = winInfo.WinTypeNum * squareSize + margin;
                return (new Point(0, y), new Point(GameGrid.Width, y));
            }
            if (winInfo.WinTypeKey == WinInfo.WinType.col)
            {
                double x = winInfo.WinTypeNum * squareSize + margin;
                return (new Point(x, 0), new Point(x, GameGrid.Height));
            }
            if (winInfo.WinTypeKey == WinInfo.WinType.mainDiag)
            {
                return (new Point(0, 0), new Point(GameGrid.Width, GameGrid.Height));
            }

            return (new Point(GameGrid.Width, 0), new Point(0, GameGrid.Height));

        }


        private void ShowLine(WinInfo winInfo)
        {
            (Point start, Point end) = FindLinePoints(winInfo);

            Line.X1 = start.X;
            Line.Y1 = start.Y;
            Line.X2 = end.X;
            Line.Y2 = end.Y;

            Line.Visibility = Visibility.Visible;

        }


        private void OnMoveMade(int r, int c)
        {
            Player player = gameLogic.GameGrid[r, c];
            imageControlsArry[r, c].BeginAnimation(Image.SourceProperty, animations[player]);
            PlayerImage.Source = imageSources[gameLogic.CurrentPlayer];
        }


        private async void OnGameEnded(GameResult gameResult)
        {
            await Task.Delay(800);

            if (gameResult.GameWinner == Player.None)
            {
                TransitionToEndScreen("it's a draw", null);
            }
            else
            {
                ShowLine(gameResult.WinInfo);
                await Task.Delay(1000);
                TransitionToEndScreen("The Winner: ", imageSources[gameResult.GameWinner]);
            }
        }


        private async void OnGameRestart()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    imageControlsArry[r, c].BeginAnimation(Image.SourceProperty, null);
                    imageControlsArry[r, c].Source = null;
                }
            }

            PlayerImage.Source = imageSources[gameLogic.CurrentPlayer];
            TransitionToGameScreen();
            gameLogic.AiMakeMove();
            await Task.Delay(80);
            OnMoveMade(gameLogic.AiRow, gameLogic.AiColumn);

        }


        private void SetUpGameGrid()
        {
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Image imageControl = new Image();
                    GameGrid.Children.Add(imageControl);
                    imageControlsArry[r, c] = imageControl;
                }
            }
        }


        private void TransitionToEndScreen(string text, ImageSource winnerImage)
        {
            TurnPanel.Visibility = Visibility.Hidden;
            GameCanvas.Visibility = Visibility.Hidden;
            ResultText.Text = text;
            WinnerImage.Source = winnerImage;
            EndScreen.Visibility = Visibility.Visible;
        }


        private void TransitionToGameScreen()
        {
            Line.Visibility = Visibility.Hidden;
            EndScreen.Visibility = Visibility.Hidden;
            TurnPanel.Visibility = Visibility.Visible;
            GameCanvas.Visibility = Visibility.Visible;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gameLogic.Reset();
            OnGameRestart();
        }

    }
}
