namespace DatingApp.API.Models
{
    public class Like
    {
        public int LikerId { get; set; }
        public int LikeeId { get; set; }
        public ExaltUser Liker { get; set; }
        public ExaltUser Likee { get; set; }
    }
}