using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal class Player
{
    public string Name { get; set; }
    public Symbol Symbol { get; set; }
    public PlayerType PlayerType{ get; set; }

    public Player(string name, Symbol symbol, PlayerType playerType)
    {
        Name = name;
        Symbol = symbol;
        PlayerType = playerType;
    }

    public virtual Move MakeMove(Board board)
    {
        Console.WriteLine("Enter row: ");
        int row = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter column: ");
        int column = Convert.ToInt32(Console.ReadLine());

        return new Move(board.Grid[row - 1][column-1],  this);
    }
}
