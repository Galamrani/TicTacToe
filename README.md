# Tic Tac Toe Game

This is a Tic Tac Toe game with unbeatable computer opponent implemented in C# using WPF for a responsive UI with animations.

## Description

The project consists of the following classes:

- `AiAlgorithm`: This class implements the AI algorithm for making the best move in the game. It uses the minimax algorithm with alpha-beta pruning to determine the optimal move.

- `GameLogic`: This class handles the game logic, including managing the game grid, current player, turns, and checking for a win or draw.

- `GameResult`: This class represents the result of a game, including the game winner and win information.

- `WinInfo`: This class represents the information about a win, including the winning player and the type of win (row, column, main diagonal, or anti-diagonal).

- `Player`: This enum represents the players in the game (X, O, or None).

- `App`: This is the entry point of the application.

- `MainWindow`: This is the main window of the application, where the game is played. It handles user interactions and displays the game grid.

## How to Play

1. Run the application.
2. The game starts with Player X.
3. Click on an empty cell in the grid to make a move.
4. The game continues until a player wins or the game ends in a draw.
5. To play again, click the "Play Again" button.

## Screenshots

<p float="left">
  <img src="Screenshots/Screenshot (3).png" width = "32%" />
  <img src="Screenshots/Screenshot (4).png" width = "32%" />
  <img src="Screenshots/Screenshot (5).png" width = "32%" />
</p>

https://user-images.githubusercontent.com/97801269/193064416-71fbe5d4-2a00-4a01-b469-98aef1e8b5bc.mp4

## Download

WPF is only available on Windows, so the game can run only on Windows machines.  
 You can download the game from the release sanction or just [click here](https://github.com/Galamrani/Tic-Tac-Toe-Game/releases)
    
## Computer Opponent Algorithm

The computer opponent algorithm used in this game is the minimax algorithm with alpha-beta pruning. The algorithm recursively explores all possible moves and assigns scores to each move. The computer opponent player (X) chooses the move with the maximum score, while the opponent player (O) chooses the move with the minimum score. The algorithm also uses depth to assign higher scores to moves that lead to a win in fewer turns.

## MiniMax algorithm
The computer player in the game is implemented by the MiniMax algorithm.  
  The MiniMax algorithm is used in decision-making, game theory.  
  It is used to find the optimal move for a player, assuming that the opponent is also playing optimally.  
    In the context of the game, we will see the computer Player blocking the User Player if necessary or making the best move for a winning opportunity.  
      <sub>
  for a better understanding of the MiniMax algorithm use those links : &emsp;[Article about MiniMax ](https://www.neverstopbuilding.com/blog/minimax), &ensp;[Video about MiniMax ](https://www.youtube.com/watch?v=l-hh51ncgDI&t=553s)

 </sub> 

#### some extra features :  
 
*  Shortest route - a depth variable that keeps track of how deep we are in the game tree.  
     the depth variable is taken under consideration when making an evaluacion between a parent node and his two children's 
       so even if the user player is not playing optimally the computer player will still play in an optimal way and look for the fastest way to win.  
         

*  Alpha-Beta pruning - an optimization technique for the MiniMax algorithm, it reduces the computation time by a huge factor, which allows us to search much faster and even go into deeper levels in the game tree.  
       it cuts off branches in the game tree which can be ignored, because there already exists a better move available.  
          as a result, the computation time reduces by a big and impactful factor.
