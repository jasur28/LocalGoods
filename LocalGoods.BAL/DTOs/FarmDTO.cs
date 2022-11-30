namespace LocalGoods.BAL.DTOs
{
    public class FarmDTO
    {
        [SwaggerSchema(ReadOnly =true)]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set;}
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
