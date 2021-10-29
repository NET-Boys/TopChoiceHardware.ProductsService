using Microsoft.EntityFrameworkCore.Migrations;

namespace TopChoiceHardware.Products.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Productos__Descr__2C3393D0",
                        column: x => x.CategoryId,
                        principalTable: "Categorias",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Productos__Suppl__2D27B809",
                        column: x => x.SupplierId,
                        principalTable: "Proveedores",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 1, "Procesadores", "Unidad de procesamiento central del PC" },
                    { 2, "Motherboards", "Circuito impreso donde se conectan todos los componentes de una PC" },
                    { 3, "Memorias RAM", "Memoria de trabajo para un PC" },
                    { 4, "Almacenamiento", "Medios de almacenamiento de informacion para un pc" },
                    { 5, "Placas de video", "Tarjeta de expansion del motherboard para procesamiento de graficos" }
                });

            migrationBuilder.InsertData(
                table: "Proveedores",
                columns: new[] { "SupplierId", "AddressId", "CompanyName", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "New Bytes", "INFO@NB.COM.AR", "(11) 4011-8809" },
                    { 2, 1, "MEGACOM", "ventas@megacom.com.ar", "(0223) 492-4414" },
                    { 3, 1, "PcRetail", "info@pc-retail.com.ar", "11 49092100" }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductId", "Brand", "CategoryId", "Description", "Image", "ProductName", "SupplierId", "UnitPrice", "UnitsInStock", "Url" },
                values: new object[,]
                {
                    { 1, "AMD", 1, "Todos los procesadores AMD Ryzen serie 5000 cuentan con un conjunto completo de tecnologías diseñadas para elevar la potencia de procesamiento de tu PC, incluidas Precision Boost 25, Precision Boost Overdrive, PCIe 4.0 (en procesadores seleccionados) y Resizable BAR.", "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40369_1.jpeg?v252?v348?v928", "Amd Ryzen 7 5700G 4.6 Ghz - AM4", 1, 66000m, 10, "https://www.amd.com/es/products/apu/amd-ryzen-7-5700g" },
                    { 2, "INTEL", 1, "Los procesadores para desktop Intel Core de 10 Generación, que cuentan con hasta 5,3 GHz, tecnología Intel Thermal Velocity Boost (Intel TVB), 20 MB de caché inteligente Intel y conexión Intel Ethernet I225 ofrecen a los jugadores y a los profesionales creativos importantes ventajas de desempeño.", "https://mexx-img-2019.s3.amazonaws.com/39495_1.jpeg", "Intel Core i5 10600KF 4.8 Ghz Comet Lake 1200", 1, 30500m, 5, "https://ark.intel.com/content/www/es/es/ark/products/199315/intel-core-i5-10600kf-processor-12m-cache-up-to-4-80-ghz.html" },
                    { 3, "INTEL", 1, "Experimente un rendimiento increíble en videojuegos, edite y comparta con fluidez vídeo en 360 grados y disfrute de entretenimiento 4K Ultra HD fantástico, y todo con unas transferencias de datos a la velocidad de la luz que ofrece la tecnología Thunderbolt™ 3.", "https://mexx-img-2019.s3.amazonaws.com/36566_1.jpeg", "Intel Core i7 9700F 4.7 Ghz Coffee Lake 1151", 1, 40500m, 5, "https://ark.intel.com/content/www/es/es/ark/products/193738/intel-core-i7-9700f-processor-12m-cache-up-to-4-70-ghz.html" },
                    { 4, "AMD", 1, "Cuando cuentas con la arquitectura de procesadores más avanzada del mundo para jugadores y creadores de contenido, las posibilidades son infinitas.Ya sea que juegues los juegos más recientes, diseñes el próximo rascacielos o proceses datos, necesitas un procesador poderoso que pueda dar respuesta.", "https://mexx-img-2019.s3.amazonaws.com/procesador-cpu-ryzen_40368_1.jpeg", "Amd Ryzen 5 5600G 4.4 Ghz - AM4", 1, 55000m, 10, "https://www.amd.com/es/products/apu/amd-ryzen-5-5600g" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoryId",
                table: "Productos",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SupplierId",
                table: "Productos",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
