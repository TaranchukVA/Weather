namespace Weather.Data.ResponseParams.ResponseNow
{
    public class WindParam
    {
        public decimal speed { get; set; }
        public decimal deg { get; set; }
        public decimal? gust { get; set; }
    }
}