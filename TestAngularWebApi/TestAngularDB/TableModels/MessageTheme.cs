using System.ComponentModel.DataAnnotations;

namespace TestAngularWebApi.TestAngularDB.TableModels
{
    public class MessageTheme
    {
        [Key] public int? ThemeId { get; set; }
        public string? ThemeName { get; set; }
        public List<Message> Messages { get; set; }
    }
}
