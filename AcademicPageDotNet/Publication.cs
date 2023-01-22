namespace AcademicPageDotNet;

public class LinkLabel
{
    public string label = "";
    public string url = "";

    public LinkLabel(string label, string url)
    {
        this.label = label;
        this.url = url;
    }
}

[Flags]
public enum AuthorType
{
    Author = 0,
    FirstAuthor = 1,
    CorrespondingAuthor = 2,
    StrongAuthor = 4
};

public class AuthorLabel : LinkLabel
{
    public AuthorType type = new AuthorType();

    public AuthorLabel(string label, string url, AuthorType type) : base(label, url)
    {
        this.type = type;
    }
}


public class ExternalLabel : LinkLabel
{
    public ExternalLabel(string label, string url) : base(label, url) { }
}

public class PublicationItem
{
    public string title = "";

    public List<AuthorLabel> authors = new();

    public string publishDate = "";

    public string publicationName = "";

    public List<ExternalLabel> links = new();

    public string introduction = "";

    public string teaserUrl = "";
}
