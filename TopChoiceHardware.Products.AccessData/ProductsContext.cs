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

                entity.HasMany(t => t.Carousel)
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
            modelBuilder.Entity<Product>().HasData(
                //Procesadores
                new Product
                {
                    ProductId = 1,
                    ProductName = "Procesador Amd Ryzen 7 5700G 4.6 Ghz - AM4",
                    CategoryId = 1,
                    UnitPrice = 65999,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Procesador AMD Ryzen 5ta generación equipado con gráficos integrados. Incluye 8 núcleos de CPU, una velocidad de reloj base de 3,8 GHz y 8 núcleos de GPU.",
                    Image = "https://i.imgur.com/O1EfiHW.png",
                    Url = "https://www.amd.com/es/products/apu/amd-ryzen-7-5700g",
                    OnSale = false
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Procesador  Intel Core i5 10600KF 4.8 Ghz Comet Lake 1200",
                    CategoryId = 1,
                    UnitPrice = 30499,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Procesador Intel® Core™ de 10ma Generación. Sin gráficos integrados, Incluye 6 núcleos 4.1GHz (hasta 4.8 Ghz), Socket 1200, Caché 12 MB",
                    Image = "https://i.imgur.com/1cDE1v4.png?1",
                    Url = "https://ark.intel.com/content/www/es/es/ark/products/199315/intel-core-i5-10600kf-processor-12m-cache-up-to-4-80-ghz.html",
                    OnSale = false
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Procesador  Intel Core i7 9700F 4.7 Ghz Coffee Lake 1151",
                    CategoryId = 1,
                    UnitPrice = 40499,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Procesador Intel Core i7-9700F de Novena Generación. Sin gráficos integrados, incluye 8 núcleos 3.0 GHz (hasta 4.7 GHz), Socket 1151, Caché 12 MB",
                    Image = "https://i.imgur.com/pPlPUe6.png",
                    Url = "https://ark.intel.com/content/www/es/es/ark/products/193738/intel-core-i7-9700f-processor-12m-cache-up-to-4-70-ghz.html",
                    OnSale = false
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Procesador  Amd Ryzen 5 5600G 4.4 Ghz - AM4",
                    CategoryId = 1,
                    UnitPrice = 54999,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Procesador AMD Ryzen 5ta generación equipado con gráficos integrados. Incluye seis núcleos de CPU, una velocidad de reloj base de 3,9 GHz y siete núcleos de GPU",
                    Image = "https://i.imgur.com/BI7uFjv.png",
                    Url = "https://www.amd.com/es/products/apu/amd-ryzen-5-5600g",
                    OnSale = false
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Procesador Intel Core i3 10100 4.3 Ghz Comet Lake 1200",
                    CategoryId = 1,
                    UnitPrice = 27999,
                    UnitsInStock = 5,
                    Brand = "INTEL",
                    Description = "Procesador Intel® Core™ de 10ma Generación equipado con los gráficos Intel. Incluye 4 núcleos y 8 hilos de procesamiento, velocidad base de i3-10100 de 3.6 GHZ y turbo hasta 4.3 GHZ, Socket 1200, 6MB Caché.",
                    Image = "https://i.imgur.com/0RdBm8b.png",
                    Url = "https://www.intel.la/content/www/xl/es/products/sku/199283/intel-core-i310100-processor-6m-cache-up-to-4-30-ghz/specifications.html",
                    OnSale = false
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Procesador Amd Apu A6 A6-9500 3.5 Ghz - AM4",
                    CategoryId = 1,
                    UnitPrice = 6499,
                    UnitsInStock = 10,
                    Brand = "AMD",
                    Description = "Procesador AMD A series de 7ma generación equipado con gráficos integrados. Incluye 2 núcleos 3.5 Ghz, Socket AM4, Caché 1 MB",
                    Image = "https://i.imgur.com/etwcYDJ.png",
                    Url = "https://www.amd.com/es/products/apu/7th-gen-a6-9500-apu",
                    OnSale = false
                },
                //Mothers
                new Product
                {
                    ProductId = 7,
                    ProductName = "Motherboard AM4 - Asrock B450M HDV 4.0",
                    CategoryId = 2,
                    UnitPrice = 8999,
                    UnitsInStock = 10,
                    Brand = "Asrock",
                    Description = "Socket AMD AM4 Ryzen™ 2000, 3000, 4000 G-Series, 5000 y 5000 G-Series Desktop Processors 2 RAM DIMMs DDR4 3200 + (OC)",
                    Image = "https://i.imgur.com/U7fAUnj.png",
                    Url = "https://www.asrock.com/mb/AMD/B450M-HDV%20R4.0/index.la.asp#Specification",
                    OnSale = false
                },
                 new Product
                 {
                     ProductId = 8,
                     ProductName = "Motherboard AM4 - Gigabyte GA-B550 AORUS ELITE AX V2",
                     CategoryId = 2,
                     UnitPrice = 30999,
                     UnitsInStock = 10,
                     Brand = "AORUS",
                     Description = "Socket AMD AM4 Ryzen™ 5000 Series / Ryzen™ 5000 G - Series / Ryzen™ 4000 G - Series and Ryzen™ 3000 Series Processors Dual Channel 4 DIMMs DDR4 ",
                     Image = "https://i.imgur.com/yjl0knB.png",
                     Url = "https://www.gigabyte.com/ar/Motherboard/B550-AORUS-ELITE-AX-V2-rev-10#kf",
                     OnSale = false
                 },
                 new Product
                 {
                     ProductId = 9,
                     ProductName = "Motherboard AM4 - Asus Tuf X570-PLUS WIFI",
                     CategoryId = 2,
                     UnitPrice = 34999,
                     UnitsInStock = 10,
                     Brand = "Asus TUF",
                     Description = "Socket AMD AM4: Listo para los procesadores AMD RyzenTM de 2da y 3ra generación. 4 x DIMM DDR4, Max. 128GB ",
                     Image = "https://i.imgur.com/4nmN1jo.png",
                     Url = "https://www.asus.com/latin/Motherboards-Components/Motherboards/TUF-Gaming/TUF-GAMING-X570-PLUS-WI-FI/",
                     OnSale = false
                 },
                 new Product
                 {
                     ProductId = 10,
                     ProductName = "Motherboard AM4 - Msi A320M PRO VH",
                     CategoryId = 2,
                     UnitPrice = 7499,
                     UnitsInStock = 10,
                     Brand = "MSI",
                     Description = "Socket AMD AM4 , Soporta procesadores AMD® Ryzen™ 1ra y 2da Generación, 2 DIMMs DDR4",
                     Image = "https://i.imgur.com/SoVh1gC.png",
                     Url = "https://www.msi.com/Motherboard/A320M-PRO-VH",
                     OnSale = false
                 },
                 new Product
                 {
                     ProductId = 11,
                     ProductName = "Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury",
                     CategoryId = 3,
                     UnitPrice = 4499,
                     UnitsInStock = 10,
                     Brand = "Kingston",
                     Description = "Capacidad de 4 GB, velocidad de 3200 MHz, tecnología  DDR4.",
                     Image = "https://i.imgur.com/5Qx2cpJ.png",
                     Url = "https://www.kingston.com/es/memory/gaming/kingston-fury-beast-ddr4-memory",
                     OnSale = false
                 },
                 new Product
                 {
                     ProductId = 12,
                     ProductName = "Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision",
                     CategoryId = 3,
                     UnitPrice = 12500,
                     UnitsInStock = 10,
                     Brand = "Hikvision",
                     Image = "https://i.imgur.com/wdk29Tl.png",
                     Description = "Capacidad de 16 GB, velocidad de 2666 MHz, tecnología  DDR4.",
                     Url = "https://www.hikvision.com/es-la/",
                     OnSale = false
                 },
                 new Product
                 {
                     ProductId = 13,
                     ProductName = "Seagate Barracuda 1TB",
                     CategoryId = 4,
                     UnitPrice = 5500,
                     UnitsInStock = 10,
                     Brand = "Seagate",
                     Description = "Modelo: ST1000DM010 Interfaz: SATA de 6 Gb/s Capacidad: 1 TB Buffer: 64 MB Velocidad: 7200 RPM. De uso doméstico",
                     Image = "https://i.imgur.com/bahey2J.png",
                     Url = "https://www.seagate.com/la/es/support/internal-hard-drives/desktop-hard-drives/barracuda-3-5/",
                     OnSale = false
                 },
                 new Product
                 {
                     ProductId = 14,
                     ProductName = "SSD Gigabyte 240GB",
                     CategoryId = 4,
                     UnitPrice = 4500,
                     UnitsInStock = 10,
                     Brand = "Seagate",
                     Description = "Modelo: ST1000DM010 Interfaz: SATA de 6 Gb/s Capacidad: 1 TB Buffer: 64 MB Velocidad: 7200 RPM. De uso doméstico",
                     Image = "https://i.imgur.com/VcSspi5.png",
                     Url = "https://www.gigabyte.com/ar/Solid-State-Drive/GIGABYTE-SSD-256GB#kf",
                     OnSale = false
                 });
            modelBuilder.Entity<Image>().HasData(
                new Image
                {
                    ImageId = 1,
                    Url = "https://i.imgur.com/7hIMXzD.png",
                    ProductId = 1,
                },//Imagen 1 Ryzen 7 5700G
                new Image
                {
                    ImageId = 2,
                    Url = "https://i.imgur.com/RYEET6W.png",
                    ProductId = 1,
                },//Imagen 2 Ryzen 7 5700G
                new Image
                {
                    ImageId = 3,
                    Url = "https://i.imgur.com/ZlfRxRX.png",
                    ProductId = 1,
                },//Imagen 3 Ryzen 7 5700G
                new Image
                {
                    ImageId = 4,
                    Url = "https://i.imgur.com/JHTHCvz.png",
                    ProductId = 1,
                },//Imagen 4 Ryzen 7 5700G
                new Image
                {
                    ImageId = 5,
                    Url = "https://i.imgur.com/pPCGtwD.png",
                    ProductId = 2,
                },//Imagen 1 Intel Core i5 10600KF
                new Image
                {
                    ImageId = 6,
                    Url = "https://i.imgur.com/PEWRhwg.png",
                    ProductId = 2,
                },//Imagen 2 Intel Core i5 10600KF
                new Image
                {
                    ImageId = 7,
                    Url = "https://i.imgur.com/PCh7GxO.png",
                    ProductId = 2,
                },//Imagen 3 Intel Core i5 10600KF
                new Image
                {
                    ImageId = 8,
                    Url = "https://i.imgur.com/Z2fJ6JD.png",
                    ProductId = 2,
                },//Imagen 4 Intel Core i5 10600KF
                new Image
                {
                    ImageId = 9,
                    Url = "https://i.imgur.com/UTodEaB.png",
                    ProductId = 3,
                },//Imagen 1 Intel Core i7 9700F
                new Image
                {
                    ImageId = 10,
                    Url = "https://i.imgur.com/RPnZ02l.png",
                    ProductId = 3,
                },//Imagen 2 Intel Core i7 9700F
                new Image
                {
                    ImageId = 11,
                    Url = "https://i.imgur.com/Rtpw8hA.png",
                    ProductId = 3,
                },//Imagen 3 Intel Core i7 9700F
                new Image
                {
                    ImageId = 12,
                    Url = "https://i.imgur.com/yWB9yD9.png",
                    ProductId = 3,
                },//Imagen 4 Intel Core i7 9700F
                new Image
                {
                    ImageId = 13,
                    Url = "https://i.imgur.com/Wy2kAhG.png",
                    ProductId = 4,
                },//Imagen 1 Ryzen 5 5600G
                new Image
                {
                    ImageId = 14,
                    Url = "https://i.imgur.com/niVhReS.png",
                    ProductId = 4,
                },//Imagen 2 Ryzen 5 5600G
                new Image
                {
                    ImageId = 15,
                    Url = "https://i.imgur.com/HHrAIAA.png",
                    ProductId = 4,
                },//Imagen 3 Ryzen 5 5600G
                new Image
                {
                    ImageId = 16,
                    Url = "https://i.imgur.com/tAeIvqD.png",
                    ProductId = 4,
                },//Imagen 4 Ryzen 5 5600G
                new Image
                {
                    ImageId = 17,
                    Url = "https://i.imgur.com/cDrubFC.png",
                    ProductId = 5,
                },//Imagen 1 Intel Core i3 10100
                new Image
                {
                    ImageId = 18,
                    Url = "https://i.imgur.com/2uBQPrT.png",
                    ProductId = 5,
                },//Imagen 2 Intel Core i3 10100
                new Image
                {
                    ImageId = 19,
                    Url = "https://i.imgur.com/yZVycHI.png",
                    ProductId = 5,
                },//Imagen 3 Intel Core i3 10100
                new Image
                {
                    ImageId = 20,
                    Url = "https://i.imgur.com/eRw8TDf.png",
                    ProductId = 5,
                },//Imagen 4 Intel Core i3 10100
                new Image
                {
                    ImageId = 21,
                    Url = "https://i.imgur.com/DBbZ0Mb.png",
                    ProductId = 6,
                },//Imagen 1 AMD a6 9500
                new Image
                {
                    ImageId = 22,
                    Url = "https://i.imgur.com/pzX4b0s.png",
                    ProductId = 6,
                },//Imagen 2 AMD a6 9500
                new Image
                {
                    ImageId = 23,
                    Url = "https://i.imgur.com/qz5UeSI.png",
                    ProductId = 6,
                },//Imagen 3 AMD a6 9500
                new Image
                {
                    ImageId = 24,
                    Url = "https://i.imgur.com/ZRHXXfj.png",
                    ProductId = 6,
                },//Imagen 4 AMD a6 9500
                new Image
                {
                    ImageId = 25,
                    Url = "https://i.imgur.com/QiD4m80.png",
                    ProductId = 7,
                }, //Imagen 1 AM4 Asrock B450M HDV 4.0
                new Image
                {
                    ImageId = 26,
                    Url = "https://i.imgur.com/tEVgQg6.png",
                    ProductId = 7,
                }, //Imagen 2 AM4 Asrock B450M HDV 4.0
                new Image
                {
                    ImageId = 27,
                    Url = "https://i.imgur.com/e3A5Y39.png",
                    ProductId = 7,
                }, //Imagen 3 AM4 Asrock B450M HDV 4.0
                new Image
                {
                    ImageId = 28,
                    Url = "https://i.imgur.com/bSv1zdZ.png",
                    ProductId = 7,
                }, //Imagen 4 AM4 Asrock B450M HDV 4.0
                new Image
                {
                    ImageId = 29,
                    Url = "https://i.imgur.com/lanfcBR.png",
                    ProductId = 8,
                }, //Imagen 1 AM4 - Gigabyte GA-B550 AORUS ELITE AX V2
                new Image
                {
                    ImageId = 30,
                    Url = "https://i.imgur.com/Gh8QFgB.png",
                    ProductId = 8,
                }, //Imagen 2 AM4 - Gigabyte GA-B550 AORUS ELITE AX V2
                new Image
                {
                    ImageId = 31,
                    Url = "https://i.imgur.com/4FFWiuf.png",
                    ProductId = 8,
                }, //Imagen 3 AM4 - Gigabyte GA-B550 AORUS ELITE AX V2
                new Image
                {
                    ImageId = 32,
                    Url = "https://i.imgur.com/ewuljgX.png",
                    ProductId = 8,
                }, //Imagen 4 AM4 - Gigabyte GA-B550 AORUS ELITE AX V2
                new Image
                {
                    ImageId = 33,
                    Url = "https://i.imgur.com/OsWivOs.png",
                    ProductId = 9,
                }, //Imagen 1 Motherboard AM4 - Asus Tuf X570-PLUS WIFI
                new Image
                {
                    ImageId = 34,
                    Url = "https://i.imgur.com/39y2gH3.png",
                    ProductId = 9,
                }, //Imagen 2 Motherboard AM4 - Asus Tuf X570-PLUS WIFI
                new Image
                {
                    ImageId = 35,
                    Url = "https://i.imgur.com/ovhu6lx.png",
                    ProductId = 9,
                }, //Imagen 3 Motherboard AM4 - Asus Tuf X570-PLUS WIFI
                new Image
                {
                    ImageId = 36,
                    Url = "https://i.imgur.com/uRVrFoJ.png",
                    ProductId = 9,
                },//Imagen 4 Motherboard AM4 - Asus Tuf X570-PLUS WIFI
                new Image
                {
                    ImageId = 37,
                    Url = "https://i.imgur.com/l3vgS6c.png",
                    ProductId = 10,
                }, //Imagen 1 AM4 - Msi A320M PRO VH
                new Image
                {
                    ImageId = 38,
                    Url = "https://i.imgur.com/2YGPcdD.png",
                    ProductId = 10,
                }, //Imagen 2 AM4 - Msi A320M PRO VH
                new Image
                {
                    ImageId = 39,
                    Url = "https://i.imgur.com/YZJDPPS.png",
                    ProductId = 10,
                }, //Imagen 3 AM4 - Msi A320M PRO VH
                new Image
                {
                    ImageId = 40,
                    Url = "https://i.imgur.com/ohrAcNY.png",
                    ProductId = 10,
                }, //Imagen 4 AM4 - Msi A320M PRO VH
                new Image
                {
                    ImageId = 41,
                    Url = "https://i.imgur.com/C0RjbtQ.png",
                    ProductId = 11,
                }, //Imagen 1 Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury
                new Image
                {
                    ImageId = 42,
                    Url = "https://i.imgur.com/X14tRUk.png",
                    ProductId = 11,
                }, //Imagen 2 Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury
                new Image
                {
                    ImageId = 43,
                    Url = "https://i.imgur.com/lPNNJkG.png",
                    ProductId = 11,
                }, //Imagen 3 Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury
                new Image
                {
                    ImageId = 44,
                    Url = "https://i.imgur.com/nw7jeAI.png",
                    ProductId = 11,
                }, //Imagen 4 Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury
                new Image
                {
                    ImageId = 45,
                    Url = "https://i.imgur.com/ItE432j.png",
                    ProductId = 12,
                },//Imagen 1 Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision
                new Image
                {
                    ImageId = 46,
                    Url = "https://i.imgur.com/zNf7Ek5.png",
                    ProductId = 12,
                },//Imagen 2 Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision
                new Image
                {
                    ImageId = 47,
                    Url = "https://i.imgur.com/WnDpaXG.png",
                    ProductId = 12,
                },//Imagen 3 Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision
                new Image
                {
                    ImageId = 48,
                    Url = "https://i.imgur.com/rcK6VEW.png",
                    ProductId = 12,
                },//Imagen 4 Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision
                new Image
                {
                    ImageId = 49,
                    Url = "https://i.imgur.com/RS4cwAD.png",
                    ProductId = 13,
                },//Imagen 1 Seagate Barracuda 1TB
                new Image
                {
                    ImageId = 50,
                    Url = "https://i.imgur.com/8qjZ41t.png",
                    ProductId = 13,
                },//Imagen 2 Seagate Barracuda 1TB
                new Image
                {
                    ImageId = 51,
                    Url = "https://i.imgur.com/kG7R1EJ.png",
                    ProductId = 13,
                },//Imagen 3 Seagate Barracuda 1TB
                new Image
                {
                    ImageId = 52,
                    Url = "https://i.imgur.com/rbUbbcd.png",
                    ProductId = 13,
                },//Imagen 4 Seagate Barracuda 1TB
                new Image
                {
                    ImageId = 53,
                    Url = "https://i.imgur.com/mcP0luK.png",
                    ProductId = 14,
                },// Imagen 1 SSD Gigabyte 240GB
                new Image
                {
                    ImageId = 54,
                    Url = "https://i.imgur.com/Tjc0xVB.png",
                    ProductId = 14,
                },// Imagen 2 SSD Gigabyte 240GB
                new Image
                {
                    ImageId = 55,
                    Url = "https://i.imgur.com/YsH84Bu.png",
                    ProductId = 14,
                },// Imagen 3 SSD Gigabyte 240GB
                new Image
                {
                    ImageId = 56,
                    Url = "https://i.imgur.com/Pd4jqhi.png",
                    ProductId = 14,
                });// Imagen 4 SSD Gigabyte 240GB
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Image> Image { get; set; }
    }
}