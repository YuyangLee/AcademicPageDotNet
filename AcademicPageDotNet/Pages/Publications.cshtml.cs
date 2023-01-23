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
            _publicationList = PublicationItem.getPublicationsList("Data/pubs.json");
        }

        public List<AuthorLabel> getAuthorLabels(PublicationItem pub) => pub.getAuthorLabels(_authorCtx);
        public List<ExternalLabel> getExternalLabels(PublicationItem pub) => pub.getExternalLabels();
    }
}
