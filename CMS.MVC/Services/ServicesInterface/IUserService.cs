
﻿using CMS.DATA.DTO;
using CMS.DATA.Enum;
using CMS.MVC.Services.Implementation;

namespace CMS.MVC.Services.ServicesInterface
{
    public interface IUserService
    {

       public Task<ResponseDto<bool>> DeleteUser(string userId);
     public Task<ResponseDto<bool>> SetActiveStatus(string userId, bool status);

      public Task<bool> RequestPermission(string userId);
     public Task<bool> GrantPermission(string userId, Permissions claims);

     Task<ResponseDTO<bool>> DeleteFileAsync(string publicId, string email);
     Task<ResponseDTO<Dictionary<string, string>>> UploadFileAsync(IFormFile file, string email);
     Task<ResponseDto<string>> GetUserRoles(string userId);
     Task<ResponseDto<IEnumerable<GetAllUsersDto>>> GetAllUsers();
     Task<ResponseDto<GetuserByIdDto>> GetByIDAsync(string Id);
    }
}

