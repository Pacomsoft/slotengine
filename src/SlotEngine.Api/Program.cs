var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/api/v1", () =>
{
    return Results.Ok(new
    {
        name = "SlotEngine API",
        version = "v1",
        status = "running"
    });
})
.WithName("GetApiInfo")
.WithTags("Platform")
.WithSummary("Returns basic SlotEngine API information");

app.Run();
