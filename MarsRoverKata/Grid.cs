using System.Collections.Generic;
using System.Linq;

namespace MarsRoverKata
{
    public class Grid
    {
        private IEnumerable<Coordinate> _obstacles { get; }
        public int Height { get; }
        public int Width { get; }

        public Grid(int height, int width, IEnumerable<Coordinate> obstacles = null)
        {
            Height = height;
            Width = width;
            _obstacles = obstacles ?? Enumerable.Empty<Coordinate>();
        }

        public bool HitObstacle(Coordinate currentPosition)
        {
            return _obstacles.Any(obstacle => obstacle.X == currentPosition.X && obstacle.Y == currentPosition.Y);
        }
    }
}