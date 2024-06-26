namespace Backend.DTOs
{
    public class BeerInsertDto //Dto con los atributos necesarios para insertar una beer
    {
        public string? Name { get; set; }
        public int BrandId { get; set; }
        public decimal Alcohol { get; set; }
    }
}
