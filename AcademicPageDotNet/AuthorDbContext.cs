using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace AcademicPageDotNet

{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options) { }

        protected DbSet<Author> Authors { get; set; }

        public Author getAuthor(string name) => Authors.FirstOrDefault<Author>(a => a.Name == name) ?? new Author(name, null);
    }
}
