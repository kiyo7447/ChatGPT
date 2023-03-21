
using Microsoft.AspNetCore.Mvc;
using TodoApiApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ITodosRepository, TodosRepository>();

//.NET7����s�v
//builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//.NET7����s�v
//app.UseHttpsRedirection();
//.NET7����s�v
//app.UseAuthorization();
//.NET7����s�v
//app.MapControllers();


app.MapGet("/todos", (
	[FromServices] ITodosRepository repository) =>
{
	return repository.GetTodos();
});
app.MapGet("/todos/{id}", (
	[FromRoute] int id,
	[FromServices] ITodosRepository repository) =>
{
	return repository.GetTodo(id);
});

app.MapPost("/todos/{description}", (
	[FromRoute] string description,
	[FromServices] ITodosRepository repository) =>
{
	repository.InsertTodo(description);
}).AddEndpointFilter(async (context, next) =>
{
	var description = (string?)context.Arguments[0];
	if (string.IsNullOrWhiteSpace(description))
	{
		return Results.Problem("Empty TODO description not allowed!");
	}
	return await next(context);
});

app.MapPut("/todos/{id}", (
	[FromRoute] int id,
	[AsParameters] EditTodoRequest request,
	[FromServices] ITodosRepository repository) =>
{
	repository.UpdateTodo(id, request.Description);
});


app.MapPost("/todos/upload", (IFormFile file,
	[FromServices] ITodosRepository repository) =>
{
	using var reader = new StreamReader(file.OpenReadStream());
	while (reader.Peek() >= 0)
		repository.InsertTodo(reader.ReadLine() ?? string.Empty);
});

app.Run();

internal struct EditTodoRequest
{
	public string Description { get; set; }
}
