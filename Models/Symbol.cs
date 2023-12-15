using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal class Symbol
{
    public char Name { get; set; }
    public Symbol(char name)
    {
        Name = name;
    }
}
