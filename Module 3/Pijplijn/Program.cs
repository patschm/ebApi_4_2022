using Pijplijn;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile(Environment.CurrentDirectory, $"Bla.{Environment.GetEnvironmentVariable("Development")}.json");
// Add services to the container.

System.Console.WriteLine(Environment.GetEnvironmentVariable("ASPNETCORE_BLA"));
var section = builder.Configuration.GetSection("MijnSpul");
MijnSpul sp = new MijnSpul();
section.Bind(sp);
System.Console.WriteLine(sp.Data);
//System.Console.WriteLine(section.Value);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseMiddleware<MijnMiddleware>();
app.UseSven();

// app.Use((HttpContext ctx, RequestDelegate next)=>{
//     System.Console.WriteLine("Heenweg");
//     return next(ctx).ContinueWith(pt=>{
      
//         System.Console.WriteLine("Terugweg");
//     });
// });

// app.Use((HttpContext ctx, RequestDelegate next)=>{
//     System.Console.WriteLine("Heenweg sub");
//     return next(ctx).ContinueWith(pt=>{
//         System.Console.WriteLine("Terugweg sub");
//     });
// });
//app.UseAuthorization();

// app.Map("/hoi", ap2=>{
//    ap2.Use((HttpContext ctx, RequestDelegate next)=>{
//     System.Console.WriteLine("Heenweg hoi");
//     return next(ctx).ContinueWith(pt=>{
//         System.Console.WriteLine("Terugweg hoi");
//     });
//     });
// });

// app.Map("/hallo", ap2=>{
//    ap2.Use((HttpContext ctx, RequestDelegate next)=>{
//     System.Console.WriteLine("Heenweg hallo");
//     return next(ctx).ContinueWith(pt=>{
//         System.Console.WriteLine("Terugweg hallo");
//     });
//     });
// });
app.MapControllers();

app.Run();
