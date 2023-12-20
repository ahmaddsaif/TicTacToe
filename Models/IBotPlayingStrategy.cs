using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal interface IBotPlayingStrategy
{
    Move MakeMove(Board board, Player player);
}
