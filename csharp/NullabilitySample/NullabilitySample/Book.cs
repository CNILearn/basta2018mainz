namespace NullabilitySample
{
    public class Book
    {
        public string Title { get; }
        public string? Publisher { get; }
        public Book(string title, string? publisher)
        {
            Title = title;
            Publisher = publisher;
        }

        public Book(string title)
            : this(title, null) { }

        public void Deconstruct(out string title, out string publisher)
            => (title, publisher) = (Title, Publisher);

        public override string ToString() => Title;
    }
}
