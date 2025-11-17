namespace Cinema_Info_Viewer.Models.DbMiracle
{
    public class Content
    {
        public Guid Id { get; set; }
        public string? ShortName { get; set; }
        public string? DistributorId { get; set; }
        public DateOnly? ReleaseDate { get; set; }
    }
}
