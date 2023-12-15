using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.BotPlayingStrategies;
using TicTacToe.Models;

namespace TicTacToe.Factories;
internal class PlayerFactory
{
    public static Bot CreateBot(DifficultyLevel difficultyLevel, string name, Symbol symbol)
    {
        return difficultyLevel switch
        {
            DifficultyLevel.Easy => new Bot(new EasyBotPlayingStrategy(), difficultyLevel, name, symbol),
            DifficultyLevel.MEdium => new Bot(new MediumBotPlayingStrategy(), difficultyLevel, name, symbol),
            DifficultyLevel.Hard => new Bot(new HardBotPlayingStrategy(), difficultyLevel, name, symbol),
            _ => throw new NotImplementedException()
        };
    }

    public static Player CreatePlayer(string name, Symbol symbol)
    {
        return new Player(name, symbol, PlayerType.Human);
    }
}
