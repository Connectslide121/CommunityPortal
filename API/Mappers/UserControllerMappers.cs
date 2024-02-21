using API.InputModels;
using Services.DTOs;

namespace API.Mappers
{
    public class UserControllerMappers
    {
        public UserDTO MapUserUpdateModelToUserDTO(UserUpdateModel updateModel)
        {


            UserDTO userDTO = new UserDTO
            {
                UserId = updateModel.UserId,
                UserName = updateModel.UserName,
                ProfilePicturePath = updateModel.ProfilePicturePath,
                Description = updateModel.Description,
            };
            return userDTO;
        }
    }
}
