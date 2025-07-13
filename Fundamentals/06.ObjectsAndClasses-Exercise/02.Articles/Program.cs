using System.Reflection;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleContents = Console.ReadLine().Split(", ");

            Article article = new()
            {
                Title = articleContents[0],
                Content = articleContents[1],
                Author = articleContents[2]
            };

            int changesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < changesCount; i++)
            {
                string[] commandArgs = Console.ReadLine().Split(": ");
                
                switch (commandArgs[0])
                {
                    case "Edit":
                        string newContent = commandArgs[1];
                        article = Article.Edit(article, newContent);
                        break;

                    case "ChangeAuthor":
                        string newAuthor = commandArgs[1];
                        article = Article.ChangeAuthor(article, newAuthor);
                        break;

                    case "Rename":
                        string newTitle = commandArgs[1];
                        article = Article.Rename(article, newTitle);
                        break;
                }
            }

            Console.WriteLine(Article.ToString(article));

        }
    }

    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }
        
        public string Author { get; set; }

        public Article() 
        { 
        
        }

        public static Article Edit(Article article, string newContent)
        {
            article.Content = newContent;

            return article;
        }

        public static Article ChangeAuthor(Article article, string newAuthor)
        {
            article.Author = newAuthor;

            return article;
        }

        public static Article Rename(Article article, string newTitle)
        {
            article.Title = newTitle;

            return article;
        }

        public static string ToString(Article article)
        {
            string title = article.Title;
            string content = article.Content;
            string author = article.Author;

            return $"{title} - {content}: {author}";
        }

    }
}
