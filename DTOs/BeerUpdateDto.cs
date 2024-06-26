namespace Backend.DTOs
{
    public class BeerUpdateDto//Dto con los atributos necesarios para modificar una beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public decimal Alcohol { get; set; }
    }
}
