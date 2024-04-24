namespace api_diploma.Data.Models
{
    public class Parameter
    {
        public int Id { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public int ShoeSize { get; set; }
        public int ClothingSize { get; set; }
        public int GasMaskSize { get; set; }
        public int HeadCircumference { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
