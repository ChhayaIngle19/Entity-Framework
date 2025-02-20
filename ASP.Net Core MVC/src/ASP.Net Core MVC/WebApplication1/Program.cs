namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //app.MapGet("/", () => "Hello World!");
            //app.Run(async (Context) =>
            //{
            //    await Context.Response.WriteAsync("Welcome to ASP.Net");
            //});

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from middleware 1. Passing to the next middleware!\r\n");

                // Call the next middleware in the pipeline
                await next.Invoke();

                await context.Response.WriteAsync("Hello from middleware 1 again!\r\n");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from middleware 2!\r\n");
            });

            app.Run();
        }
    }
}
