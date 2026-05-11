using Microsoft.EntityFrameworkCore;
using VeltriQ.Data;
using VeltriQ.Services.Interfaces;
using VeltriQ.ViewModels;

namespace VeltriQ.Services
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuViewModel>> GetMenusByRoleAsync(int roleId)
        {
            var menus = await
            (
                from menu in _context.AppMenus

                join permission in _context.RoleMenuPermissions
                    on menu.MenuId equals permission.MenuId

                where permission.RoleId == roleId
                      && permission.CanView
                      && permission.IsActive
                      && menu.IsActive
                      && menu.IsVisible

                orderby menu.DisplayOrder

                select new MenuViewModel
                {
                    MenuId = menu.MenuId,

                    ParentMenuId = menu.ParentMenuId,

                    MenuName = menu.MenuName,

                    MenuIcon = menu.MenuIcon,

                    ControllerName = menu.ControllerName,

                    ActionName = menu.ActionName,

                    Url = menu.Url,

                    IsDropdown = menu.IsDropdown
                }

            ).ToListAsync();

            var parentMenus = menus
                .Where(x => x.ParentMenuId == null)
                .OrderBy(x => x.MenuId)
                .ToList();

            foreach (var parent in parentMenus)
            {
                parent.Children = menus
                    .Where(x => x.ParentMenuId == parent.MenuId)
                    .OrderBy(x => x.MenuId)
                    .ToList();
            }

            return parentMenus;
        }
    }
}