namespace AcademicPageDotNet.Models;

using System.Collections.Generic;
using System.Text.Json;
using AcademicPageDotNet;

public class ExternalLabel : LinkLabel
{
    public ExternalLabel(string label, string url) : base(label, url) { }
}

public class PublicationItem
{
    public string? Title { get; set; }

    public Dictionary<string, AuthorType> Authors { get; set; } = new();

    public string? PublishDate { get; set; }

    public string? PublicationName { get; set; }

    public string? State { get; set; }

    public Dictionary<string, string> Links { get; set; } = new();

    public string? Introduction { get; set; }

    public string? TeaserUrl { get; set; }

    public bool? Highlight { get; set; }

    public bool? Preprint { get; set; }

    public static Tuple<List<PublicationItem>, List<PublicationItem>> GetPublicationsList(string jsonFilePath)
    {
        if (!File.Exists(jsonFilePath))
        {
            return new Tuple<List<PublicationItem>, List<PublicationItem>>(new List<PublicationItem>(), new List<PublicationItem>());
        }
        string json = File.ReadAllText(jsonFilePath);
        List<PublicationItem> allPublicationList = JsonSerializer.Deserialize<List<PublicationItem>>(json) ?? new List<PublicationItem>();
        List<PublicationItem> preprintList = allPublicationList.Where(pub => pub.Preprint is true).ToList();
        List<PublicationItem> publicationList = allPublicationList.Where(pub => pub.Preprint is false).ToList();
        return new Tuple<List<PublicationItem>, List<PublicationItem>>(preprintList, publicationList);
    }

    public List<AuthorLabel> GetAuthorLabels(AuthorDbContext authorDbContext)
    {
        List<AuthorLabel> authorLabels = new();
        foreach (var (name, type) in Authors)
        {
            authorLabels.Add(new AuthorLabel(authorDbContext.GetAuthor(name), type));
        }
        return authorLabels;
    }

    public List<ExternalLabel> GetExternalLabels()
    {
        List<ExternalLabel> externalLabels = new();
        foreach (var (label, url) in Links)
        {
            externalLabels.Add(new ExternalLabel(label, url));
        }
        return externalLabels;
    }
}
