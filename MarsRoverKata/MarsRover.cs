using System;
using static MarsRoverKata.RoverDirection;

namespace MarsRoverKata
{
    public class MarsRover
    {
        private Coordinate _coordinate = new Coordinate(0, 0);
        private RoverDirection _direction = North;
        private readonly Grid _grid;
        private bool _obstacleHit;

        public MarsRover(Grid grid)
        {
            _grid = grid;
        }

        public string Execute(string input)
        {
            foreach (var command in input)
            {
                if (command == 'L' || command == 'R')
                {
                    _direction = Turn(command);
                }

                if (command == 'M')
                {
                    _coordinate = Move();
                    if (_obstacleHit) return $"O:{_coordinate.X}:{_coordinate.Y}:{Direction()}";
                }
            }

            return $"{_coordinate.X}:{_coordinate.Y}:{Direction()}";
        }

        private Coordinate Move()
        {
            var x = _coordinate.X;
            var y = _coordinate.Y;

            switch (_direction)
            {
                case North:
                    if (_grid.HitObstacle(new Coordinate(x + 1, y)))
                    {
                        _obstacleHit = true;
                    } else {
                        x = x + 1 > _grid.Height ? 0 : x + 1;
                    }
                    break;
                case South:
                    if (_grid.HitObstacle(new Coordinate(x - 1, y)))
                    {
                        _obstacleHit = true;
                    } else {
                        x = x - 1 < 0 ? _grid.Height : x - 1;
                    }
                    break;
                case East:
                    if (_grid.HitObstacle(new Coordinate(x, y + 1)))
                    {
                        _obstacleHit = true;
                    } else {
                        y = y + 1 > _grid.Width ? 0 : y + 1;
                    }
                    break;
                case West:
                    if (_grid.HitObstacle(new Coordinate(x, y - 1)))
                    {
                        _obstacleHit = true;
                    } else {
                        y = y - 1 < 0 ? _grid.Width : y - 1;
                    }
                    break;
            }

            return new Coordinate(x, y);
        }

        private string Direction()
        {
            switch (_direction)
            {
                case North:
                    return "N";
                case West:
                    return "W";
                case South:
                    return "S";
                case East:
                    return "E";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private RoverDirection Turn(char command)
        {
            switch (_direction)
            {
                case North:
                    return command == 'L' ? West : East;
                case West:
                    return command == 'L' ? South : North;
                case South:
                    return command == 'L' ? East : West;
                case East:
                    return command == 'L' ? North : South;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
