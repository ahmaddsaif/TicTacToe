using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Models;
internal class Game
{
    public List<Player> Players { get; set; } // Players of the game
    public List<Move> Moves { get; set; } // Moves that have been made so far
    public Board Board { get; set; } // Board associated to the game
    public List<IWinningStrategy> WinningStrategies { get; set; }
    public int LastMovePlayerIndex { get; set; }
    public GameStatus GameStatus { get; set; }
    public Player Winner { get; set; }

    private int _filledCells = 0;

    private Game() { }

    public class GameBuilder
    {
        private List<Player> _players;
        private int _dimensions;
        List<IWinningStrategy> _winningStrategies;

        public GameBuilder WithPlayers(List<Player> players)
        {
            this._players = players;
            return this;
        }

        public GameBuilder WithDimensions(int dimensions)
        {
            this._dimensions = dimensions;
            return this;
        }

        public GameBuilder WithStrategies(List<IWinningStrategy>  winningStrategies)
        {
            this._winningStrategies = winningStrategies;
            return this;
        }

        public Game Build()
        {
            Game game = new Game();
            game.Players = _players;
            game.WinningStrategies = _winningStrategies;
            game.Board = new Board(_dimensions);
            game.LastMovePlayerIndex = -1;
            game.GameStatus = GameStatus.InProgress;
            game.Moves = new List<Move>();

            return game;
        }
    }

    public void MakeMove()
    {
        this.Board.Display();

        LastMovePlayerIndex++;
        LastMovePlayerIndex %= Players.Count;

        Console.WriteLine($"{this.Players[LastMovePlayerIndex].Name}'s turn");

        Move potentialMove = Players[LastMovePlayerIndex].MakeMove(this.Board);

        Cell cell = this.Board.Grid[potentialMove.Cell.Row][potentialMove.Cell.Column];

        if(cell.Player != null)
        {
            Console.WriteLine("Bad move! Try again");
            LastMovePlayerIndex--;
            return;
        }

        this.Moves.Add(potentialMove);

        cell.Player = this.Players[LastMovePlayerIndex];

        _filledCells++;

        foreach (IWinningStrategy strategy in this.WinningStrategies)
        {
            if (strategy.Check(this.Board, potentialMove))
            {
                this.GameStatus = GameStatus.Finished;
                this.Winner = this.Players[LastMovePlayerIndex];
                return;
            }
        }

        if(_filledCells == Board.Dimensions*Board.Dimensions)
        {
            this.GameStatus = GameStatus.Draw;
        }
    }
}
