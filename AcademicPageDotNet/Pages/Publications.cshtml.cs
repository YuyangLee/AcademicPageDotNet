using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AcademicPageDotNet.Pages
{
    public class PublicationsModel : PageModel
    {
        private readonly AuthorDbContext _authorCtx;
        public List<PublicationItem> _publicationList;
        public List<AuthorLabel> _authors;
        public List<ExternalLabel> _links;

        public PublicationsModel(AuthorDbContext authorCtx)
        {
            _authorCtx = authorCtx;
        }

        public void OnGet()
        {
            _publicationList = PublicationItem.getPublicationsList("Data/subs.json");
        }

        public List<AuthorLabel> getAuthorLabels(PublicationItem pub) => pub.getAuthorLabels(_authorCtx);
        public List<ExternalLabel> getExternalLabels(PublicationItem pub) => pub.getExternalLabels();
    }
}
