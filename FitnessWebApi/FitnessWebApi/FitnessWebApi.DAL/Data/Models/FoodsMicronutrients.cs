namespace FitnessWebApi.DAL.Data.Models
{
    public class FoodsMicronutrients
    {
        public int FoodId { get; set; }

        public virtual Food Food { get; set; }

        public int MicronutrientId { get; set; }

        public virtual Micronutrient Micronutrient { get; set; }
    }
}
