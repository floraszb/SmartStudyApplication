using Microsoft.EntityFrameworkCore;

namespace SmartStudy.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        // Example DbSets
        public DbSet<User> Users => Set<User>();
        public DbSet<Flashcard> Flashcards => Set<Flashcard>();
        public DbSet<Note> Notes => Set<Note>();
    }

    // Example entity classes
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class Flashcard
    {
        public int Id { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
    }

    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}