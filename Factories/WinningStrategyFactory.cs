using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Models;
using TicTacToe.WinningStrategies;

namespace TicTacToe.Factories;
internal class WinningStrategyFactory
{
    public static IWinningStrategy CreateWinningStrategy(WinningStrategyName winningStrategyName)
    {
        return winningStrategyName switch
        {
            WinningStrategyName.Row => new RowWinningStrategy(),
            WinningStrategyName.Column => new ColumnWinningStrategy(),
            WinningStrategyName.Diagonal => new DiagonalWinningStrategy(),
            _ => new RowWinningStrategy()
        };
    }
}
