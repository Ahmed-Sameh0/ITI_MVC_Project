namespace WebApplication4.Helper
{
    public static class Upload
    {
        public static string UploadFile(string FolderName, IFormFile file)
        {
            try
            {
                string FolderPath = Directory.GetCurrentDirectory() + "/wwwroot/" + FolderName;
                string FileName = Guid.NewGuid()
                    + Path.GetFileName(file.FileName);
                string FinalPath = Path.Combine(FolderPath, FileName);
                using (var stream = new FileStream(FinalPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return FileName;
            }

            catch (Exception ex)
            {
                return ex.Message;
            } 
            
        }
    }
}
