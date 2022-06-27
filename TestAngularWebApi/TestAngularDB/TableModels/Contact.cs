using System.ComponentModel.DataAnnotations;

namespace TestAngularWebApi.TestAngularDB.TableModels
{
    public class Contact
    {
        [Key] public int? ContactId { get; set; }
        public string? ContactName { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public List<Message>? Messages { get; set; }
    }
}
