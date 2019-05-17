using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarsRoverKata.RoverDirection;

namespace MarsRoverKata
{
    public class MarsRover
    {
        private RoverDirection _direction = RoverDirection.North;
        public string Execute(string input)
        {
            for (var i = 0; i < input.Length; i++)
            { 
                CalculateDirection();
            }

            return CalculatePosition();
        }

        private string CalculatePosition()
        {
            switch (_direction)
            {
                case RoverDirection.North:
                    return "N";
                case RoverDirection.West:
                    return "W";
                case RoverDirection.South:
                    return "S";
                case RoverDirection.East:
                    return "E";
                default:
                    return null;
            }
        }

        private void CalculateDirection()
        {
            switch (_direction)
            {
                case RoverDirection.North:
                    _direction = RoverDirection.West;
                    break;
                case RoverDirection.West:
                    _direction = RoverDirection.South;
                    break;
                case RoverDirection.South:
                    _direction = RoverDirection.East;
                    break;
                default:
                    _direction = RoverDirection.North;
                    break;
            }
        }
    }

    public enum RoverDirection
    {
        North,
        South,
        East,
        West, 
    }
}
