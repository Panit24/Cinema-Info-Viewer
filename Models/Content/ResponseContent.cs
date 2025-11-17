namespace Cinema_Info_Viewer.Models.Content
{
    public class ResponseContent
    {
        public Guid id { get; set; }
        public string? type { get; set; }
        public string? title { get; set; }
        public string? genre { get; set; }
        public string? rating { get; set; }
        public DateOnly? releaseDate { get; set; }
        public int? contentLength { get; set; }
        //public ResponseContentMedia? media { get; set; }
        public string? synopsis { get; set; }
        //public List<ResponseContentActor>? actor { get; set; }
        public string? director { get; set; }
        public List<string> eventId { get; set; }
        //public ResponseContentRibbon? ribbon { get; set; }
        //public ResponseContentRelease? rerelease { get; set; }
        public List<string> contentFormat { get; set; }
    }
}
