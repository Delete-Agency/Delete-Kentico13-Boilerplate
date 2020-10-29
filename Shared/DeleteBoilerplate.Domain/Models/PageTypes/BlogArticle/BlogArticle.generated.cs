//--------------------------------------------------------------------------------------------------
// <auto-generated>
//
//     This code was generated by code generator tool.
//
//     To customize the code use your own partial class. For more info about how to use and customize
//     the generated code see the documentation at https://docs.xperience.io/.
//
// </auto-generated>
//--------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using CMS;
using CMS.Base;
using CMS.Helpers;
using CMS.DataEngine;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.DeleteBoilerplate;

[assembly: RegisterDocumentType(BlogArticle.CLASS_NAME, typeof(BlogArticle))]

namespace CMS.DocumentEngine.Types.DeleteBoilerplate
{
	/// <summary>
	/// Represents a content item of type BlogArticle.
	/// </summary>
	public partial class BlogArticle : TreeNode
	{
		#region "Constants and variables"

		/// <summary>
		/// The name of the data class.
		/// </summary>
		public const string CLASS_NAME = "DeleteBoilerplate.BlogArticle";


		/// <summary>
		/// The instance of the class that provides extended API for working with BlogArticle fields.
		/// </summary>
		private readonly BlogArticleFields mFields;

		#endregion


		#region "Properties"

		/// <summary>
		/// BlogArticleID.
		/// </summary>
		[DatabaseIDField]
		public int BlogArticleID
		{
			get
			{
				return ValidationHelper.GetInteger(GetValue("BlogArticleID"), 0);
			}
			set
			{
				SetValue("BlogArticleID", value);
			}
		}


		/// <summary>
		/// Name.
		/// </summary>
		[DatabaseField]
		public string Name
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Name"), @"");
			}
			set
			{
				SetValue("Name", value);
			}
		}


		/// <summary>
		/// Description.
		/// </summary>
		[DatabaseField]
		public string Description
		{
			get
			{
				return ValidationHelper.GetString(GetValue("Description"), @"");
			}
			set
			{
				SetValue("Description", value);
			}
		}


		/// <summary>
		/// Include in sitemap.
		/// </summary>
		[DatabaseField]
		public bool IncludeInSitemap
		{
			get
			{
				return ValidationHelper.GetBoolean(GetValue("IncludeInSitemap"), true);
			}
			set
			{
				SetValue("IncludeInSitemap", value);
			}
		}


		/// <summary>
		/// Sitemap priority.
		/// </summary>
		[DatabaseField]
		public decimal SitemapPriority
		{
			get
			{
				return ValidationHelper.GetDecimal(GetValue("SitemapPriority"), ValidationHelper.GetDecimal("0.5", 0));
			}
			set
			{
				SetValue("SitemapPriority", value);
			}
		}


		/// <summary>
		/// Gets an object that provides extended API for working with BlogArticle fields.
		/// </summary>
		[RegisterProperty]
		public BlogArticleFields Fields
		{
			get
			{
				return mFields;
			}
		}


		/// <summary>
		/// Provides extended API for working with BlogArticle fields.
		/// </summary>
		[RegisterAllProperties]
		public partial class BlogArticleFields : AbstractHierarchicalObject<BlogArticleFields>
		{
			/// <summary>
			/// The content item of type BlogArticle that is a target of the extended API.
			/// </summary>
			private readonly BlogArticle mInstance;


			/// <summary>
			/// Initializes a new instance of the <see cref="BlogArticleFields" /> class with the specified content item of type BlogArticle.
			/// </summary>
			/// <param name="instance">The content item of type BlogArticle that is a target of the extended API.</param>
			public BlogArticleFields(BlogArticle instance)
			{
				mInstance = instance;
			}


			/// <summary>
			/// BlogArticleID.
			/// </summary>
			public int ID
			{
				get
				{
					return mInstance.BlogArticleID;
				}
				set
				{
					mInstance.BlogArticleID = value;
				}
			}


			/// <summary>
			/// Name.
			/// </summary>
			public string Name
			{
				get
				{
					return mInstance.Name;
				}
				set
				{
					mInstance.Name = value;
				}
			}


			/// <summary>
			/// Description.
			/// </summary>
			public string Description
			{
				get
				{
					return mInstance.Description;
				}
				set
				{
					mInstance.Description = value;
				}
			}


			/// <summary>
			/// Include in sitemap.
			/// </summary>
			public bool IncludeInSitemap
			{
				get
				{
					return mInstance.IncludeInSitemap;
				}
				set
				{
					mInstance.IncludeInSitemap = value;
				}
			}


			/// <summary>
			/// Sitemap priority.
			/// </summary>
			public decimal SitemapPriority
			{
				get
				{
					return mInstance.SitemapPriority;
				}
				set
				{
					mInstance.SitemapPriority = value;
				}
			}
		}

		#endregion


		#region "Constructors"

		/// <summary>
		/// Initializes a new instance of the <see cref="BlogArticle" /> class.
		/// </summary>
		public BlogArticle() : base(CLASS_NAME)
		{
			mFields = new BlogArticleFields(this);
		}

		#endregion
	}
}