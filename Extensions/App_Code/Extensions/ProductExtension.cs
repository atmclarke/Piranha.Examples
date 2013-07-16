using System;
using System.ComponentModel.Composition;

using Piranha.Extend;

/// <summary>
/// A simple product extension applied to posts of the type "Standard product" and "Special product"
/// </summary>
[Export(typeof(IExtension))]
[ExportMetadata("InternalId", "ProductExtension")]
[ExportMetadata("Name", "Specification")]
[ExportMetadata("Type", ExtensionType.Post)]
[Serializable]
public class ProductExtension : Extension
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