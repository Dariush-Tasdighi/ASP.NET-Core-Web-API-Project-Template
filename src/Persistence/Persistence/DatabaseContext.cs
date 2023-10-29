using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class DatabaseContext :
	Microsoft.EntityFrameworkCore.DbContext
{
	#region Constructor
	public DatabaseContext(Microsoft.EntityFrameworkCore
		.DbContextOptions<DatabaseContext> options) : base(options: options)
	{
		// تا قبل از اولین نسخه اصلی
		Database.EnsureCreated();
	}
	#endregion /Constructor

	#region Properties

	#region Identity Feature

	public Microsoft.EntityFrameworkCore.DbSet<Domain.Features.Identity.User> Users { get; set; }

	#endregion /Identity Feature

	#endregion /Properties

	#region Methods

	#region OnConfiguring()
	protected override void OnConfiguring
		(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
	{
		// ******************************************************************
		// https://www.connectionstrings.com/sql-server/
		// Connect Timeout or Connection Timeout: Default: 15 Seconds
		// ******************************************************************

		// ******************************************************************
		// *** Windows Authentication Mode without TrustServerCertificate ***
		// ******************************************************************
		//var connectionString =
		//	"Server=.;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;Trusted_Connection=True;";
		// ******************************************************************

		// ***************************************************************
		// *** Windows Authentication Mode with TrustServerCertificate ***
		// ***************************************************************
		//var connectionString =
		//	"Server=.;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;Trusted_Connection=True;TrustServerCertificate=True;";
		// ******************************************************************

		// *********************************************************************
		// *** SQL Server Authentication Mode without TrustServerCertificate ***
		// *********************************************************************
		//var connectionString =
		//	"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true";
		// ******************************************************************

		// ******************************************************************
		// *** SQL Server Authentication Mode with TrustServerCertificate ***
		// ******************************************************************
		var connectionString =
			"Server=.;User ID=sa;Password=1234512345;Database=LEARNING_EF_CORE_0200;MultipleActiveResultSets=true;TrustServerCertificate=True;";
		// ******************************************************************

		// UseSqlServer -> using Microsoft.EntityFrameworkCore;
		optionsBuilder.UseSqlServer
			(connectionString: connectionString);
	}
	#endregion /OnConfiguring()

	#region OnModelCreating()
	protected override void OnModelCreating
		(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly
			(assembly: typeof(DatabaseContext).Assembly);
	}
	#endregion /OnModelCreating()

	#endregion /Methods
}
