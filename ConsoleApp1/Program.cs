// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using ConsoleApp1;

public static class Program
{
    static void Main(string[] args)
    {
       
           //string[] inputLines = { "55", "12N", "LMLMLMLMM" };
        string[] inputLines = { "55", "24W", "RMLMRRM" };

        var result = Result.ValidationOk;

        if (result == Result.ValidationOk)
        {
            var marsRovers = new MarsRovers(inputLines);
            result = marsRovers.ExecuteMoves();
        }

    }

    

    
}