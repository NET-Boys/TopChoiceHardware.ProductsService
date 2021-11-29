using Microsoft.EntityFrameworkCore.Migrations;

namespace TopChoiceHardware.Products.AccessData.Migrations
{
    public partial class Init : Migration
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
                table: "Product",
                columns: new[] { "ProductId", "Brand", "CategoryId", "Description", "Image", "OnSale", "ProductName", "SupplierId", "UnitPrice", "UnitsInStock", "Url" },
                values: new object[,]
                {
                    { 1, "AMD", 1, "Procesador AMD Ryzen 5ta generación equipado con gráficos integrados. Incluye 8 núcleos de CPU, una velocidad de reloj base de 3,8 GHz y 8 núcleos de GPU.", "https://i.imgur.com/O1EfiHW.png", false, "Procesador Amd Ryzen 7 5700G 4.6 Ghz - AM4", 0, 65999m, 10, "https://www.amd.com/es/products/apu/amd-ryzen-7-5700g" },
                    { 2, "INTEL", 1, "Procesador Intel® Core™ de 10ma Generación. Sin gráficos integrados, Incluye 6 núcleos 4.1GHz (hasta 4.8 Ghz), Socket 1200, Caché 12 MB", "https://i.imgur.com/1cDE1v4.png?1", false, "Procesador  Intel Core i5 10600KF 4.8 Ghz Comet Lake 1200", 0, 30499m, 5, "https://ark.intel.com/content/www/es/es/ark/products/199315/intel-core-i5-10600kf-processor-12m-cache-up-to-4-80-ghz.html" },
                    { 3, "INTEL", 1, "Procesador Intel Core i7-9700F de Novena Generación. Sin gráficos integrados, incluye 8 núcleos 3.0 GHz (hasta 4.7 GHz), Socket 1151, Caché 12 MB", "https://i.imgur.com/pPlPUe6.png", false, "Procesador  Intel Core i7 9700F 4.7 Ghz Coffee Lake 1151", 0, 40499m, 5, "https://ark.intel.com/content/www/es/es/ark/products/193738/intel-core-i7-9700f-processor-12m-cache-up-to-4-70-ghz.html" },
                    { 4, "AMD", 1, "Procesador AMD Ryzen 5ta generación equipado con gráficos integrados. Incluye seis núcleos de CPU, una velocidad de reloj base de 3,9 GHz y siete núcleos de GPU", "https://i.imgur.com/BI7uFjv.png", false, "Procesador  Amd Ryzen 5 5600G 4.4 Ghz - AM4", 0, 54999m, 10, "https://www.amd.com/es/products/apu/amd-ryzen-5-5600g" },
                    { 5, "INTEL", 1, "Procesador Intel® Core™ de 10ma Generación equipado con los gráficos Intel. Incluye 4 núcleos y 8 hilos de procesamiento, velocidad base de i3-10100 de 3.6 GHZ y turbo hasta 4.3 GHZ, Socket 1200, 6MB Caché.", "https://i.imgur.com/0RdBm8b.png", false, "Procesador Intel Core i3 10100 4.3 Ghz Comet Lake 1200", 0, 27999m, 5, "https://www.intel.la/content/www/xl/es/products/sku/199283/intel-core-i310100-processor-6m-cache-up-to-4-30-ghz/specifications.html" },
                    { 6, "AMD", 1, "Procesador AMD A series de 7ma generación equipado con gráficos integrados. Incluye 2 núcleos 3.5 Ghz, Socket AM4, Caché 1 MB", "https://i.imgur.com/etwcYDJ.png", false, "Procesador Amd Apu A6 A6-9500 3.5 Ghz - AM4", 0, 6499m, 10, "https://www.amd.com/es/products/apu/7th-gen-a6-9500-apu" },
                    { 7, "Asrock", 2, "Socket AMD AM4 Ryzen™ 2000, 3000, 4000 G-Series, 5000 y 5000 G-Series Desktop Processors 2 RAM DIMMs DDR4 3200 + (OC)", "", false, "Motherboard AM4 - Asrock B450M HDV 4.0", 0, 8999m, 10, "https://www.asrock.com/mb/AMD/B450M-HDV%20R4.0/index.la.asp#Specification" },
                    { 8, "AORUS", 2, "Socket AMD AM4 Ryzen™ 5000 Series / Ryzen™ 5000 G - Series / Ryzen™ 4000 G - Series and Ryzen™ 3000 Series Processors Dual Channel 4 DIMMs DDR4 ", "https://i.imgur.com/yjl0knB.png", false, "Motherboard AM4 - Gigabyte GA-B550 AORUS ELITE AX V2", 0, 30999m, 10, "https://www.gigabyte.com/ar/Motherboard/B550-AORUS-ELITE-AX-V2-rev-10#kf" },
                    { 9, "Asus TUF", 2, "Socket AMD AM4: Listo para los procesadores AMD RyzenTM de 2da y 3ra generación. 4 x DIMM DDR4, Max. 128GB ", "https://i.imgur.com/4nmN1jo.png", false, "Motherboard AM4 - Asus Tuf X570-PLUS WIFI", 0, 34999m, 10, "https://www.asus.com/latin/Motherboards-Components/Motherboards/TUF-Gaming/TUF-GAMING-X570-PLUS-WI-FI/" },
                    { 10, "MSI", 2, "Socket AMD AM4 , Soporta procesadores AMD® Ryzen™ 1ra y 2da Generación, 2 DIMMs DDR4", "https://i.imgur.com/SoVh1gC.png", false, "Motherboard AM4 - Msi A320M PRO VH", 0, 7499m, 10, "https://www.msi.com/Motherboard/A320M-PRO-VH" },
                    { 11, "Kingston", 3, "Capacidad de 4 GB, velocidad de 3200 MHz, tecnología  DDR4.", "https://i.imgur.com/5Qx2cpJ.png", false, "Memoria Ram DDR4 - 4Gb 3200 Mhz Beast Kingston Fury", 0, 4499m, 10, "" },
                    { 12, "Hikvision", 3, "Capacidad de 16 GB, velocidad de 2666 MHz, tecnología  DDR4.", null, false, "Memoria Ram DDR4 - 16Gb 2666 Mhz Value Hikvision", 0, 12500m, 10, "https://www.hikvision.com/es-la/" },
                    { 13, "Seagate", 4, "Modelo: ST1000DM010 Interfaz: SATA de 6 Gb/s Capacidad: 1 TB Buffer: 64 MB Velocidad: 7200 RPM. De uso doméstico", "", false, "Seagate Barracuda 1TB", 0, 5500m, 10, "https://www.seagate.com/la/es/support/internal-hard-drives/desktop-hard-drives/barracuda-3-5/" },
                    { 14, "Seagate", 4, "Modelo: ST1000DM010 Interfaz: SATA de 6 Gb/s Capacidad: 1 TB Buffer: 64 MB Velocidad: 7200 RPM. De uso doméstico", "", false, "SSD Gigabyte 240GB", 0, 4500m, 10, "https://www.gigabyte.com/ar/Solid-State-Drive/GIGABYTE-SSD-256GB#kf" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "ProductId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://i.imgur.com/7hIMXzD.png" },
                    { 22, 6, "https://i.imgur.com/pzX4b0s.png" },
                    { 21, 6, "https://i.imgur.com/DBbZ0Mb.png" },
                    { 20, 5, "https://i.imgur.com/eRw8TDf.png" },
                    { 19, 5, "https://i.imgur.com/yZVycHI.png" },
                    { 18, 5, "https://i.imgur.com/2uBQPrT.png" },
                    { 17, 5, "https://i.imgur.com/cDrubFC.png" },
                    { 16, 4, "https://i.imgur.com/tAeIvqD.png" },
                    { 15, 4, "https://i.imgur.com/HHrAIAA.png" },
                    { 14, 4, "https://i.imgur.com/niVhReS.png" },
                    { 13, 4, "https://i.imgur.com/Wy2kAhG.png" },
                    { 12, 3, "https://i.imgur.com/yWB9yD9.png" },
                    { 11, 3, "https://i.imgur.com/Rtpw8hA.png" },
                    { 10, 3, "https://i.imgur.com/RPnZ02l.png" },
                    { 9, 3, "https://i.imgur.com/UTodEaB.png" },
                    { 8, 2, "https://i.imgur.com/Z2fJ6JD.png" },
                    { 7, 2, "https://i.imgur.com/PCh7GxO.png" },
                    { 6, 2, "https://i.imgur.com/PEWRhwg.png" },
                    { 5, 2, "https://i.imgur.com/pPCGtwD.png" },
                    { 4, 1, "https://i.imgur.com/JHTHCvz.png" },
                    { 3, 1, "https://i.imgur.com/ZlfRxRX.png" },
                    { 2, 1, "https://i.imgur.com/RYEET6W.png" },
                    { 23, 6, "https://i.imgur.com/qz5UeSI.png" },
                    { 24, 6, "https://i.imgur.com/ZRHXXfj.png" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId",
                table: "Image",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
