using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Heading)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.Summary)
                .HasMaxLength(500);

            this.Property(t => t.Description)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Categories");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Heading).HasColumnName("Heading");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
