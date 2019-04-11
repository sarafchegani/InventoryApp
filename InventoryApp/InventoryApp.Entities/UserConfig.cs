using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public partial  class User
    {
        //corporition
        public virtual ICollection<Corporation> DeletedCorporition { get; set; }
        public virtual ICollection<Corporation> CreatedCorporition { get; set; }
        public virtual ICollection<Corporation> ChangedCorporition { get; set; }

        //Inventory
        public virtual ICollection<Inventory> DeletedInventory { get; set; }
        public virtual ICollection<Inventory> CreatedInventory { get; set; }
        public virtual ICollection<Inventory> ChangedInventory { get; set; }

        //ProductUnit
        public virtual ICollection<ProductUnit> DeletedProductUnit { get; set; }
        public virtual ICollection<ProductUnit> CreatedProductUnit { get; set; }
        public virtual ICollection<ProductUnit> ChangedProductUnit { get; set; }

        //ProductCategory
        public virtual ICollection<ProductCategory> DeletedProductCategory { get; set; }
        public virtual ICollection<ProductCategory> CreatedProductCategory { get; set; }
        public virtual ICollection<ProductCategory> ChangedProductCategory { get; set; }

        //Product
        public virtual ICollection<Product> DeletedProduct { get; set; }
        public virtual ICollection<Product> CreatedProduct { get; set; }
        public virtual ICollection<Product> ChangedProduct { get; set; }

        //ProductParameter
        public virtual ICollection<ProductParameter> DeletedProductParameter { get; set; }
        public virtual ICollection<ProductParameter> CreatedProductParameter { get; set; }
        public virtual ICollection<ProductParameter> ChangedProductParameter { get; set; }

        //InventoryInsType
        public virtual ICollection<InventoryInsType> DeletedInventoryInsType  { get; set; }
        public virtual ICollection<InventoryInsType> CreatedInventoryInsType { get; set; }
        public virtual ICollection<InventoryInsType> ChangedInventoryInsType { get; set; }

        //InventoryInsHeader
        public virtual ICollection<InventoryInsHeader> DeletedInventoryInsHeader { get; set; }
        public virtual ICollection<InventoryInsHeader> CreatedInventoryInsHeader { get; set; }
        public virtual ICollection<InventoryInsHeader> ChangedInventoryInsHeader { get; set; }
        public virtual ICollection<InventoryInsHeader> AccepetedInventoryInsHeader { get; set; }

        //InventoryOutsType
        public virtual ICollection<InventoryOutsType> DeletedInventoryOutsType { get; set; }
        public virtual ICollection<InventoryOutsType> CreatedInventoryOutsType { get; set; }
        public virtual ICollection<InventoryOutsType> ChangedInventoryOutsType { get; set; }

        //InventoryOutsHeader
        public virtual ICollection<InventoryOutsHeader> DeletedInventoryOutsHeader { get; set; }
        public virtual ICollection<InventoryOutsHeader> CreatedInventoryOutsHeader { get; set; }
        public virtual ICollection<InventoryOutsHeader> ChangedInventoryOutsHeader { get; set; }
        public virtual ICollection<InventoryOutsHeader> AccepetedInventoryOutsHeader { get; set; }

        //Role
        public virtual ICollection<Role> Roles { get; set; }





        //public virtual ICollection<Inventory> DeletedInventory { get; set; }
        //public virtual ICollection<Inventory> DeletedUser { get; set; }
        
        //public virtual ICollection<Inventory> DeletedProductUnit { get; set; }
        //public virtual ICollection<Inventory> DeletedProduct { get; set; }
        //public virtual ICollection<Inventory> DeletedProductCategory { get; set; }
        //public virtual ICollection<Inventory> DeletedProductParameter { get; set; }
        //public virtual ICollection<Inventory> DeletedProductParameter { get; set; }


        public static EntityTypeConfiguration<User> Map()
        {
            var map = new EntityTypeConfiguration<User>();
            map.Property(U => U.Username).HasMaxLength(100).IsRequired();
            map.Property(U => U.Password).HasMaxLength(100).IsRequired();
            map.Property(U => U.PasswordSalt).HasMaxLength(100).IsRequired();
            map.Property(U => U.Username).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Ix_Username_Unique") { IsUnique = true }));
            map.HasMany(U => U.Roles).WithMany(R => R.Users).Map(_map => _map.MapLeftKey("UserId").MapRightKey("RoleId").ToTable("UsersRoles"));
            return map;
        }
    }
}
