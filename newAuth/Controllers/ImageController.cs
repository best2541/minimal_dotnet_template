using Microsoft.AspNetCore.Mvc;
using minimalAPIDemo.Components;

namespace minimalAPIDemo.Controllers
{
    public class ImageController
    {
        public static IResult UploadImage(IFormFile image)
        {
            var result = UploadFile.Img(image);
            return Results.Ok(result);
        }
    }
}
