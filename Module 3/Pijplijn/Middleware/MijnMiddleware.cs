public class MijnMiddleware
{
    private RequestDelegate next;

    public MijnMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext ctx)
    {
        System.Console.WriteLine("Heen met mijn");
        await next(ctx);
        System.Console.WriteLine("terug met mijn");
    }
}

public static class SvenExtenstion
{
    public static IApplicationBuilder UseSven(this IApplicationBuilder app)
    {
        app.UseMiddleware<MijnMiddleware>();
        return app;
    }
}