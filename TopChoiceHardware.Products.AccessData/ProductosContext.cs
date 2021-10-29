using Microsoft.EntityFrameworkCore;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.AccessData
{
    public class ProductosContext : DbContext
    {
        public ProductosContext() { }

        public ProductosContext(DbContextOptions<ProductosContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).ValueGeneratedOnAdd();

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(255);
            });


            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.Property(e => e.Brand).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);



                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productos__Descr__2C3393D0");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productos__Suppl__2D27B809");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.SupplierId).ValueGeneratedOnAdd();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    CategoryId = 1,
                    CategoryName = "Procesadores",
                    Description = "Unidad de procesamiento central del PC"
                },
                new Categoria
                {
                    CategoryId = 2,
                    CategoryName = "Motherboards",
                    Description = "Circuito impreso donde se conectan todos los componentes de una PC"
                },
                new Categoria
                {
                    CategoryId = 3,
                    CategoryName = "Memorias RAM",
                    Description = "Memoria de trabajo para un PC"
                },
                new Categoria
                {
                    CategoryId = 4,
                    CategoryName = "Almacenamiento",
                    Description = "Medios de almacenamiento de informacion para un pc"
                },
                new Categoria
                {
                    CategoryId = 5,
                    CategoryName = "Placas de video",
                    Description = "Tarjeta de expansion del motherboard para procesamiento de graficos"
                }
            );
            modelBuilder.Entity<Proveedor>().HasData(
                new Proveedor
                {
                    SupplierId = 1,
                    CompanyName = "New Bytes",
                    Email = "INFO@NB.COM.AR",
                    Phone = "(11) 4011-8809",
                    AddressId = 1
                },
                new Proveedor
                {
                    SupplierId = 2,
                    CompanyName = "MEGACOM",
                    Email = "ventas@megacom.com.ar",
                    Phone = "(0223) 492-4414",
                    AddressId = 1
                },
                new Proveedor
                {
                    SupplierId = 3,
                    CompanyName = "PcRetail",
                    Email = "info@pc-retail.com.ar",
                    Phone = "11 49092100",
                    AddressId = 1
                }
                );
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    ProductId = 1,
                    ProductName = "Amd Ryzen 7 5700G 4.6 Ghz - AM4",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 66000,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Todos los procesadores AMD Ryzen serie 5000 cuentan con un conjunto completo de tecnologías diseñadas para elevar la potencia de procesamiento de tu PC, incluidas Precision Boost 25, Precision Boost Overdrive, PCIe 4.0 (en procesadores seleccionados) y Resizable BAR.",
                    Image = "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40369_1.jpeg?v252?v348?v928",
                    Url = "https://www.amd.com/es/products/apu/amd-ryzen-7-5700g"
                },
                new Producto
                {
                    ProductId = 2,
                    ProductName = "Intel Core i5 10600KF 4.8 Ghz Comet Lake 1200",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 30500,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Los procesadores para desktop Intel Core de 10 Generación, que cuentan con hasta 5,3 GHz, tecnología Intel Thermal Velocity Boost (Intel TVB), 20 MB de caché inteligente Intel y conexión Intel Ethernet I225 ofrecen a los jugadores y a los profesionales creativos importantes ventajas de desempeño.",
                    Image = "https://mexx-img-2019.s3.amazonaws.com/39495_1.jpeg",
                    Url = "https://ark.intel.com/content/www/es/es/ark/products/199315/intel-core-i5-10600kf-processor-12m-cache-up-to-4-80-ghz.html"
                },
                new Producto
                {
                    ProductId = 3,
                    ProductName = "Intel Core i7 9700F 4.7 Ghz Coffee Lake 1151",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 40500,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Experimente un rendimiento increíble en videojuegos, edite y comparta con fluidez vídeo en 360 grados y disfrute de entretenimiento 4K Ultra HD fantástico, y todo con unas transferencias de datos a la velocidad de la luz que ofrece la tecnología Thunderbolt™ 3.",
                    Image = "https://mexx-img-2019.s3.amazonaws.com/36566_1.jpeg",
                    Url = "https://ark.intel.com/content/www/es/es/ark/products/193738/intel-core-i7-9700f-processor-12m-cache-up-to-4-70-ghz.html"
                },
                new Producto
                {
                    ProductId = 4,
                    ProductName = "Amd Ryzen 5 5600G 4.4 Ghz - AM4",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 55000,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Cuando cuentas con la arquitectura de procesadores más avanzada del mundo para jugadores y creadores de contenido, las posibilidades son infinitas.Ya sea que juegues los juegos más recientes, diseñes el próximo rascacielos o proceses datos, necesitas un procesador poderoso que pueda dar respuesta.",
                    Image = "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40368_1.jpeg",
                    Url = "https://www.amd.com/es/products/apu/amd-ryzen-5-5600g"
                }
                );
        }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
    }
}