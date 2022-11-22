using DemoSignatures.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoSignatures.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}

	public DbSet<FileEntry> FileEntries=> Set<FileEntry>();
}
