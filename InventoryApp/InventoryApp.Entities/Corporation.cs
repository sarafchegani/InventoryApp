using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class Corporation
    {
        public int CorporationId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Description { get; set; }

        //Delete
        public virtual User DeletedUser { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? DeletedByUserId { get; set; }

        //Created
        public virtual User CreatedUser { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }

        //Changed
        public virtual User ChangedUser { get; set; }
        public DateTime? ChangedDate { get; set; }
        public int? ChangedByUserId { get; set; }




        public ICollection<Inventory> Inventories { get; set; }
       

        public static EntityTypeConfiguration<Corporation> Map()
        {
            var map = new EntityTypeConfiguration<Corporation>();
            map.Property(C=>C.Title).HasMaxLength(200).IsRequired();
            map.Property(C=>C.Description).HasMaxLength(1000);
            map.Property(C=>C.Address).HasMaxLength(1000);
            map.HasOptional(C => C.DeletedUser).WithMany(U => U.DeletedCorporition).HasForeignKey(I => I.DeletedByUserId);
            map.HasRequired(C=>C.CreatedUser).WithMany(U => U.CreatedCorporition).HasForeignKey(I => I.CreatedByUserId).WillCascadeOnDelete(false);
            map.HasOptional(C=>C.ChangedUser).WithMany(U => U.ChangedCorporition).HasForeignKey(I => I.ChangedByUserId);
            return map;
        }
    }
}
