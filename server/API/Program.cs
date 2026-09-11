using Infrastructure;
using LinqToDB;
using Service;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=./development.db";
var options = DataOptionsExtensions.UseSQLite(new DataOptions(), connectionString);
var dataOptions = new DataOptions<MyAmazingDatabase>(options);

builder.Services.AddScoped<MyAmazingDatabase>(_ => new MyAmazingDatabase(dataOptions));
builder.Services.AddOpenApiDocument();

builder.Services.AddScoped<IMyAmazingService, MyAmazingService>();
builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MyAmazingDatabase>();
    db.CreateTable<MyAmazingEntities>(tableOptions: TableOptions.CreateIfNotExists);
}

app.MapGet("/", (MyAmazingDatabase db) => db.MyAmazingEntities().ToList());
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();

app.Run();
