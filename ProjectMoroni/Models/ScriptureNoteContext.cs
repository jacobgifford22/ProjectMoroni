using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMoroni.Models
{
    public class ScriptureNoteContext : DbContext
    {
        // Constructor
        public ScriptureNoteContext(DbContextOptions<ScriptureNoteContext> options) : base(options)
        {
            // Leave blank for now
        }

        public DbSet<ScriptureNote> ScriptureNotes { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Seed data
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Scripture" },
                new Category { CategoryId = 2, CategoryName = "General Conference Talk" },
                new Category { CategoryId = 3, CategoryName = "Article" },
                new Category { CategoryId = 4, CategoryName = "Other" }
            );

            mb.Entity<ScriptureNote>().HasData(

                new ScriptureNote
                {
                    ScriptureNoteId = 1,
                    CategoryId = 1,
                    Reference = "Alma 48:17",
                    Link = "https://www.churchofjesuschrist.org/study/scriptures/bofm/alma/48?lang=eng&id=p17#p17",
                    Author = "Book of Mormon",
                    Quote = "Yea, verily, verily I say unto you, if all men had been, and were, and ever would be, like unto Moroni, behold, the very powers of hell would have been shaken forever; yea, the devil would never have power over the hearts of the children of men.",
                    Notes = "How can I be more like Moroni?"
                }
            );
        }
    }
}
