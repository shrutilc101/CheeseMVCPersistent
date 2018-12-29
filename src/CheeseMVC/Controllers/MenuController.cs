using System;
using System.Collections.Generic;
using System.Linq;
using CheeseMVC.ViewModels;
using CheeseMVC.Data;
using CheeseMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace CheeseMVC.Controllers
{
    public class MenuController : Controller

    {
        private readonly CheeseDbContext context;

        public MenuController(CheeseDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
        }

        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                };
                context.Menus.Add(newMenu);
                context.SaveChanges();
                return Redirect("/Menu/ViewMenu/" + newMenu.ID);

            }
            else
            {
                return View(addMenuViewModel);
            }

        }

        public IActionResult ViewMenu(int id)
        {
            Menu menu = context.Menus.Single(c => c.ID == id);

            List<CheeseMenu> items = context.CheeseMenus.Include(item => item.Cheese)
                .Where(cm => cm.MenuID == id).ToList();

            ViewMenuViewModel viewMenuViewModel = new ViewMenuViewModel
            {
                Menu = menu,
                Items = items
            };

            return View(viewMenuViewModel);


        }

        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
            List<Cheese> cheeses = context.Cheeses.ToList();
            AddMenuItemViewModel addMenuItemViewModel = new AddMenuItemViewModel(menu, cheeses);
            return View(addMenuItemViewModel);
        }

        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var cheeseID = addMenuItemViewModel.CheeseID;
                var menuID = addMenuItemViewModel.MenuID;

                IList<CheeseMenu> existingItems = context.CheeseMenus
                    .Where(cm => cm.CheeseID == cheeseID)
                    .Where(cm => cm.MenuID == menuID).ToList();

                if (existingItems.Count == 0)
                {
                    CheeseMenu menuItem = new CheeseMenu
                    {
                        CheeseID = cheeseID,
                        MenuID = menuID
                    };

                    context.CheeseMenus.Add(menuItem);
                    context.SaveChanges();
                    return Redirect($"/Menu/Viewmenu/{menuItem.MenuID}");

                }
                else
                {
                    return View($"/Menu/ViewMenu/{addMenuItemViewModel.MenuID}");
                }
            }
            else
            {
                return View(addMenuItemViewModel);
            }


            }
        }
        
    }

