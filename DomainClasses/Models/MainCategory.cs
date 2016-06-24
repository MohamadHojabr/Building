﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Buolding.Utility;

namespace DomainClasses.Models
{
    public class MainCategory : BaseEntity
    {
        #region Ctor

        /// <summary>
        ///     create one instance of <see cref="MainCategory" />
        /// </summary>
        public MainCategory()
        {
            MainCategoryId = SequentialGuidGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        [Key]
        public Guid MainCategoryId { get; set; }

        public string Name { get; set; }
        public string Describtion { get; set; }

        [NotMapped]
        public bool Checked { get; set; }

        #endregion

        #region NavigationProperties

        public int? ParentId { get; set; }
        public virtual MainCategory Parent { get; set; }
        public virtual ICollection<MainCategory> Children { get; set; }
        public virtual ICollection<PersonalProfile> Profile { get; set; }
        public virtual ICollection<CompanyProfile> CompanyProfiles { get; set; }

        #endregion
    }
}