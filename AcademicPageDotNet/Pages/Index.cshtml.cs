using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace AcademicPageDotNet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        private readonly ILogger<IndexModel> _logger;

        public Dictionary<string, string?> Personal = new();
        public Dictionary<string, string?> Links = new();
        public string BioHtmlString = "";
        public string NewsHtmlString = "";
        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
        }

        private void LoadMarkdownData()
        {
            try
            {
                using (var streamReader = new StreamReader(this._config.GetValue<string>("BioMDFilePath"), Encoding.UTF8))
                {
                    BioHtmlString = Markdig.Markdown.ToHtml(streamReader.ReadToEnd());
                }
            }
            catch { BioHtmlString = "Failed to load the bio markdown file..."; }

            try
            {
                using (var streamReader = new StreamReader(this._config.GetValue<string>("NewsMDFilePath"), Encoding.UTF8))
                {
                    NewsHtmlString = Markdig.Markdown.ToHtml(streamReader.ReadToEnd());
                }
            }
            catch { NewsHtmlString = "Failed to load the news markdown file..."; }
        }

        public void OnGet()
        {
            var data = this._config.GetSection("Personal");
            this.Personal = data.GetChildren()
                                .ToDictionary(x => x.Key, x => x.Value);
            this.Links = data.GetSection("Links")
                             .GetChildren()
                             .ToDictionary(x => x.Key, x => x.Value);
            this.LoadMarkdownData();
        }
    }
}