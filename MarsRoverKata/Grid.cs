namespace MarsRoverKata
{
    public class Grid
    {
        private Coordinate _obstacle { get; }
        public int Height { get; }
        public int Width { get; }

        public Grid(int height, int width, Coordinate obstacle = null)
        {
            Height = height;
            Width = width;
            _obstacle = obstacle;
        }

        public bool HitObstacle(Coordinate currentPosition)
        {
            return currentPosition.X == _obstacle?.X && currentPosition.Y == _obstacle?.Y;
        }
    }
}