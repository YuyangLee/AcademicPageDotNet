namespace AcademicPageDotNet;


[Flags]
public enum AuthorType
{
    Author = 0,
    FirstAuthor = 1,
    CorrespondingAuthor = 2,
    WebsiteOwner = 4
};

public class AuthorLabel : LinkLabel
{
    public AuthorType Type = new AuthorType();

    public AuthorLabel(string label, string? url, AuthorType type) : base(label, url)
    {
        this.Type = type;
    }

    public AuthorLabel(Author author, AuthorType type) : base(author.Name, author.Url)
    {
        this.Type = type;
    }
}

public class Author
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public string? Url { get; set; }

    public Author(string name, string? url)
    {
        Id = -1;
        Name = name;
        Url = url;
    }
}
