using System;
using System.Collections.Generic;

namespace _03.Articles2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int articlesCount = int.Parse(Console.ReadLine());

            List<Article> articlesList = new();
            
            for (int i = 0; i < articlesCount; i++)
            {
                string[] articleDetails = Console.ReadLine().Split(", ");

                string title = articleDetails[0];
                string content = articleDetails[1];
                string author = articleDetails[2];

                Article article = new(title, content, author);

                articlesList.Add(article);
            }

            foreach (Article article in articlesList)
            {
                Console.WriteLine(Article.ToString(article));
            }
        }
    }

    public class Article
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
           Title = title;
           Content = content;
           Author = author;
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
