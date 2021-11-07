

namespace OOP_GB.Inheritance
{
    public struct Size
    {
        public float Height { get; set; }
        public float Width { get; set; }


        public Size(float height, float width)
        {
            Height = height;
            Width = width;
        }


        public static Size operator ++(Size size) => new Size(++size.Height, ++size.Width);

        public static Size operator --(Size size)
        {
            float sizeHeight = size.Height, sizeWidth = size.Width;
            return --sizeHeight < 0 || --sizeWidth < 0 ? size : new Size(sizeHeight, sizeWidth);
        }
    }
}
