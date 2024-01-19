using DotNetMinimalAPIDemo.Components;
using minimalAPIDemo.Controllers;

namespace DotNetMinimalAPIDemo.RouterClasses
{
    public class AuthRouter : RouterBase
    {

        public AuthRouter(ILogger<AuthRouter> logger)
        {
            UrlFragment = "auth";
            Logger = logger;
        }

        public override void AddRoutes(WebApplication app)
        {
            app.MapGet($"/{UrlFragment}/no", () => AuthController.NoAuth());
            app.MapGet($"/{UrlFragment}/yes", (HttpRequest req) => AuthController.YesAuth(req)).RequireAuthorization();
            app.MapGet($"/{UrlFragment}/redis/{{key}}", (string key) => AuthController.GetRedis(key));
            app.MapGet($"/{UrlFragment}/getheader", (HttpRequest req) => AuthController.Get(req));
            app.MapGet($"/{UrlFragment}/mongo", () => AuthController.GetMongo());

        }
    }


}
