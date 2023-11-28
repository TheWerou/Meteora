// See https://aka.ms/new-console-template for more information
using Meteora.Main;

var user = new User();
var userInterface = new ConsoleInterface();

var gameEngine = new GameEngine(user, userInterface);
gameEngine.Run();