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

[assembly: RegisterDocumentType(Home.CLASS_NAME, typeof(Home))]

namespace CMS.DocumentEngine.Types.DeleteBoilerplate
{
    /// <summary>
    /// Represents a content item of type Home.
    /// </summary>
    public partial class Home : TreeNode
    {
        #region "Constants and variables"

        /// <summary>
        /// The name of the data class.
        /// </summary>
        public const string CLASS_NAME = "DeleteBoilerplate.Home";


        /// <summary>
        /// The instance of the class that provides extended API for working with Home fields.
        /// </summary>
        private readonly HomeFields mFields;

        #endregion


        #region "Properties"

        /// <summary>
        /// HomePageID.
        /// </summary>
        [DatabaseIDField]
        public int HomePageID
        {
            get
            {
                return ValidationHelper.GetInteger(GetValue("HomePageID"), 0);
            }
            set
            {
                SetValue("HomePageID", value);
            }
        }


        /// <summary>
        /// CustomField.
        /// </summary>
        [DatabaseField]
        public string CustomField
        {
            get
            {
                return ValidationHelper.GetString(GetValue("CustomField"), @"");
            }
            set
            {
                SetValue("CustomField", value);
            }
        }


        /// <summary>
        /// Gets an object that provides extended API for working with Home fields.
        /// </summary>
        [RegisterProperty]
        public HomeFields Fields
        {
            get
            {
                return mFields;
            }
        }


        /// <summary>
        /// Provides extended API for working with Home fields.
        /// </summary>
        [RegisterAllProperties]
        public partial class HomeFields : AbstractHierarchicalObject<HomeFields>
        {
            /// <summary>
            /// The content item of type Home that is a target of the extended API.
            /// </summary>
            private readonly Home mInstance;


            /// <summary>
            /// Initializes a new instance of the <see cref="HomeFields" /> class with the specified content item of type Home.
            /// </summary>
            /// <param name="instance">The content item of type Home that is a target of the extended API.</param>
            public HomeFields(Home instance)
            {
                mInstance = instance;
            }


            /// <summary>
            /// HomePageID.
            /// </summary>
            public int PageID
            {
                get
                {
                    return mInstance.HomePageID;
                }
                set
                {
                    mInstance.HomePageID = value;
                }
            }


            /// <summary>
            /// CustomField.
            /// </summary>
            public string CustomField
            {
                get
                {
                    return mInstance.CustomField;
                }
                set
                {
                    mInstance.CustomField = value;
                }
            }
        }

        #endregion


        #region "Constructors"

        /// <summary>
        /// Initializes a new instance of the <see cref="Home" /> class.
        /// </summary>
        public Home() : base(CLASS_NAME)
        {
            mFields = new HomeFields(this);
        }

        #endregion
    }
}