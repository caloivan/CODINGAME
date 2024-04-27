using System;
using System.Linq; //Dictionary
using System.Collections.Generic;//Dictionary

class Player{
    public int number;
    public char sign;
    public List<int> opponents;
    public Player(string line)  {
        string[] inputs = line.Split(' ');
        number = int.Parse(inputs[0]);
        sign = char.Parse(inputs[1]);
        opponents = new List<int>();
    }
}

class Game{ 
        static Dictionary<char, char[]> combinations = new Dictionary<char, char[]>{
        ['C'] = new[] { 'P', 'L' },//  sCissors (C)  
        ['P'] = new[] { 'R', 'S' },//Paper (P) 
        ['R'] = new[] { 'L', 'C' },//Rock (R)
        ['L'] = new[] { 'S', 'P' },// Lizard (L)
        ['S'] = new[] { 'C', 'R' }// Spock (S)
    };

    public static Player VS(Player player1, Player player2) {
        player1.opponents.Add(player2.number);
        player2.opponents.Add(player1.number);
        return  player1.sign == player2.sign?                       player1.number < player2.number ? player1 : player2:
                combinations[player1.sign].Contains(player2.sign)?  player1:
                                                                    player2;
    }

    public static Player Tournament(List<Player> players)   {
        if (players.Count == 1)    return players[0];
        List<Player> nextRound = new List<Player>();
        for (int i = 0; i < players.Count; i += 2) {
            Player winner = VS(players[i], players[i+1]);
            nextRound.Add(winner);
        }
        return Tournament(nextRound);//Recursivity until 1 Player is returned
    }
}

class Solution{
    static void Main(string[] args)   {
        int N = int.Parse(Console.ReadLine());
        List<Player> players = new List<Player>();
        for (int i = 0; i < N; i++)
            players.Add(new Player(Console.ReadLine()));
        Player winner = Game.Tournament(players);
        Console.WriteLine(winner.number);
        Console.WriteLine(string.Join(" ", winner.opponents));
    }
}
