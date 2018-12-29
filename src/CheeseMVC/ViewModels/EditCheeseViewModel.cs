﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace CheeseMVC.ViewModels
{
    public class EditCheeseViewModel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Add description of your Cheese")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        public List<SelectListItem>Categories { get; set; }

        public EditCheeseViewModel() { }

        public EditCheeseViewModel(Cheese cheese,  IEnumerable<CheeseCategory> categories)
        {
            ID = cheese.ID;
            Name = cheese.Name;
            Description = cheese.Description;
            CategoryID = cheese.CategoryID;

            Categories = new List<SelectListItem>();

            foreach (CheeseCategory cat in categories)
            {
                Categories.Add(new SelectListItem
                {
                    Value = cat.ID.ToString(),
                    Text = cat.Name

                });
            }
        }

    }
}
