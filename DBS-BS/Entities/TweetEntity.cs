namespace DBS_BS.Models;


public class TweetEntity
{
    public int TweetId { get; set; }
    public string? Content { get; set; }
    public string? Author { get; set; }
    public int Likes { get; set; }
    public string? CreatedAt  { get; set; }
    public string? UpdatedAt  { get; set; }
}