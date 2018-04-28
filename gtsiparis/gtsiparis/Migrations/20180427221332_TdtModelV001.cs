using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gtsiparis.Migrations
{
    public partial class TdtModelV001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tdt.Grup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: true),
                    Il = table.Column<string>(nullable: true),
                    Ilce = table.Column<string>(nullable: true),
                    SemtBelde = table.Column<string>(nullable: true),
                    Mahalle = table.Column<string>(nullable: true),
                    PostaKodu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdt.Grup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tdt.Birim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: true),
                    GrupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdt.Birim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tdt.Birim_tdt.Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "tdt.Grup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tdt.Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    GrupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdt.Kategori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tdt.Kategori_tdt.Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "tdt.Grup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tdt.Siparis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciId = table.Column<string>(nullable: true),
                    GrupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdt.Siparis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tdt.Siparis_tdt.Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "tdt.Grup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tdt.Uretici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: true),
                    Il = table.Column<string>(nullable: true),
                    Ilce = table.Column<string>(nullable: true),
                    SemtBelde = table.Column<string>(nullable: true),
                    Mahalle = table.Column<string>(nullable: true),
                    PostaKodu = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    GrupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdt.Uretici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tdt.Uretici_tdt.Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "tdt.Grup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tdt.Urun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ad = table.Column<string>(nullable: true),
                    Aciklama = table.Column<string>(nullable: true),
                    Maliyet = table.Column<decimal>(nullable: false),
                    Fiyat = table.Column<decimal>(nullable: false),
                    Mesafe = table.Column<int>(nullable: true),
                    UretimBolge = table.Column<string>(nullable: true),
                    Baslangic = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Bitis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Aktif = table.Column<bool>(nullable: false),
                    BirimId = table.Column<int>(nullable: true),
                    KategoriId = table.Column<int>(nullable: true),
                    UreticiId = table.Column<int>(nullable: true),
                    GrupId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdt.Urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tdt.Urun_tdt.Birim_BirimId",
                        column: x => x.BirimId,
                        principalTable: "tdt.Birim",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tdt.Urun_tdt.Grup_GrupId",
                        column: x => x.GrupId,
                        principalTable: "tdt.Grup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tdt.Urun_tdt.Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "tdt.Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tdt.Urun_tdt.Uretici_UreticiId",
                        column: x => x.UreticiId,
                        principalTable: "tdt.Uretici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tdt.SiparisKalemi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Miktar = table.Column<decimal>(nullable: false),
                    Tutar = table.Column<decimal>(nullable: false),
                    BirimFiyat = table.Column<decimal>(nullable: false),
                    SiparisId = table.Column<int>(nullable: true),
                    UrunId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tdt.SiparisKalemi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tdt.SiparisKalemi_tdt.Siparis_SiparisId",
                        column: x => x.SiparisId,
                        principalTable: "tdt.Siparis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tdt.SiparisKalemi_tdt.Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "tdt.Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Birim_GrupId",
                table: "tdt.Birim",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Kategori_GrupId",
                table: "tdt.Kategori",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Siparis_GrupId",
                table: "tdt.Siparis",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.SiparisKalemi_SiparisId",
                table: "tdt.SiparisKalemi",
                column: "SiparisId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.SiparisKalemi_UrunId",
                table: "tdt.SiparisKalemi",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Uretici_GrupId",
                table: "tdt.Uretici",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Urun_BirimId",
                table: "tdt.Urun",
                column: "BirimId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Urun_GrupId",
                table: "tdt.Urun",
                column: "GrupId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Urun_KategoriId",
                table: "tdt.Urun",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_tdt.Urun_UreticiId",
                table: "tdt.Urun",
                column: "UreticiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tdt.SiparisKalemi");

            migrationBuilder.DropTable(
                name: "tdt.Siparis");

            migrationBuilder.DropTable(
                name: "tdt.Urun");

            migrationBuilder.DropTable(
                name: "tdt.Birim");

            migrationBuilder.DropTable(
                name: "tdt.Kategori");

            migrationBuilder.DropTable(
                name: "tdt.Uretici");

            migrationBuilder.DropTable(
                name: "tdt.Grup");
        }
    }
}
