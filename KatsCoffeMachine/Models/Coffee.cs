using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KatsCoffeMachine.Models
{
    public class Coffee
    {
        //1, Paulig, cappuccino, 200, 400
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public Brand Brand { get; set; }
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        public CoffeeType CoffeeType { get; set; }
        [Display(Name = "Coffee type")]
        public int CoffeeTypeId { get; set; }
        public int CupsAvailable { get; set; }
        [Display(Name = "Cup Packages")]
        public int CupPackages { get; set; }
    }
}
