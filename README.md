# Tic Tac Toe Game

Welcome to the Tic Tac Toe Game! This C# application features an unbeatable computer opponent implemented in WPF, offering a responsive UI with smooth animations.

## Components

The project consists of the following classes:

- `ComputerPlayer`: This class implements the unbeatable computer opponent algorithm for making the best move in the game. It uses the minimax algorithm with alpha-beta pruning to determine the optimal move.

- `GameLogic`: This class handles the game logic, including managing the game grid, current player, turns, and checking for a win or draw.

- `GameResult`: This class represents the result of a game, including the game-winner and win information.

- `WinInfo`: This class represents the information about a win, including the winning player and the type of win (row, column, main diagonal, or anti-diagonal).

- `Player`: This enum represents the players in the game (X, O, or None).

- `App`: This is the entry point of the application.

- `MainWindow`: This is the main window of the application, where the game is played. It handles user interactions and displays the game grid.

## Screenshots

<p float="left">
  <img src="Screenshots/Screenshot (3).png" width = "32%" />
  <img src="Screenshots/Screenshot (4).png" width = "32%" />
  <img src="Screenshots/Screenshot (5).png" width = "32%" />
</p>

https://user-images.githubusercontent.com/97801269/193064416-71fbe5d4-2a00-4a01-b469-98aef1e8b5bc.mp4

## Download

Note: The game is compatible only with Windows machines due to its WPF implementation. 
Download the latest release [click here](https://github.com/Galamrani/Tic-Tac-Toe-Game/releases)
    
## Computer Opponent Algorithm

The unbeatable computer opponent is powered by the minimax algorithm with alpha-beta pruning, incorporating dynamic programming for efficient decision-making. 
  This algorithm explores all possible moves, assigns scores to each move, and ensures optimal decision-making. 
    The depth parameter influences scoring, favoring moves that lead to victory in fewer turns.

## MiniMax algorithm
The MiniMax algorithm employed in the game is pivotal for optimal decision-making in game theory. 
  It guides the computer player to make strategic moves, blocking the user player when needed and seeking the fastest route to victory.
    For a deeper understanding of the MiniMax algorithm:  
      <sub>
  for a better understanding of the MiniMax algorithm use those links: &emsp;[Article about MiniMax ](https://www.neverstopbuilding.com/blog/minimax), &ensp;[Video about MiniMax ](https://www.youtube.com/watch?v=l-hh51ncgDI&t=553s)

 </sub> 

#### extra features :  
 
*  Shortest route - A depth variable optimizes the game tree traversal, ensuring optimal play even if the user doesn't.  
         
*  Alpha-Beta pruning - An optimization technique for MiniMax, significantly reducing computation time by cutting off unnecessary branches in the game tree.
