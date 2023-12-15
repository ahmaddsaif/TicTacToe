// See https://aka.ms/new-console-template for more information
using TicTacToe.Factories;
using TicTacToe.Models;
using static TicTacToe.Models.Game;

Console.WriteLine("How many players?: ");
int playerCount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("How many bots?: ");
int botCount = Convert.ToInt32(Console.ReadLine());

List<Player> players = new List<Player>();
int i = 0;
for(i=0; i<botCount; i++)
{
    Console.WriteLine($"Diffuculty level of bot {i + 1} (Easy - 0, Medium - 1, Hard - 2): ");
    int difficulty = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine($"Symbol for bot {i + 1}: ");
    char symbol = Convert.ToChar(Console.ReadLine());

    Bot bot = PlayerFactory.CreateBot((DifficultyLevel)difficulty, $"Bot-{i+1}", new Symbol(symbol));
    players.Add(bot);
}

for(i=botCount; i<playerCount; i++)
{
    Console.WriteLine($"Name of player {i - botCount + 1}: ");
    string name = Console.ReadLine() ?? $"Player-{i - botCount + 1}";

    Console.WriteLine($"Symbol of plyayer {i - botCount + 1}: ");
    char symbol = Convert.ToChar(Console.ReadLine());

    Player player = new Player(name, new Symbol(symbol), PlayerType.Human);
    players.Add(player);
}

Console.WriteLine("How many winning strategies?: ");
int winningStrategyCount = Convert.ToInt32(Console.ReadLine());

List<IWinningStrategy> winningStrategies = new List<IWinningStrategy>();
for(int w=0; w<Math.Min(winningStrategyCount, 3); w++)
{
    Console.WriteLine($"Enter {w + 1}th winning strategy: ");
    Console.WriteLine("(0 - Row Winning, 1 - Column Winning, 2 - Diagonal Winning)");
    int winningStrategyNumber = Convert.ToInt32(Console.ReadLine());

    winningStrategies.Add(WinningStrategyFactory.CreateWinningStrategy((WinningStrategyName)winningStrategyNumber));
}

Game game = new GameBuilder()
    .WithDimensions(playerCount + 1)
    .WithPlayers(players)
    .WithStrategies(winningStrategies)
    .Build();

Console.WriteLine("Game created");

// Let's start the game

while(game.GameStatus == GameStatus.InProgress)
{
    game.MakeMove();
}