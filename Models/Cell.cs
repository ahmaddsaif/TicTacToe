using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal class Cell
{
    public Player Player { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }

    public Cell(int row, int column)
    {
        Row = row;
        Column = column;
    }

    internal bool isEmpty()
    {
        return this.Player == null;
    }
}
