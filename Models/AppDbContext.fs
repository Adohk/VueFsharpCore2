namespace VueFsharpCore2.Models

open VueFsharpCore2.Models
open Microsoft.AspNetCore.Identity.EntityFrameworkCore
open Microsoft.EntityFrameworkCore

type AppDbContext (options:DbContextOptions<AppDbContext>) =
    inherit IdentityDbContext<ApplicationUser>(options)

    [<DefaultValue>] val mutable Contacts : DbSet<Contact>
    member x.Contact with get() = x.Contacts and set v = x.Contacts <- v

    // [<DefaultValue>] val mutable ApplicationUsers : DbSet<ApplicationUser>
    // member x.ApplicationUser with get() = x.ApplicationUsers and set v = x.ApplicationUsers <- v

    //  override this.OnConfiguring optionsBuilder =
    //      optionsBuilder.UseSqlServer @"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;"

    //  override this.OnModelCreating(modelBuilder:ModelBuilder) =
    //      this.OnModelCreating(modelBuilder)