using Empty.Services;

var builder = WebApplication.CreateBuilder(args);
// ConfigureServices (Configureer je de DI)
builder.Services.AddHttpClient("test", opts=>{
    opts.BaseAddress=new Uri("https:///huahasodh.com");
}).SetHandlerLifetime(TimeSpan.FromMinutes(4));
builder.Services.AddScoped<ICounter, Counter>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure (Hier configureer je de request pipeline)
app.UseRouting();
app.MapDefaultControllerRoute();

app.Run();
