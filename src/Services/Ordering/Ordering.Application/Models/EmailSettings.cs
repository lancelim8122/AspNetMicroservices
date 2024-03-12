namespace Ordering.Application.Models
{

    /// <summary>
    /// For sendgrid integration
    /// </summary>
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }

}