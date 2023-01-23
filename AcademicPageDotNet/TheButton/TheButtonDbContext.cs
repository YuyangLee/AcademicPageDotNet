using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace AcademicPageDotNet.Button
{
    public class TheButtonClick
    {
        public int Id { get; set; }
        public long Count { get; set; }
        public string? LastClickIP { get; set; }
        public DateTime? LastClickTime { get; set; }
    }

    public class TheButtonDbContext : DbContext
    {
        public TheButtonDbContext(DbContextOptions<TheButtonDbContext> options) : base(options) { }
        protected DbSet<TheButtonClick> Clicks { get; set; }
        public TheButtonClick GetLastClick() => Clicks.OrderBy(c => c.Id).LastOrDefault<TheButtonClick>() ?? new TheButtonClick() { Id = -1, Count = 0 };

        public TheButtonClick AddClick(string thisClickAddr)
        {
            var lastClick = GetLastClick();
            var thisClickTimeUTC = DateTime.UtcNow;

            TheButtonClick thisClick = new()
            {
                Id = lastClick.Id + 1,
                Count = lastClick.Count + 1,
                LastClickIP = thisClickAddr,
                LastClickTime = thisClickTimeUTC
            };

            // TODO: Add anti-injection check (may be required, tho it runs at the server side...)
            Clicks.Add(thisClick);
            this.SaveChanges();
            
            return thisClick;
        }
    }
}
