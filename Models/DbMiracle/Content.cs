namespace Cinema_Info_Viewer.Models.DbMiracle
{
    public class Content
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? DistributorId { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public List<string>? ContentFormat { get; set; }
        public int? Duration { get; set; }
        public bool? IsAdvanceReport { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<string>? AudioLangs { get; set; }
        public List<string>? SubtitleLangs { get; set; }
        public string? RatingId { get; set; }
    }
}
