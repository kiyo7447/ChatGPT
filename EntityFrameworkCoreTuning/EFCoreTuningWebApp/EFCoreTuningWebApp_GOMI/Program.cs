using EFCoreTuningWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);


//DIコンテナにデータベースコンテキストを登録します。
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));



// データベースのマイグレーション処理を初回のレスポンスを強化する。
// データベースのマイグレーション処理
using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
	var services = scope.ServiceProvider;

	try
	{
		var dbContext = services.GetRequiredService<MyDbContext>();
		dbContext.Database.Migrate();
	}
	catch (Exception ex)
	{
		var logger = services.GetRequiredService<ILogger<Program>>();
		logger.LogError(ex, "An error occurred while migrating the database.");
		throw;
	}
}





// 他のサービスやミドルウェアの設定


// Add services to the container.
builder.Services.AddRazorPages();


// すべてのコントローラを登録
builder.Services.AddControllers();



//アプリを作成
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// コントローラのルーティングを有効化
app.MapControllers();

app.Run();
