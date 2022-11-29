namespace KatsCoffeMachine.Models
{
    public class Coffee
    {
        //1, Paulig, cappuchino, 200, 400
        public int Id { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public CoffeeType CoffeeType { get; set; }
        public int CoffeeTypeId { get; set; }
        public int CupsAvailable { get; set; }
        public int CupsInPackage { get; set; }
    }
}
