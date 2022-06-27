using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAngularWebApi.TestAngularDB;
using TestAngularWebApi.TestAngularDB.TableModels;
using TestAngularWebApi.Services;
using TestAngularWebApi.Models;
using System.Text;

namespace TestAngularWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedBackController : ControllerBase
    {
        private readonly TestAngularDbContext _db;
        private readonly ILogger<FeedBackController> _logger;
        private readonly FieldsValidator _validator;

        public FeedBackController(ILogger<FeedBackController> logger, 
                                    TestAngularDbContext db, 
                                    FieldsValidator validator)
        {
            _logger = logger;
            _db = db;
            _validator = validator;
        }

        [HttpGet]
        public IEnumerable<MessageTheme> ProvideMessageThemes() => _db.MessageThemes.ToList();

        [HttpGet("messages/{id}")]
        public Message? GetMessage(int id) => _db.Messages.Find(id);

        [HttpGet("themes/{id}")]
        public MessageTheme? GetTheme(int id) => _db.MessageThemes.Find(id);

        [HttpGet("contacts/{id}")]
        public Contact? GetContact(int id) => _db.Contacts.Find(id);
        
        //Returns id of added message
        [HttpPost]
        public ActionResult<int> RecieveFeedBack(FeedBackFormModel model)
        {
            if (model != null
                && _validator.ValidateEmail(model.Email)
                && _validator.ValidatePhone(model.Phone)
                && !string.IsNullOrEmpty(model.Name)
                && !string.IsNullOrEmpty(model.Message))
            {
                Contact? contact = _db.Contacts
                    .Where(c => c.ContactPhone == model.Phone && c.ContactEmail == model.Email)
                    .ToList()
                    .DefaultIfEmpty(null)
                    .First();

                if (contact == null)
                    contact = new Contact
                    {
                        ContactId = null,
                        ContactName = model.Name,
                        ContactEmail = model.Email,
                        ContactPhone = model.Phone
                    };

                Message message = new Message
                {
                    MessageId = null,
                    MessageContent = model.Message,
                    Contact = contact,
                    MessageTheme = _db.MessageThemes.Find(model.Theme)
                };
                _db.Messages.Add(message);
                _db.SaveChanges();

                return Ok(message.MessageId);
            }

            return BadRequest();
        }
    }
}
