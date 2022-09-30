# Tic-Tac-Toe-Game
Tic-Tac-Toe game with unbeatable AI, implemented by MiniMax algorithm , written in C#, using WPF for a responsive UI with animations.

## How the game looks like 
- player X -->  AI player  
- player O -->  User player 
 
  
<p float="left">
  <img src="Screenshots/Screenshot (3).png" width = "32%" />
  <img src="Screenshots/Screenshot (4).png" width = "32%" />
  <img src="Screenshots/Screenshot (5).png" width = "32%" />
</p>

https://user-images.githubusercontent.com/97801269/193064416-71fbe5d4-2a00-4a01-b469-98aef1e8b5bc.mp4

## How to download
----- need to add ----

## About the game
The game is played on a 3 × 3 grid.  
  Players take turns placing a mark in one of the cells of the grid.  
    The goal of the game is for players to position their marks so that they make a continuous line of three cells vertically, horizontally, or diagonally.

## MiniMax algorithm
The MiniMax algorithm used in decision making, game theory and artificial intelligence (AI).  
  It is used to find the optimal move for a player, assuming that the opponent is also playing optimally.  
    In the context of the game we will see the AI Player blocking the User Player if necessary or making the best move for a winning opportunity.
    
[Article about MiniMax ](https://www.neverstopbuilding.com/blog/minimax)
[Video about MiniMax ](https://www.youtube.com/watch?v=l-hh51ncgDI&t=553s)

---- need to fix the features explanation ---

#### I added to the algorithm some extra features :  
  
1. Shortest route - so even if the user player is not playing optimally the AI player will still play in an optimally  way and look for the fastest way to win.

2. Alpha-Beta pruning - an optimization technique for the minimax algorithm, it reduces the computation time by a huge factor, this allows us to search much faster and even go into deeper levels in the game tree.
  it cuts off branches in the game tree which need not be searched because there already exists a better move available. It is called Alpha-Beta pruning because it       passes 2 extra parameters in the minimax function, namely alpha and beta.
  
  Alpha is the best value that the maximizer currently can guarantee at that level or above.  
    Beta is the best value that the minimizer currently can guarantee at that level or above.
