﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TopChoiceHardware.Products.AccessData;

namespace TopChoiceHardware.Products.AccessData.Migrations
{
    [DbContext(typeof(ProductosContext))]
    partial class ProductosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TopChoiceHardware.Products.Domain.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Procesadores",
                            Description = "Unidad de procesamiento central del PC"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Motherboards",
                            Description = "Circuito impreso donde se conectan todos los componentes de una PC"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Memorias RAM",
                            Description = "Memoria de trabajo para un PC"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Almacenamiento",
                            Description = "Medios de almacenamiento de informacion para un pc"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Placas de video",
                            Description = "Tarjeta de expansion del motherboard para procesamiento de graficos"
                        });
                });

            modelBuilder.Entity("TopChoiceHardware.Products.Domain.Entities.Producto", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("money");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Productos");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Brand = "AMD",
                            CategoryId = 1,
                            Description = "Todos los procesadores AMD Ryzen serie 5000 cuentan con un conjunto completo de tecnologías diseñadas para elevar la potencia de procesamiento de tu PC, incluidas Precision Boost 25, Precision Boost Overdrive, PCIe 4.0 (en procesadores seleccionados) y Resizable BAR.",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40369_1.jpeg?v252?v348?v928",
                            ProductName = "Amd Ryzen 7 5700G 4.6 Ghz - AM4",
                            SupplierId = 1,
                            UnitPrice = 66000m,
                            UnitsInStock = 10,
                            Url = "https://www.amd.com/es/products/apu/amd-ryzen-7-5700g"
                        },
                        new
                        {
                            ProductId = 2,
                            Brand = "INTEL",
                            CategoryId = 1,
                            Description = "Los procesadores para desktop Intel Core de 10 Generación, que cuentan con hasta 5,3 GHz, tecnología Intel Thermal Velocity Boost (Intel TVB), 20 MB de caché inteligente Intel y conexión Intel Ethernet I225 ofrecen a los jugadores y a los profesionales creativos importantes ventajas de desempeño.",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/39495_1.jpeg",
                            ProductName = "Intel Core i5 10600KF 4.8 Ghz Comet Lake 1200",
                            SupplierId = 1,
                            UnitPrice = 30500m,
                            UnitsInStock = 5,
                            Url = "https://ark.intel.com/content/www/es/es/ark/products/199315/intel-core-i5-10600kf-processor-12m-cache-up-to-4-80-ghz.html"
                        },
                        new
                        {
                            ProductId = 3,
                            Brand = "INTEL",
                            CategoryId = 1,
                            Description = "Experimente un rendimiento increíble en videojuegos, edite y comparta con fluidez vídeo en 360 grados y disfrute de entretenimiento 4K Ultra HD fantástico, y todo con unas transferencias de datos a la velocidad de la luz que ofrece la tecnología Thunderbolt™ 3.",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/36566_1.jpeg",
                            ProductName = "Intel Core i7 9700F 4.7 Ghz Coffee Lake 1151",
                            SupplierId = 1,
                            UnitPrice = 40500m,
                            UnitsInStock = 5,
                            Url = "https://ark.intel.com/content/www/es/es/ark/products/193738/intel-core-i7-9700f-processor-12m-cache-up-to-4-70-ghz.html"
                        },
                        new
                        {
                            ProductId = 4,
                            Brand = "AMD",
                            CategoryId = 1,
                            Description = "Cuando cuentas con la arquitectura de procesadores más avanzada del mundo para jugadores y creadores de contenido, las posibilidades son infinitas.Ya sea que juegues los juegos más recientes, diseñes el próximo rascacielos o proceses datos, necesitas un procesador poderoso que pueda dar respuesta.",
                            Image = "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40368_1.jpeg",
                            ProductName = "Amd Ryzen 5 5600G 4.4 Ghz - AM4",
                            SupplierId = 1,
                            UnitPrice = 55000m,
                            UnitsInStock = 10,
                            Url = "https://www.amd.com/es/products/apu/amd-ryzen-5-5600g"
                        });
                });

            modelBuilder.Entity("TopChoiceHardware.Products.Domain.Entities.Proveedor", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("SupplierId");

                    b.ToTable("Proveedores");

                    b.HasData(
                        new
                        {
                            SupplierId = 1,
                            AddressId = 1,
                            CompanyName = "New Bytes",
                            Email = "INFO@NB.COM.AR",
                            Phone = "(11) 4011-8809"
                        },
                        new
                        {
                            SupplierId = 2,
                            AddressId = 1,
                            CompanyName = "MEGACOM",
                            Email = "ventas@megacom.com.ar",
                            Phone = "(0223) 492-4414"
                        },
                        new
                        {
                            SupplierId = 3,
                            AddressId = 1,
                            CompanyName = "PcRetail",
                            Email = "info@pc-retail.com.ar",
                            Phone = "11 49092100"
                        });
                });

            modelBuilder.Entity("TopChoiceHardware.Products.Domain.Entities.Producto", b =>
                {
                    b.HasOne("TopChoiceHardware.Products.Domain.Entities.Categoria", "Category")
                        .WithMany("Productos")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Productos__Descr__2C3393D0")
                        .IsRequired();

                    b.HasOne("TopChoiceHardware.Products.Domain.Entities.Proveedor", "Supplier")
                        .WithMany("Productos")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("FK__Productos__Suppl__2D27B809")
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("TopChoiceHardware.Products.Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("TopChoiceHardware.Products.Domain.Entities.Proveedor", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
