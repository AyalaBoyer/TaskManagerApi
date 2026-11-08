using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// מאפשר לכתוב את רמת הדחיפות כטקסט ב-JSON ("High") ולא כמספר
builder.Services.AddControllers()
    .AddJsonOptions(o => o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();
app.MapControllers();
app.Run();
