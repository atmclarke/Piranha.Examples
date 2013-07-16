using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using Piranha.Extend;

/// <summary>
/// Generic user extension that is applied to all users.
/// </summary>
[Export(typeof(IExtension))]
[ExportMetadata("InternalId", "ContactAddress")]
[ExportMetadata("Name", "Contact address")]
[ExportMetadata("Type", ExtensionType.User)]
[Serializable]
public class UserExtension : Extension
{
	#region Members
	/// <summary>
	/// Internal member for the countries.
	/// </summary>
	[ScriptIgnore]
	private List<object> countries = null ;
	#endregion

	#region Properties
	/// <summary>
	/// Gets/sets the street address.
	/// </summary>
	public string StreetAddress { get ; set ; }

	/// <summary>
	/// Gets/sets the postal zip code.
	/// </summary>
	public string ZipCode { get ; set ; }

	/// <summary>
	/// Gets/sets the country.
	/// </summary>
	public string Country { get ; set ; }

	/// <summary>
	/// This property is used in manager and should not be serialized
	/// as data.
	/// </summary>
	[ScriptIgnore]
	public SelectList Countries { get ; set ; }
	#endregion

	/// <summary>
	/// Default constructor. Creates a new user extension.
	/// </summary>
	public UserExtension() {
		countries = CultureInfo.GetCultures(CultureTypes.AllCultures)
			.OrderBy(c => c.EnglishName)
			.Select(c => (object)new { Name = c.EnglishName })
			.ToList() ;
		Countries = new SelectList(countries, "Name", "Name") ;
	}

	/// <summary>
	/// Initializes the extension when loaded in the manager interface.
	/// </summary>
	/// <param name="model">The current edit model</param>
	public override void Init(object model) {
		Countries = new SelectList(countries, "Name", "Name", Country) ;
	}
}