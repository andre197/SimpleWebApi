namespace FitnessWebApi.ViewModels
{
    public class MicronutrientViewModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public decimal Quantity { get; set; }

        public string FoodsContainingIt { get; set; }
    }
}