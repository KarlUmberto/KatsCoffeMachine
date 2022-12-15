namespace KatsCoffeMachine.Models
{
    public class CoffeeType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Coffee>? Coffees { get; set; }

    }
}
