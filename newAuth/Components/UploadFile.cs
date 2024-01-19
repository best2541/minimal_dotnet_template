namespace minimalAPIDemo.Components
{
    public class UploadFile
    {
        public static string Img(IFormFile file)
        {
            try
            {
                string ecmid = "";
                    using (var stream = new MemoryStream())
                    {
                        file.CopyTo(stream);
                        byte[] data = stream.ToArray();
                        ecmid = file.Name;
                    return System.Text.Encoding.UTF8.GetString(data);
                    }
            } catch (Exception e)
            {
                throw e;
            }

        }
    }
}
