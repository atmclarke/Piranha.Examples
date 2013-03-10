using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Piranha.Extend;

/// <summary>
/// A simple product extension applied to posts of the type "Standard product" and "Special product"
/// </summary>
[Extension(InternalId="ProductExtension", Name="Specification", Type=ExtensionType.Post)]
public class ProductExtension : IExtension
{
	/// <summary>
	/// Gets/sets the price.
	/// </summary>
	public int Price { get ; set ; }

	/// <summary>
	/// Gets/sets how many products are available in stock.
	/// </summary>
	public int InStock { get ; set ; }
}