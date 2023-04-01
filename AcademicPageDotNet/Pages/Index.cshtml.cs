using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AcademicPageDotNet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        private readonly ILogger<IndexModel> _logger;

        public Dictionary<string, string?> Personal = new();
        public Dictionary<string, string?> Links = new();
        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
        }

        public void OnGet()
        {
            var data = this._config.GetSection("Personal");
            this.Personal = data.GetChildren()
                                .ToDictionary(x => x.Key, x => x.Value);
            this.Links = data.GetSection("Links")
                             .GetChildren()
                             .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}