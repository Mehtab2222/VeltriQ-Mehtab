using VeltriQ.ViewModels;

namespace VeltriQ.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<MenuViewModel>> GetMenusByRoleAsync(int roleId);
    }
}