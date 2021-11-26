using Microsoft.EntityFrameworkCore.Migrations;

namespace TopChoiceHardware.Products.AccessData.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
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
                    table.PrimaryKey("PK_Supplier", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "money", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OnSale = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Productos__Descr__2C3393D0",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Productos__Suppl__2D27B809",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK__Products__Image",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
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
                table: "Supplier",
                columns: new[] { "SupplierId", "AddressId", "CompanyName", "Email", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "New Bytes", "INFO@NB.COM.AR", "(11) 4011-8809" },
                    { 2, 1, "MEGACOM", "ventas@megacom.com.ar", "(0223) 492-4414" },
                    { 3, 1, "PcRetail", "info@pc-retail.com.ar", "11 49092100" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "Brand", "CategoryId", "Description", "Image", "OnSale", "ProductName", "SupplierId", "UnitPrice", "UnitsInStock", "Url" },
                values: new object[,]
                {
                    { 1, "AMD", 1, "Todos los procesadores AMD Ryzen serie 5000 cuentan con un conjunto completo de tecnologías diseñadas para elevar la potencia de procesamiento de tu PC, incluidas Precision Boost 25, Precision Boost Overdrive, PCIe 4.0 (en procesadores seleccionados) y Resizable BAR.", "https://i.imgur.com/O1EfiHW.png", false, "Procesador Amd Ryzen 7 5700G 4.6 Ghz - AM4", 1, 65999m, 10, "https://www.amd.com/es/products/apu/amd-ryzen-7-5700g" },
                    { 2, "INTEL", 1, "Los procesadores para desktop Intel Core de 10 Generación, que cuentan con hasta 5,3 GHz, tecnología Intel Thermal Velocity Boost (Intel TVB), 20 MB de caché inteligente Intel y conexión Intel Ethernet I225 ofrecen a los jugadores y a los profesionales creativos importantes ventajas de desempeño.", "https://i.imgur.com/1cDE1v4.png?1", false, "Procesador  Intel Core i5 10600KF 4.8 Ghz Comet Lake 1200", 1, 30499m, 5, "https://ark.intel.com/content/www/es/es/ark/products/199315/intel-core-i5-10600kf-processor-12m-cache-up-to-4-80-ghz.html" },
                    { 3, "INTEL", 1, "Experimente un rendimiento increíble en videojuegos, edite y comparta con fluidez vídeo en 360 grados y disfrute de entretenimiento 4K Ultra HD fantástico, y todo con unas transferencias de datos a la velocidad de la luz que ofrece la tecnología Thunderbolt™ 3.", "https://i.imgur.com/EFy8fOT.png", false, "Procesador  Intel Core i7 9700F 4.7 Ghz Coffee Lake 1151", 1, 40499m, 5, "https://ark.intel.com/content/www/es/es/ark/products/193738/intel-core-i7-9700f-processor-12m-cache-up-to-4-70-ghz.html" },
                    { 4, "AMD", 1, "Cuando cuentas con la arquitectura de procesadores más avanzada del mundo para jugadores y creadores de contenido, las posibilidades son infinitas.Ya sea que juegues los juegos más recientes, diseñes el próximo rascacielos o proceses datos, necesitas un procesador poderoso que pueda dar respuesta.", "https://i.imgur.com/BI7uFjv.png", false, "Procesador  Amd Ryzen 5 5600G 4.4 Ghz - AM4", 1, 54999m, 10, "https://www.amd.com/es/products/apu/amd-ryzen-5-5600g" },
                    { 5, "INTEL", 1, "Procesador Intel® Core™ de 10ma Generación equipado con los gráficos Intel. Estos procesadores ofrecen un nuevo nivel de integración que permite potenciar las experiencias de uso de computadoras en la actualidad y en el futuro.", "https://i.imgur.com/HlWiLZf.png", false, "Procesador Intel Core i3 10100 4.3 Ghz Comet Lake 1200", 1, 27999m, 5, "https://www.intel.la/content/www/xl/es/products/sku/199283/intel-core-i310100-processor-6m-cache-up-to-4-30-ghz/specifications.html" },
                    { 6, "AMD", 1, "Sumergíte en la tecnología líder para gráficas con la arquitectura Graphics Core Next (GCN) de AMD. Esta tecnología de tercera generación activa las prestaciones avanzadas y el increíble rendimiento de las gráficas AMD Radeon", "https://i.imgur.com/GJk8cpx.png", false, "Procesador Amd Apu A6 A6-9500 3.5 Ghz - AM4", 1, 6499m, 10, "https://www.amd.com/es/products/apu/7th-gen-a6-9500-apu" },
                    { 7, "Asrock", 2, "Soporta Socket AMD AM4 Ryzen™ 2000, 3000, 4000 G-Series, 5000 y 5000 G-Series Desktop Processors 2 DIMMs, Soporta memoria DDR4 3200 + (OC)", "https://i.imgur.com/kgyIGNT.png", false, "Motherboard AM4 - Asrock B450M HDV 4.0", 1, 8999m, 10, "https://www.asrock.com/mb/AMD/B450M-HDV%20R4.0/index.la.asp#Specification" },
                    { 8, "AORUS", 2, "Supports AMD Ryzen™ 5000 Series / Ryzen™ 5000 G - Series / Ryzen™ 4000 G - Series and Ryzen™ 3000 Series Processors Dual Channel ECC / Non - ECC Unbuffered DDR4, 4 DIMMs", "https://i.imgur.com/yjl0knB.png", false, "Motherboard AM4 - Gigabyte GA-B550 AORUS ELITE AX V2", 1, 30999m, 10, "https://www.gigabyte.com/ar/Motherboard/B550-AORUS-ELITE-AX-V2-rev-10#kf" },
                    { 9, "Asus TUF", 2, "Socket AMD AM4: Listo para los procesadores AMD RyzenTM de 2da y 3ra generación. 4 x DIMM, Max. 128GB, DDR4 4400(O.C)/3466(O.C.)/3400(O.C.)/3200(O.C.)/3000(O.C.)/2933(O.C.)/2800(O.C.)/2666/2400/2133", "https://i.imgur.com/4nmN1jo.png", false, "Motherboard AM4 - Asus Tuf X570-PLUS WIFI", 1, 34999m, 10, "https://www.asus.com/latin/Motherboards-Components/Motherboards/TUF-Gaming/TUF-GAMING-X570-PLUS-WI-FI/" },
                    { 10, "MSI", 2, "AMD Socket AM4 , AMD® A320 Chipset, Supports DDR4 1866/ 2133/ 2400/ 2667/ 2800/ 2933/ 3000/ 3066/ 3200 MHz", "https://i.imgur.com/SoVh1gC.png", false, "Motherboard AM4 - Msi A320M PRO VH", 1, 7499m, 10, "https://www.msi.com/Motherboard/A320M-PRO-VH" },
                    { 11, "Kingston", 3, "Capacidad de 4 GB, velocidad de 3200 MHz, tecnología  DDR4.", "https://i.imgur.com/5Qx2cpJ.png", false, "Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury", 2, 4499m, 10, "" },
                    { 12, "Hikvision", 3, "Capacidad de 16 GB, velocidad de 2666 MHz, tecnología  DDR4.", "https://i.imgur.com/8xl51WL.png", false, "Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision", 2, 12500m, 10, "" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "ProductId", "Url" },
                values: new object[] { 1, 1, "https://i.imgur.com/O1EfiHW.png" });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "ProductId", "Url" },
                values: new object[] { 2, 1, "https://i.imgur.com/cRSZLrc.png" });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierId",
                table: "Product",
                column: "SupplierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
