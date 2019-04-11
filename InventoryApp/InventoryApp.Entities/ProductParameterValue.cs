using System.Data.Entity.ModelConfiguration;

namespace InventoryApp.Entities
{
    public class ProductParameterValue
    {
        public int ProductId { get; set; }
        public int ProductParameterId { get; set; }
        public string Value { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductParameter ProductParameter { get; set; }

        public static EntityTypeConfiguration<ProductParameterValue> Map()
        {
            var map = new EntityTypeConfiguration<ProductParameterValue>();
            map.HasRequired(P => P.Product).WithMany(p => p.ProductParameterValues).HasForeignKey(p => p.ProductId).WillCascadeOnDelete(false); 
            map.HasRequired(P => P.ProductParameter).WithMany(p => p.ProductParameterValues).HasForeignKey(p => p.ProductParameterId).WillCascadeOnDelete(false); 
            map.HasKey(P => new { P.ProductId, P.ProductParameterId });
            return map;
        }
    }
}
