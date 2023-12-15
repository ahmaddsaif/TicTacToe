using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.BotPlayingStrategies;
internal class EasyBotPlayingStrategy : IBotPlayingStrategy
{
    public Move MakeMove(Board board, Player player)
    {
        foreach(List<Cell> row in board.Grid)
        {
            foreach(Cell cell in row)
            {
                if(cell.isEmpty())
                {
                    return new Move(cell, player);
                }
            }
        }

        return null;
    }
}
