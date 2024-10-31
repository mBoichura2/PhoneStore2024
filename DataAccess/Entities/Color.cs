namespace UI.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation property
        public List<Phone> Colors { get; set; } = new List<Phone>();
    }
}
