namespace RecipeDB.Models.DTO.Rating
{
    public class RatingResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public int Note { get; set; }
    }
}
