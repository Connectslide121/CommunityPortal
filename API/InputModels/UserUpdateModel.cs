using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API.InputModels
{
    public class UserUpdateModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string ProfilePicturePath { get; set; }
        public string Description { get; set; }
    }
}
