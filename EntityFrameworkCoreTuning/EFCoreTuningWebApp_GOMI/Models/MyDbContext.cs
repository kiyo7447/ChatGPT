using EFCoreTuningWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace EFCoreTuningWebApp.Models
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options)
			: base(options)
		{
		}

		public DbSet<MyEntity> MyEntities { get; set; }

		// 必要に応じて他のDbSetプロパティを追加
	}
}
