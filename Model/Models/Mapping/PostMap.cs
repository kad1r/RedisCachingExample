using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Model.Models.Mapping
{
    public class PostMap : EntityTypeConfiguration<Post>
    {
        public PostMap()
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

            this.Property(t => t.FriendlyUrl)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.Tags)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Posts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.Heading).HasColumnName("Heading");
            this.Property(t => t.Summary).HasColumnName("Summary");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.FriendlyUrl).HasColumnName("FriendlyUrl");
            this.Property(t => t.Tags).HasColumnName("Tags");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.ReadTime).HasColumnName("ReadTime");
            this.Property(t => t.ReadCount).HasColumnName("ReadCount");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Posts)
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
