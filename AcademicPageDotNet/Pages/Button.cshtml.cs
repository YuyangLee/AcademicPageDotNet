using AcademicPageDotNet.Button;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Emit;

namespace AcademicPageDotNet.Pages
{
    public class ButtonModel : PageModel
    {
        private readonly TheButtonDbContext _btnCtx;
        private string _remoteAddr = "somewhere mysterious";

        [BindProperty]
        public long ClickCount { get; set; } = 0;
        [BindProperty]
        public string? LastClickAddr { get; set; }
        [BindProperty]
        public string? LastClickDateTime { get; set; }

        public ButtonModel(TheButtonDbContext btnCtx)
        {
            _btnCtx = btnCtx;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            SetData(_btnCtx.GetLastClick());
            return Page();
        }

        private void SetData(TheButtonClick clk)
        {
            ClickCount = clk.Count;
            LastClickAddr = clk.LastClickIP;
            LastClickDateTime = clk.LastClickTime.ToString();
        }

        public void OnPost()
        {
            if (Request.Headers.TryGetValue("X-Forwarded-For", out var forwardedIps))
                _remoteAddr = forwardedIps.First();
            else
            {
                _remoteAddr = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "somewhere really mysterious";
            }

            SetData(_btnCtx.AddClick(_remoteAddr));
        }
    }
}
