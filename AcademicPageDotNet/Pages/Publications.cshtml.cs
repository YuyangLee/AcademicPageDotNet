using AcademicPageDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AcademicPageDotNet.Pages
{
    public class PublicationsModel : PageModel
    {
        private readonly AuthorDbContext _authorCtx;
        public List<PublicationItem> _publicationList = new();

        public PublicationsModel(AuthorDbContext authorCtx)
        {
            _authorCtx = authorCtx;
        }

        public void OnGet()
        {
            _publicationList = PublicationItem.GetPublicationsList("Data/pubs.json");
        }

        public List<AuthorLabel> GetAuthorLabels(PublicationItem pub) => pub.GetAuthorLabels(_authorCtx);
        public List<ExternalLabel> GetExternalLabels(PublicationItem pub) => pub.GetExternalLabels();
    }
}
