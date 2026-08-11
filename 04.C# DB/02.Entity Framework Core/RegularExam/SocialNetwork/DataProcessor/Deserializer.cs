using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.Data.Models;
using SocialNetwork.DataProcessor.ImportDTOs;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(SocialNetworkDbContext dbContext, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute root = new XmlRootAttribute("Messages");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportMessagesWrapperDto), root);

            using StringReader reader = new StringReader(xmlString);
            ImportMessagesWrapperDto wrapper = (ImportMessagesWrapperDto)serializer.Deserialize(reader);

            List<Message> validMessages = new List<Message>();

            foreach (ImportMessageDto dto in wrapper.Messages)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool validDate = DateTime
                    .TryParseExact(
                    dto.SentAt,
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime sentAt);

                if (!validDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool validStatus = Enum.TryParse(dto.Status, out MessageStatus status)
                    && Enum.IsDefined(typeof(MessageStatus), status);//TO DO: WHAT??

                if (!validStatus)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool conversationExists = dbContext.Conversations.Any(c => c.Id == dto.ConversationId);
                bool senderExists = dbContext.Users.Any(u => u.Id == dto.SenderId);

                if (!conversationExists || !senderExists)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDuplicate = dbContext.Messages.Any(m =>
                   m.Content == dto.Content &&
                   m.SentAt == sentAt &&
                   m.Status == status &&
                   m.SenderId == dto.SenderId &&
                   m.ConversationId == dto.ConversationId) || validMessages.Any(m =>
                   m.Content == dto.Content &&
                   m.SentAt == sentAt &&
                   m.Status == status &&
                   m.SenderId == dto.SenderId &&
                   m.ConversationId == dto.ConversationId);

                if (isDuplicate)
                {
                    sb.AppendLine(DuplicatedDataMessage);
                    continue;
                }

                Message message = new Message
                {
                    Content = dto.Content,
                    SentAt = sentAt,
                    Status = status,
                    ConversationId = dto.ConversationId,
                    SenderId = dto.SenderId
                };

                validMessages.Add(message);
                sb.AppendLine(string.Format(SuccessfullyImportedMessageEntity, sentAt.ToString("yyyy-MM-ddTHH:mm:ss"), status));
            }

            dbContext.Messages.AddRange(validMessages);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPosts(SocialNetworkDbContext dbContext, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportPostDto[] dtos = JsonConvert.DeserializeObject < ImportPostDto[]>(jsonString);
            List<Post> validPosts = new List<Post>();

            foreach (ImportPostDto dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool validDate = DateTime.TryParseExact(
                    dto.CreatedAt,
                    "yyyy-MM-ddTHH:mm:ss",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime createdAt);

                if (!validDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                User creator = dbContext.Users.FirstOrDefault(u => u.Id == dto.CreatorId);
                if (creator == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isDuplicate = dbContext.Posts.Any(p =>
                    p.Content == dto.Content &&
                    p.CreatedAt == createdAt &&
                    p.CreatorId == dto.CreatorId) || validPosts.Any(p =>
                    p.Content == dto.Content &&
                    p.CreatedAt == createdAt &&
                    p.CreatorId == dto.CreatorId);

                if (isDuplicate)
                {
                    sb.AppendLine(DuplicatedDataMessage);
                    continue;
                }

                Post post = new Post
                {
                    Content = dto.Content,
                    CreatedAt = createdAt,
                    CreatorId = dto.CreatorId
                };

                validPosts.Add(post);
                sb.AppendLine(string.Format(SuccessfullyImportedPostEntity, creator.Username, createdAt.ToString("yyyy-MM-ddTHH:mm:ss")));
            }

            dbContext.Posts.AddRange(validPosts);
            dbContext.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
