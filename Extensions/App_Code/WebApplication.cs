using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Piranha.WebPages;

/// <summary>
/// Main class for initializing the application.
/// </summary>
public static class WebApplication
{
	/// <summary>
	/// Initializes the webb app.
	/// </summary>
	public static void AppInitialize() {
		WebPiranha.Init() ;
		WebPiranha.InitServices() ;

		// First add the menu item for products pointing to our simple product controller
		Manager.Menu.Where(m => m.InternalId == "Content").Single().Items.Insert(2,
			new Manager.MenuItem() {
				InternalId = "Products",
				Name = "Products",
				Controller = "product",
				Action = "index",
				Permission = "ADMIN_POST"
			}) ;

		// Now lets filter the available templates for the product and post view.
		// Let's also change the title for the product list view.
		Hooks.Manager.PostListModelLoaded += (controller, menu, model) => {
			if (menu.InternalId == "Products") {
				model.Posts = model.Posts.Where(p => p.TemplateName == "Standard product" || p.TemplateName == "Special product").ToList() ;
				model.Templates = model.Templates.Where(t => t.Name == "Standard product" || t.Name == "Special product").ToList() ;
				controller.ViewBag.Title = "Products" ;
			} else {
				model.Posts = model.Posts.Where(p => p.TemplateName != "Standard product" && p.TemplateName != "Special product").ToList() ;
				model.Templates = model.Templates.Where(t => t.Name != "Standard product" && t.Name != "Special product").ToList() ;
			}
		} ;

		// In edit mode, remove the product extension if we're not in the product view and
		// also change the page title for product view.
		Hooks.Manager.PostEditModelLoaded += (controller, menu, model) => {
			if (menu.InternalId == "Products") {
				if (model.Post.IsNew)
					controller.ViewBag.Title = "Add new product" ;
				else controller.ViewBag.Title = "Edit product" ;
			} else {
				model.Extensions = model.Extensions.Where(e => e.Type != "ProductExtension").ToList() ;
			}
		} ;
	}
}