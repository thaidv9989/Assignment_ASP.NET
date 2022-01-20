using System.Threading.Tasks;

namespace ASP.NET
{
    public class CustomMiddleware{
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next){
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context){
            await Task.Run(
                async () => {
                    await context.Response.WriteAsync("Reference\n");
                }
            );
            await context.Response.WriteAsync("Scheme: " + context.Request.Scheme + "\n");
            await context.Response.WriteAsync("Host: " + context.Request.Host.ToString() + "\n");
            await context.Response.WriteAsync("Path: " + context.Request.Path + "\n");
            await context.Response.WriteAsync("QueryString: " + context.Request.QueryString.ToString() + "\n");
            await context.Response.WriteAsync("Body: " + context.Request.Body.ToString());
            
        }
    }
}