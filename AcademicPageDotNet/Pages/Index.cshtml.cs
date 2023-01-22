using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AcademicPageDotNet.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;

        private readonly ILogger<IndexModel> _logger;

        public Dictionary<string, string> personal = new();
        public IndexModel(ILogger<IndexModel> logger, IConfiguration config)
        {
            this._config = config;
            _logger = logger;
        }

        public void OnGet()
        {
            this.personal = this._config.GetSection("Personal")
                                        .GetChildren()
                                        .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}