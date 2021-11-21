using Microsoft.EntityFrameworkCore;
using TopChoiceHardware.Products.Domain.Entities;

namespace TopChoiceHardware.Products.AccessData
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() { }

        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
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


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).ValueGeneratedOnAdd();

                entity.Property(e => e.Brand).HasMaxLength(55);

                entity.Property(e => e.Description).HasMaxLength(300);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(60);



                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productos__Descr__2C3393D0");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Productos__Suppl__2D27B809");
                entity.HasMany(t => t.Images)
                    .WithOne(t => t.Product)
                    .HasForeignKey(t => t.ProductId)
                    .OnDelete(DeleteBehavior.ClientCascade)
                    .HasConstraintName("FK__Products__Image");
            });
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.Property(e => e.ImageId).ValueGeneratedOnAdd();
                
                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Supplier>(entity =>
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

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Procesadores",
                    Description = "Unidad de procesamiento central del PC"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Motherboards",
                    Description = "Circuito impreso donde se conectan todos los componentes de una PC"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Memorias RAM",
                    Description = "Memoria de trabajo para un PC"
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Almacenamiento",
                    Description = "Medios de almacenamiento de informacion para un pc"
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Placas de video",
                    Description = "Tarjeta de expansion del motherboard para procesamiento de graficos"
                }
            );
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier
                {
                    SupplierId = 1,
                    CompanyName = "New Bytes",
                    Email = "INFO@NB.COM.AR",
                    Phone = "(11) 4011-8809",
                    AddressId = 1
                },
                new Supplier
                {
                    SupplierId = 2,
                    CompanyName = "MEGACOM",
                    Email = "ventas@megacom.com.ar",
                    Phone = "(0223) 492-4414",
                    AddressId = 1
                },
                new Supplier
                {
                    SupplierId = 3,
                    CompanyName = "PcRetail",
                    Email = "info@pc-retail.com.ar",
                    Phone = "11 49092100",
                    AddressId = 1
                }
                );
            modelBuilder.Entity<Product>().HasData(
                //Procesadores
                new Product
                {
                    ProductId = 1,
                    ProductName = "Procesador Amd Ryzen 7 5700G 4.6 Ghz - AM4",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 65999,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Todos los procesadores AMD Ryzen serie 5000 cuentan con un conjunto completo de tecnologías diseñadas para elevar la potencia de procesamiento de tu PC, incluidas Precision Boost 25, Precision Boost Overdrive, PCIe 4.0 (en procesadores seleccionados) y Resizable BAR.",
                    Url = "https://www.amd.com/es/products/apu/amd-ryzen-7-5700g",
                    OnSale=false                    
                }
                /*,
                new Product
                {
                    ProductId = 2,
                    ProductName = "Procesador  Intel Core i5 10600KF 4.8 Ghz Comet Lake 1200",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 30499,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Los procesadores para desktop Intel Core de 10 Generación, que cuentan con hasta 5,3 GHz, tecnología Intel Thermal Velocity Boost (Intel TVB), 20 MB de caché inteligente Intel y conexión Intel Ethernet I225 ofrecen a los jugadores y a los profesionales creativos importantes ventajas de desempeño.",
                    Images = { "https://i.imgur.com/1cDE1v4.png?1"},
                    Url = "https://ark.intel.com/content/www/es/es/ark/products/199315/intel-core-i5-10600kf-processor-12m-cache-up-to-4-80-ghz.html"
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Procesador  Intel Core i7 9700F 4.7 Ghz Coffee Lake 1151",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 40499,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Experimente un rendimiento increíble en videojuegos, edite y comparta con fluidez vídeo en 360 grados y disfrute de entretenimiento 4K Ultra HD fantástico, y todo con unas transferencias de datos a la velocidad de la luz que ofrece la tecnología Thunderbolt™ 3.",
                    Images = {"https://i.imgur.com/EFy8fOT.png" },
                    Url = "https://ark.intel.com/content/www/es/es/ark/products/193738/intel-core-i7-9700f-processor-12m-cache-up-to-4-70-ghz.html"
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Procesador  Amd Ryzen 5 5600G 4.4 Ghz - AM4",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 54999,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Cuando cuentas con la arquitectura de procesadores más avanzada del mundo para jugadores y creadores de contenido, las posibilidades son infinitas.Ya sea que juegues los juegos más recientes, diseñes el próximo rascacielos o proceses datos, necesitas un procesador poderoso que pueda dar respuesta.",
                    Images = {"https://i.imgur.com/BI7uFjv.png" },
                    Url = "https://www.amd.com/es/products/apu/amd-ryzen-5-5600g"
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Procesador Intel Core i3 10100 4.3 Ghz Comet Lake 1200",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 27999,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Procesador Intel® Core™ de 10ma Generación equipado con los gráficos Intel. Estos procesadores ofrecen un nuevo nivel de integración que permite potenciar las experiencias de uso de computadoras en la actualidad y en el futuro.",
                    Images = {"https://i.imgur.com/HlWiLZf.png" },
                    Url = "https://www.intel.la/content/www/xl/es/products/sku/199283/intel-core-i310100-processor-6m-cache-up-to-4-30-ghz/specifications.html"
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Procesador Amd Apu A6 A6-9500 3.5 Ghz - AM4",
                    CategoryId = 1,
                    SupplierId = 1,
                    UnitPrice = 6499,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Sumergíte en la tecnología líder para gráficas con la arquitectura Graphics Core Next (GCN) de AMD. Esta tecnología de tercera generación activa las prestaciones avanzadas y el increíble rendimiento de las gráficas AMD Radeon",
                    Images = { "https://i.imgur.com/GJk8cpx.png"},
                    Url = "https://www.amd.com/es/products/apu/7th-gen-a6-9500-apu"
                },
                //Mothers
                new Product
                {
                    ProductId = 7,
                    ProductName = "Motherboard AM4 - Asrock B450M HDV 4.0",
                    CategoryId = 2,
                    SupplierId = 1,
                    UnitPrice = 8999,
                    UnitsInStock = 10,
                    Brand = "Asrock",
                    Description = "Soporta Socket AMD AM4 Ryzen™ 2000, 3000, 4000 G-Series, 5000 y 5000 G-Series Desktop Processors 2 DIMMs, Soporta memoria DDR4 3200 + (OC)",
                    Images = { "https://i.imgur.com/kgyIGNT.png"},
                    Url = "https://www.asrock.com/mb/AMD/B450M-HDV%20R4.0/index.la.asp#Specification"
                },
                 new Product
                 {
                     ProductId = 8,
                     ProductName = "Motherboard AM4 - Gigabyte GA-B550 AORUS ELITE AX V2",
                     CategoryId = 2,
                     SupplierId = 1,
                     UnitPrice = 30999,
                     UnitsInStock = 10,
                     Brand = "AORUS",
                     Description = "Supports AMD Ryzen™ 5000 Series / Ryzen™ 5000 G - Series / Ryzen™ 4000 G - Series and Ryzen™ 3000 Series Processors Dual Channel ECC / Non - ECC Unbuffered DDR4, 4 DIMMs",
                     Images = { "https://i.imgur.com/yjl0knB.png"},
                     Url = "https://www.gigabyte.com/ar/Motherboard/B550-AORUS-ELITE-AX-V2-rev-10#kf"
                 },
                 new Product
                 {
                     ProductId = 9,
                     ProductName = "Motherboard AM4 - Asus Tuf X570-PLUS WIFI",
                     CategoryId = 2,
                     SupplierId = 1,
                     UnitPrice = 34999,
                     UnitsInStock = 10,
                     Brand = "Asus TUF",
                     Description = "Socket AMD AM4: Listo para los procesadores AMD RyzenTM de 2da y 3ra generación. 4 x DIMM, Max. 128GB, DDR4 4400(O.C)/3466(O.C.)/3400(O.C.)/3200(O.C.)/3000(O.C.)/2933(O.C.)/2800(O.C.)/2666/2400/2133",
                     Images = { "https://i.imgur.com/4nmN1jo.png"},
                     Url = "https://www.asus.com/latin/Motherboards-Components/Motherboards/TUF-Gaming/TUF-GAMING-X570-PLUS-WI-FI/"
                 },
                 new Product
                 {
                     ProductId = 10,
                     ProductName = "Motherboard AM4 - Msi A320M PRO VH",
                     CategoryId = 2,
                     SupplierId = 1,
                     UnitPrice = 7499,
                     UnitsInStock = 10,
                     Brand = "MSI",
                     Description = "AMD Socket AM4 , AMD® A320 Chipset, Supports DDR4 1866/ 2133/ 2400/ 2667/ 2800/ 2933/ 3000/ 3066/ 3200 MHz",
                     Images = {"https://i.imgur.com/SoVh1gC.png" },
                     Url = "https://www.msi.com/Motherboard/A320M-PRO-VH"
                 },
                 new Product
                 {
                     ProductId = 11,
                     ProductName = "Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury",
                     CategoryId = 3,
                     SupplierId = 2,
                     UnitPrice = 4499,
                     UnitsInStock = 10,
                     Brand = "Kingston",
                     Description = "Capacidad de 4 GB, velocidad de 3200 MHz, tecnología  DDR4.",
                     Images = {"https://i.imgur.com/5Qx2cpJ.png" },
                     Url = ""
                 },
                 new Product
                 {
                     ProductId = 12,
                     ProductName = "Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision",
                     CategoryId = 3,
                     SupplierId = 2,
                     UnitPrice = 12500,
                     UnitsInStock = 10,
                     Brand = "Hikvision",
                     Description = "Capacidad de 16 GB, velocidad de 2666 MHz, tecnología  DDR4.",
                     Images = { "https://i.imgur.com/8xl51WL.png"},
                     Url = ""
                 }*/
                
                );
            modelBuilder.Entity<Image>(e =>
            {
                e.HasData(new Image
                {
                    ImageId = 1,
                    Url = "https://i.imgur.com/O1EfiHW.png",
                    ProductId = 1,
                }); //Imagen 1 Ryzen 7 5700G
                e.HasData(new Image
                {
                    ImageId = 2,
                    Url = "https://i.imgur.com/cRSZLrc.png",
                    ProductId = 1,
                }); //Imagen 2 Ryzen 7 5700G
            }
            );
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Image> Images { get; set; }
    }
}