namespace AcademicPageDotNet;

using System.Text.Json;
using System.Text.Json.Serialization;

public class ExternalLabel : LinkLabel
{
    public ExternalLabel(string label, string url) : base(label, url) { }
}

public class PublicationItem
{
    public string Title { get; set; }

    public List<string> Authors { get; set; }

    public string PublishDate { get; set; }

    public string PublicationName { get; set; }

    public string State { get; set; }

    public Dictionary<string, string> Links { get; set; }

    public string Introduction { get; set; }

    public string TeaserUrl { get; set; }

    public bool Highlight { get; set; }

    public static List<PublicationItem> getPublicationsList(string jsonFilePath)
    {
        if (!System.IO.File.Exists(jsonFilePath))
        {
            return new List<PublicationItem>();
        }
        string json = System.IO.File.ReadAllText(jsonFilePath);
        return JsonSerializer.Deserialize<List<PublicationItem>>(json) ?? new List<PublicationItem>();
    }

    public List<AuthorLabel> getAuthorLabels(AuthorDbContext authorDbContext)
    {
        List<AuthorLabel> authorLabels = new();
        foreach (var author in Authors)
        {
            authorLabels.Add(new AuthorLabel(authorDbContext.getAuthor(author), AuthorType.Author));
        }
        return authorLabels;
    }

    public List<ExternalLabel> getExternalLabels()
    {
        List<ExternalLabel> externalLabels = new();
        foreach (var (label, url) in Links)
        {
            externalLabels.Add(new ExternalLabel(label, url));
        }
        return externalLabels;
    }
}
