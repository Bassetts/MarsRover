using MarsRover;

const string input = @"5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM";

var rovers = InputParser.ParseInput(input);
var coordinator = new Coordinator(rovers);
var results = coordinator.Execute();
foreach (var result in results) Console.WriteLine(result);