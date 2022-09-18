using FileManager.Models;
using Microsoft.EntityFrameworkCore;

namespace FileManager;

public class ApplicationContext : DbContext
{
    public DbSet<FileAccessRecord> FilesAccessRecords { get; set; }

	public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
	{

	}
}
