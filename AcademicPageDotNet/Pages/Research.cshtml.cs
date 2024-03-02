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
        public List<PublicationItem> preprintList = new();
        public List<PublicationItem> publicationList = new();
        public bool hasPreprint = false;
        public bool hasPublication = false;

        public PublicationsModel(AuthorDbContext authorCtx)
        {
            _authorCtx = authorCtx;
        }

        public void OnGet()
        {
            var data = PublicationItem.GetPublicationsList("Data/pubs.json");

            preprintList = data.Item1;
            hasPreprint = (preprintList.Count > 0);

            publicationList = data.Item2;
            hasPublication = (publicationList.Count > 0);
        }

        public List<AuthorLabel> GetAuthorLabels(PublicationItem pub) => pub.GetAuthorLabels(_authorCtx);
        public List<ExternalLabel> GetExternalLabels(PublicationItem pub) => pub.GetExternalLabels();
    }
}
