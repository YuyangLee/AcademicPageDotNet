using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace AcademicPageDotNet.Models

{
    public class AuthorDbContext : DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options) : base(options) { }

        protected DbSet<Author> Authors { get; set; }

        public Author GetAuthor(string name) => Authors.FirstOrDefault(a => a.Name == name) ?? new Author(name, null);
    }
}
