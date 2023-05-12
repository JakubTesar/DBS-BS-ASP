namespace DBS_BS.FormModels;

public class TweetFormModel
{
    public string? Content { get; set; }
    public string? Author { get; set; }
    public int Likes { get; set; }
    public string? CreatedAt  { get; set; }
    public string? UpdatedAt  { get; set; }
}