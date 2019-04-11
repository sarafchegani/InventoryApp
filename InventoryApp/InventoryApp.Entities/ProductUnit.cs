﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class ProductUnit
    {
        public int ProductUnitId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //Delete
        public virtual User DeletedUser { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public int? DeletedByUserId { get; set; }

        //Created
        public virtual User CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }

        //Changed
        public virtual User ChangedUser { get; set; }
        public DateTime ChangedDate { get; set; }
        public int? ChangedByUserId { get; set; }

        public static EntityTypeConfiguration<ProductUnit> Map()
        {
            var map = new EntityTypeConfiguration<ProductUnit>();
            map.Property(C => C.Title).HasMaxLength(200).IsRequired();
            map.Property(C => C.Description).HasMaxLength(1000);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedProductUnit).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(C => C.CreatedUser).WithMany(U => U.CreatedProductUnit).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C => C.ChangedUser).WithMany(U => U.ChangedProductUnit).HasForeignKey(I => I.ChangedByUserId);
            map.Property(U => U.Title).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Ix_Title_Unique") { IsUnique = true }));
            return map;
        }
    }
}