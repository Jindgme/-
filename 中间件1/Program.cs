var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

app.Map("/test", async (pBuilder) =>
{
    pBuilder.Use(async (context, next) =>
    {
        context.Response.ContentType = "text/html";
        await context.Response.WriteAsync("1 start<br/>");
        await next();
        await context.Response.WriteAsync("1 end<br/>");
    });
    pBuilder.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("2 start<br/>");
        await next();
        await context.Response.WriteAsync("2 end<br/>");
    }); 
    pBuilder.Run(async context =>
    {
        await context.Response.WriteAsync("Run<br/>");
    }); 
});
app.Run();
