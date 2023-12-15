using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal interface IWinningStrategy
{
    public bool Check(Board board, Move potentialMove);
}
