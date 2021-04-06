using System.Drawing;

namespace BLSnakeLibrary
{
    public interface IGraphicElement
    {
        Coordinate Coord { get; }

        char Symbol { get; }

        Image Picture { get; }

        int PictureSize { get; }
    }
}
