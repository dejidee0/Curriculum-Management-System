namespace CMS.MVC.Models
{
    public class ApiRequestDto
    {
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public object requestObject { get; set; }
    }
}