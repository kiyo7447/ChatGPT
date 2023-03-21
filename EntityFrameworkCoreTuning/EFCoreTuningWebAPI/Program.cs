using EFCoreTuningWebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DI�R���e�i�Ƀf�[�^�x�[�X�R���e�L�X�g��o�^���܂��B
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options => options.UseSqlServer(connectionString));

// ���ׂẴR���g���[����o�^
builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// �f�[�^�x�[�X�̃}�C�O���[�V��������������̃��X�|���X����������B
// �f�[�^�x�[�X�}�C�O���[�V�����̓K�p
using (var scope = app.Services.CreateScope()) 
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




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
