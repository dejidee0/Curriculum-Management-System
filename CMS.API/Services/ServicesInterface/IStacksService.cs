using CMS.API.Models;
using CMS.DATA.DTO;
using CMS.DATA.Entities;

namespace CMS.API.Services.ServicesInterface
{
    public interface IStacksService
    {
        Task<ResponseDto<Stack>> GetStackbyId(string id);
        Task<ResponseDto<IEnumerable<Stack>>> GetStacks();
        Task<ResponseDto<List<UserDto>>> GetUsersByStack(string stackId);
        Task<ResponseDto<string>> DeleteStack(string stackId);
       
    }
}