namespace AcademicPageDotNet.Models;

public class LinkLabel
{
    public string Label = "";
    public string? Url = "";

    public LinkLabel(string label, string? url)
    {
        Label = label;
        Url = url;
    }
}
