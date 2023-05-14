# Tic-Tac-Toe-Game
Tic-Tac-Toe game with unbeatable computer opponent, implemented by MiniMax algorithm, written in C#, using WPF for a responsive UI with animations.


## How the game looks like 
- player X -->  Computer player  
- player O -->  User player 
 
  
<p float="left">
  <img src="Screenshots/Screenshot (3).png" width = "32%" />
  <img src="Screenshots/Screenshot (4).png" width = "32%" />
  <img src="Screenshots/Screenshot (5).png" width = "32%" />
</p>

https://user-images.githubusercontent.com/97801269/193064416-71fbe5d4-2a00-4a01-b469-98aef1e8b5bc.mp4

## Download
WPF is only available on Windows, so the game can run only on Windows machines.  
  You can download the game from the release sanction or just [click here](https://github.com/Galamrani/Tic-Tac-Toe-Game/releases)
  
  
## About the game
The game is played on a 3 × 3 grid.  
  Players take turns placing a mark in one of the cells of the grid.  
    The computer player will always play the first turn.  
      The goal of the game is for players to position their marks so that they make a continuous line of three cells vertically, horizontally, or diagonally.  

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
