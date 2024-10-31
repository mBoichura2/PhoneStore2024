namespace UI.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int ColorId { get; set; }

        //Navigation properties
        public Color Color { get; set; }
    }
}
