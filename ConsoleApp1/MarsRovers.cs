using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MarsRovers
    {
        private readonly string _movesList;
        private string _currentDirection;
        private (int, int) _currentPosition;
        private readonly (int, int) _startPosition;
        private readonly string _startDirection;

        public MarsRovers(string[] inputLines)
        {
            
            _movesList = inputLines[2];
            //_movesList = inputLines[2].ToCharArray()[2].ToString();
            _startPosition = ParseSetupLineInPosition(inputLines[1]);
            //_startDirection = inputLines[1].Trim().Split(' ')[2];
            _startDirection = inputLines[1].ToCharArray()[2].ToString();
            Console.WriteLine("Start Position : " + _startPosition  + "\nStart Direction : "+ _startDirection + "\nMove List : " + _movesList );
            Console.ReadLine();
        }

        public static (int, int) ParseSetupLineInPosition(string line)
        {
           
            return (int.Parse(line.ToCharArray()[0].ToString()), int.Parse(line.ToCharArray()[1].ToString()));
        }
        public Result ExecuteMoves()
        {
            var result = Result.TurtleLost;
            _currentPosition = _startPosition;
            _currentDirection = _startDirection;

            foreach (var line in _movesList)
            {
                foreach (var move in line.ToString())
                {
                    switch (move)
                    {
                        case 'M':
                           
                                result = Move();
                           
                            break;
                        case 'R':
                            RotateRight(); break;
                        case 'L':
                            RotateLeft(); break;
                    }
                }
            }
            Console.WriteLine(_currentPosition + ""  + _currentDirection);
            return result;
        }
        private Result Move()
        {
            // update current position values and compare with mines list & exit in here
            switch (_currentDirection)
            {
                case "N":
                    _currentPosition.Item2++; break;
                case "S":
                    _currentPosition.Item2--; break;
                case "E":
                    _currentPosition.Item1++; break;
                case "W":
                    _currentPosition.Item1--; break;
            }

            var result = CheckIfStillInGrid();
          
            return result;
        }
        private Result CheckIfStillInGrid()
        {
            if (_currentPosition.Item1 < 0 ||
                _currentPosition.Item2 < 0 ||
                _currentPosition.Item1 >= 5 ||
                _currentPosition.Item2 >= 5)
                return Result.TurtleOutside;

            return Result.TurtleLost;
        }
        private void RotateRight()
        {
            _currentDirection = _currentDirection switch
            {
                "N" => "E",
                "S" => "W",
                "E" => "S",
                "W" => "N",
                _ => throw new System.NotImplementedException(),
            };
        }

        private void RotateLeft()
        {
            _currentDirection = _currentDirection switch
            {
                "N" => "W",
                "S" => "E",
                "E" => "N",
                "W" => "S",
                _ => throw new System.NotImplementedException(),
            };
        }

       
    }

   

}
