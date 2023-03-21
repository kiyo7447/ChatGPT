using EFCoreTuningWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static System.Formats.Asn1.AsnWriter;

var builder = WebApplication.CreateBuilder(args);


//DI�R���e�i�Ƀf�[�^�x�[�X�R���e�L�X�g��o�^���܂��B
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));



// �f�[�^�x�[�X�̃}�C�O���[�V��������������̃��X�|���X����������B
// �f�[�^�x�[�X�̃}�C�O���[�V��������
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





// ���̃T�[�r�X��~�h���E�F�A�̐ݒ�


// Add services to the container.
builder.Services.AddRazorPages();


// ���ׂẴR���g���[����o�^
builder.Services.AddControllers();



//�A�v�����쐬
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

// �R���g���[���̃��[�e�B���O��L����
app.MapControllers();

app.Run();
