using static MarsRoverKata.RoverDirection;

namespace MarsRoverKata
{
    public class MarsRover
    {
        private Coordinate _coordinate = new Coordinate(0, 0);
        private RoverDirection _direction = North;
        private const int MaxHeight = 10;
        private const int MaxWidth = 10;

        public string Execute(string input)
        {
            foreach (var command in input)
            {
                if (command == 'L' || command == 'R')
                {
                    Turn(command);
                }

                if (command == 'M')
                {
                    _coordinate = Move();
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
                    x += 1;
                    if (x > MaxHeight) x = 0;
                    break;
                case South:
                    x -= 1;
                    if (x < 0) x = MaxHeight;
                    break;
                case East:
                    y += 1;
                    if (y > MaxWidth) y = 0;
                    break;
                case West:
                    y -= 1;
                    if (y < 0) y = MaxWidth;
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
                    return null;
            }
        }

        private void Turn(char command)
        {
            switch (_direction)
            {
                case North:
                    _direction = (command == 'L') ? West : East;
                    break;
                case West:
                    _direction = (command == 'L') ? South : North;
                    break;
                case South:
                    _direction = (command == 'L') ? East : West;
                    break;
                case East:
                    _direction = (command == 'L') ? North : South;
                    break;
            }
        }
    }
}
