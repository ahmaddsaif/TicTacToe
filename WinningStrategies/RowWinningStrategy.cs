using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.WinningStrategies;
internal class RowWinningStrategy : IWinningStrategy
{
    public bool Check(Board board, Move potentialMove)
    {
        return false;
    }
}
