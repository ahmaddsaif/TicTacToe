using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal class Board
{
    public int Dimensions { get; set; }
    public List<List<Cell>> Grid { get; set; }

    public Board(int dimensions)
    {
        Dimensions = dimensions;

        Grid = new List<List<Cell>>();

        for(int i = 0; i < Dimensions; i++)
        {
            List<Cell> row = new List<Cell>();
            for(int j = 0; j < Dimensions; j++)
            {
                row.Add(new Cell(i, j));
            }
            Grid.Add(row);
        }
    }

    internal void Display()
    {
        foreach(List<Cell> row in Grid)
        {
            Console.WriteLine();
            foreach(Cell cell in row)
            {
                if(cell.Player == null)
                    Console.Write("- ");
                else
                    Console.Write(cell.Player.Symbol.Name + " ");
            }
        }
        Console.WriteLine();
        Console.WriteLine();
    }
}
