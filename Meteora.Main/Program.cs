// See https://aka.ms/new-console-template for more information
using Meteora.Main;
using Meteora.Main.Model;
using Meteora.Main.Utils;

var user = new User();
var userInterface = new ConsoleInterface();
var vowels = Letters.Vowels.ToList();

var gameEngine = new GameEngine(user, userInterface, vowels);
gameEngine.Run();