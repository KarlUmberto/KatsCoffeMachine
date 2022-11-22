namespace KatsCoffeMachine.Models
{
    public class Coffee
    {
        //1, Paulig, cappuchino, 200, 400
        public int Id { get; set; }
        public string Brand { get; set; }
        public string CoffeeType { get; set; }
        public int CupsAvailable { get; set; }
        public int CupsInPackage { get; set; }
    }
}
