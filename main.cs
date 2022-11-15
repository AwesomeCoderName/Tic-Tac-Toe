using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    Program game = new Program();
    game.judgement();
  }

  private int[] conquered = int[5]; // Might make this an attribute of player class
  // During the game when a player pressed a button that buttons number will be added to this list
  private int[ , ] winner = { {1,2,3}, {4,5,6}, {7,8,9},
                              {1,4,7}, {2,5,8}, {3,6,9},
                              {1,5,9}, {3,5,7}};

  List<string> winningConditions;
  
  // Make an attribue to each player win method: win();
  // When a player pressed a certain button it adds that number to the places array
  public void judgement() { 
    for (int row = 0; row < winningConditions.length; row++) {
      bool[] miniJudge = {false,false,false};
      for (int col = 0; col < winningConditions[row]; col++) {
        if (whoIsPlaying.Conquered.Contains(winningConditions[row][col]) {
          miniJudge[col] = true;
        }
      }
    }
  }
}
