using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.DataProcessor.ExportDTOs;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            List<ExportUserDto> userDtos = dbContext.Users
                .OrderBy(u => u.Username)
                .Select(u => new ExportUserDto
                {
                    Friendships = dbContext.Friendships.Count(f => f.UserOneId == u.Id || f.UserTwoId == u.Id),
                    Username = u.Username,
                    Posts = u.Posts
                    .OrderBy(p => p.Id)
                    .Select(p => new ExportPostDto
                    {
                        Content = p.Content,
                        CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)
                    }).ToList()

                }).ToList();

            ExportUsersWrapperDto wrapper = new ExportUsersWrapperDto
            {
                Users = userDtos
            };

            XmlSerializer serializer = new XmlSerializer(typeof(ExportUsersWrapperDto));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            //XmlWriterSettings settings = new XmlWriterSettings
            //{
            //    Indent = true,
            //    IndentChars = " ",
            //    NewLineChars = "\r\n",
            //    Encoding = Encoding.UTF8,
            //    OmitXmlDeclaration = false
            //};

            StringBuilder sb = new StringBuilder();
            using (StringWriter sw = new StringWriter(sb))
                //using (XmlWriter xmlW = XmlWriter.Create(sw, settings))
            {
                serializer.Serialize(sw, wrapper, namespaces);
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            List<ExportConversationDto> conversationDtios = dbContext.Conversations
                .OrderBy(c => c.StartedAt)
                .Select(c => new ExportConversationDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                    Messages = c.Messages
                        .OrderBy(m => m.SentAt)
                        .Select(m => new ExportMessageDto
                        {
                            Content = m.Content,
                            SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture),
                            Status = (int)m.Status,
                            SenderUsername = m.Sender.Username
                        }).ToList()
                }).ToList();

            string json = JsonConvert.SerializeObject(conversationDtios, Newtonsoft.Json.Formatting.Indented);
            return json;
        }
    }
}
