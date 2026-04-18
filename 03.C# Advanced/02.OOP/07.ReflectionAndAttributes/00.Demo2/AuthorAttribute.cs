namespace Demo2
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    internal class AuthorAttribute : Attribute
    {
        public string Name { get; set; }
    }
}
