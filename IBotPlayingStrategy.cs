using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe;
internal interface IBotPlayingStrategy
{
    Move MakeMove(Board board, Player player);
}
