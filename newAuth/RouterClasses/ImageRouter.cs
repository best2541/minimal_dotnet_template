using DotNetMinimalAPIDemo.Components;
using minimalAPIDemo.Controllers;

namespace minimalAPIDemo.RouterClasses
{
    public class ImageRouter: RouterBase
    {
        public ImageRouter(ILogger<ImageRouter> logger) {
            UrlFragment = "image";
            Logger = logger;
        }

        protected virtual IResult Get()
        {
            Logger.LogInformation("Getting all products");
            return Results.Ok();
        }

        public override void AddRoutes(WebApplication app)
        {
            app.MapPost($"/{UrlFragment}/upload", (IFormFile req) => ImageController.UploadImage(req));
            app.MapGet($"/{UrlFragment}/get", () => Get());
        }
    } }
