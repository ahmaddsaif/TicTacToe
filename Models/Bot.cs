using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal class Bot : Player
{
    private readonly IBotPlayingStrategy _botPlayingStrategy;
    public DifficultyLevel DifficultyLevel { get; set; }

    public Bot(IBotPlayingStrategy botPlayingStrategy, DifficultyLevel difficultyLevel, string name, Symbol symbol) : 
        base(name, symbol, PlayerType.Bot)
    {
        _botPlayingStrategy = botPlayingStrategy;
        DifficultyLevel = difficultyLevel;
    }

    public override Move MakeMove(Board board)
    {
        return _botPlayingStrategy.MakeMove(board, this);
    }
}
