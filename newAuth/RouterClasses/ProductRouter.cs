using DotNetMinimalAPIDemo.EntityClasses;
using DotNetMinimalAPIDemo.Components;

namespace DotNetMinimalAPIDemo.RouterClasses
{
    /// <summary>
    /// Product Router inherits from the Router Base class
    /// </summary>
    public class ProductRouter: RouterBase
    {
        public ProductRouter(ILogger<ProductRouter> logger)
        {
            UrlFragment = "product";
            Logger = logger;
        }


        /// <summary>
        /// GET a collection of data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Get()
        {
            Logger.LogInformation("Getting all products");
            return Results.Ok(GetAll());
        }

        /// <summary>
        /// Get a collection of Product objects
        /// </summary>
        /// <returns>A list of Product objects</returns>
        protected virtual IResult GetAll()
        {
            return Results.Ok("OK");
        }

        /// <summary>
        /// GET a single row of data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Get(int id)
        {
            return Results.Ok("OK");
        }

        /// <summary>
        /// INSERT new data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Post()
        {
            return Results.Ok("OK");
        }

        /// UPDATE existing data
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Put(int id)
        {
            IResult ret;
            return Results.Ok("OK");
        }

        /// <summary>
        /// DELETE a single row
        /// </summary>
        /// <returns>An IResult object</returns>
        protected virtual IResult Delete(int id)
        {
            IResult ret;
            return Results.Ok("OK");
        }

        /// <summary>
        /// The AddRoutes() method calls the app.MapGet() method using the WebApplication app variable passed in from the Program.cs file.
        ///  The first parameter to the MapGet() method is  the route name the user sends the request to, such as http://
        /// localhost:nnnn/product or http://localhost:nnnn/customer
        //</summary>
        /// <param name="app">A WebApplication object</param>
        public override void AddRoutes(WebApplication app)
        {
            app.MapGet($"/{UrlFragment}", () => Get());

            app.MapGet($"/{UrlFragment}/{{id:int}}",
            (int id) => Get(id));

            app.MapDelete($"/{UrlFragment}/{{id:int}}",
            (int id) => Delete(id));
        }
    }
}
