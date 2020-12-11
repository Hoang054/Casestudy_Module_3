using System;

namespace RPShop.Models.Entities
{
    public class Replay
    {
        public int ReplayId { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
