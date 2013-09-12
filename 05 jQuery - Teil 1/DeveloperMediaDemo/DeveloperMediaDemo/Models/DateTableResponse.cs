namespace DeveloperMediaDemo.Models
{
    public class DateTableResponse
    {
        public string sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public string[][] aaData { get; set; }
    }
}