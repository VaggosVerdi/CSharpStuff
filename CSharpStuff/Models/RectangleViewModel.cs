namespace CSharpStuff.Models
{
    public class RectangleViewModel
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public string? BtnType { get; set; }
        public double Area() => Length * Width;
        public double Perimeter() => 2 * (Length +  Width);
        public double Result {  get; set; }
    }
}
