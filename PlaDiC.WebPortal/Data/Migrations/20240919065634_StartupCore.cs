using System;
using FirebirdSql.EntityFrameworkCore.Firebird.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlaDiC.WebPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class StartupCore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Object",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Prefix = table.Column<string>(type: "varchar(10)", nullable: false),
                    Label = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Icono = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    UseName = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    NameLabel = table.Column<string>(type: "varchar(200)", nullable: true),
                    NameHint = table.Column<string>(type: "varchar(200)", nullable: true),
                    IsBlocked = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsVisible = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsDetail = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsRelated = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsAccessControlled = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    CustomSentence = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ListSentence = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    RelatedSentence = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    FieldsSentence = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    FilterSentence = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    MaxListRecords = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxRelatedRecords = table.Column<int>(type: "INTEGER", nullable: false),
                    AITriggerCode = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    BITriggerCode = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    AUTriggerCode = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    BUTriggerCode = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    ADTriggerCode = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    BDTriggerCode = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    RecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Folio = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    IsDisabled = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    InsertRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    Owner = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Object", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObjectProperty",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Label = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Hint = table.Column<string>(type: "varchar(200)", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    DefaultValue = table.Column<string>(type: "varchar(200)", nullable: true),
                    RegExp = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    MaxLng = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxVal = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    MinVal = table.Column<decimal>(type: "DECIMAL(18,2)", nullable: false),
                    IsRequired = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    RelatedSentence = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    FieldsSentece = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    Formula = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    Group = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    Secuence = table.Column<int>(type: "INTEGER", nullable: false),
                    Col = table.Column<int>(type: "INTEGER", nullable: false),
                    Row = table.Column<int>(type: "INTEGER", nullable: false),
                    Option = table.Column<int>(type: "INTEGER", nullable: false),
                    IsVisible = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsVisibleInList = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsVisibleInRelated = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsFilter = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsUnique = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    IsIndexed = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ObjectId = table.Column<string>(type: "varchar(50)", nullable: false),
                    RefObjectId = table.Column<string>(type: "varchar(50)", nullable: false),
                    RecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Folio = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    IsDisabled = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    InsertRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    Owner = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectProperty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectProperty_Object_Objec~",
                        column: x => x.ObjectId,
                        principalTable: "Object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ObjectProperty_Object_RefOb~",
                        column: x => x.RefObjectId,
                        principalTable: "Object",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PickList",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Label = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    IsGlobal = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    ObjectPropertyId = table.Column<string>(type: "varchar(50)", nullable: true),
                    RecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Folio = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    IsDisabled = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    InsertRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    Owner = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickList_ObjectProperty_Obj~",
                        column: x => x.ObjectPropertyId,
                        principalTable: "ObjectProperty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PickListValue",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", nullable: false),
                    PickListId = table.Column<string>(type: "varchar(50)", nullable: false),
                    Label = table.Column<string>(type: "varchar(200)", nullable: false),
                    Value = table.Column<string>(type: "varchar(50)", nullable: false),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true),
                    Color = table.Column<string>(type: "varchar(20)", nullable: true),
                    IsDefault = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    Secuence = table.Column<int>(type: "INTEGER", nullable: false),
                    RecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Folio = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    IsDisabled = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    InsertRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    UpdateRef = table.Column<string>(type: "varchar(50)", nullable: true),
                    Owner = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickListValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickListValue_PickList_Pick~",
                        column: x => x.PickListId,
                        principalTable: "PickList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectProperty_ObjectId",
                table: "ObjectProperty",
                column: "ObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectProperty_RefObjectId",
                table: "ObjectProperty",
                column: "RefObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PickList_ObjectPropertyId",
                table: "PickList",
                column: "ObjectPropertyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PickListValue_PickListId",
                table: "PickListValue",
                column: "PickListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PickListValue");

            migrationBuilder.DropTable(
                name: "PickList");

            migrationBuilder.DropTable(
                name: "ObjectProperty");

            migrationBuilder.DropTable(
                name: "Object");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    Name = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: true),
                    Tipo = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    Email = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    LockoutEnd = table.Column<string>(type: "VARCHAR(48)", nullable: true),
                    Name = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    NormalizedEmail = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    SecurityStamp = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "BOOLEAN", nullable: false),
                    UserName = table.Column<string>(type: "VARCHAR(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    RoleId = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRole~",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Fb:ValueGenerationStrategy", FbValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    UserId = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUser~",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    ProviderKey = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true),
                    UserId = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUser~",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    RoleId = table.Column<string>(type: "VARCHAR(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles~",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers~",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    LoginProvider = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(256)", nullable: false),
                    Value = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUser~",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }
    }
}
