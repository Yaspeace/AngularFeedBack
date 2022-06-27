using System.ComponentModel.DataAnnotations;

namespace TestAngularWebApi.TestAngularDB.TableModels
{
    public class Message
    {
        [Key] public int? MessageId { get; set; }
        public string? MessageContent { get; set; }
        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }
        public int MessageThemeId { get; set; }
        public MessageTheme MessageTheme { get; set; }
    }
}
