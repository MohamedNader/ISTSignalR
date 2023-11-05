using PushTasks.Hubs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen(option =>
{
});
// Add services to the container.

builder.Services.AddSignalR(o => 
{
    o.HandshakeTimeout = TimeSpan.FromMilliseconds(500);
    o.EnableDetailedErrors = true;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true));
});

builder.Services.AddControllers();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("CORSPolicy");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();
app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapHub<TasksHub>("/UsersTasks");
});

app.Run();
