using Microsoft.EntityFrameworkCore;

namespace DTOCore;

public partial class TsmgContext : DbContext
{
    public TsmgContext()
    {
    }

    public TsmgContext(DbContextOptions<TsmgContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=TSMG;Trusted_Connection=True;user id=sa;password=17102003;TrustServerCertificate=True");
#pragma warning restore CS1030 // #warning directive

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.ToTable("order");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Total).HasColumnName("total");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_user_account1");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Odid);

            entity.ToTable("order_detail");

            entity.Property(e => e.Odid).HasColumnName("odid");
            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_detail_order1");

            entity.HasOne(d => d.PidNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.Pid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_order_detail_product1");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("product");

            entity.Property(e => e.Pid).HasColumnName("pid");
            entity.Property(e => e.Pimg)
                .IsRequired()
                .HasMaxLength(1024)
                .HasColumnName("pimg");
            entity.Property(e => e.Pinfo)
                .IsRequired()
                .HasMaxLength(256)
                .HasColumnName("pinfo");
            entity.Property(e => e.Pname)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnName("pname");
            entity.Property(e => e.Pprice).HasColumnName("pprice");
            entity.Property(e => e.Pquantity).HasColumnName("pquantity");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.ToTable("user_account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("phone");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(16)
                .HasColumnName("type");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
