using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaIntercambioFinal.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoIncial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgendamentoProfissional",
                columns: table => new
                {
                    Id_AgendamentoProfissional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraAgendamento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoProfissional", x => x.Id_AgendamentoProfissional);
                });

            migrationBuilder.CreateTable(
                name: "CadastroDoCliente",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroDoCliente", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "CompanhiaAerea",
                columns: table => new
                {
                    CompanhiaAereaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanhiaAereaDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanhiaAerea", x => x.CompanhiaAereaId);
                });

            migrationBuilder.CreateTable(
                name: "DestinoIntercambio",
                columns: table => new
                {
                    DestinoIntercambioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoIntercambioDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinoIntercambio", x => x.DestinoIntercambioId);
                });

            migrationBuilder.CreateTable(
                name: "DuracaoIntercambio",
                columns: table => new
                {
                    DuracaoIntercambioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuracaoIntercambioDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuracaoIntercambio", x => x.DuracaoIntercambioId);
                });

            migrationBuilder.CreateTable(
                name: "TipoIntercambio",
                columns: table => new
                {
                    TipoIntercambioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoIntercambioDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIntercambio", x => x.TipoIntercambioId);
                });

            migrationBuilder.CreateTable(
                name: "AgendamentoViagem",
                columns: table => new
                {
                    AgendamentoViagemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAgendamentoViagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraAgendamentoViagem = table.Column<int>(type: "int", nullable: false),
                    CompanhiaAereaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendamentoViagem", x => x.AgendamentoViagemId);
                    table.ForeignKey(
                        name: "FK_AgendamentoViagem_CompanhiaAerea_CompanhiaAereaId",
                        column: x => x.CompanhiaAereaId,
                        principalTable: "CompanhiaAerea",
                        principalColumn: "CompanhiaAereaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CadastroIntercambio",
                columns: table => new
                {
                    Id_CadastoIntercambio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoIntercambioId = table.Column<int>(type: "int", nullable: false),
                    TipoIntercambioId = table.Column<int>(type: "int", nullable: false),
                    DuracaoIntercambioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroIntercambio", x => x.Id_CadastoIntercambio);
                    table.ForeignKey(
                        name: "FK_CadastroIntercambio_DestinoIntercambio_DestinoIntercambioId",
                        column: x => x.DestinoIntercambioId,
                        principalTable: "DestinoIntercambio",
                        principalColumn: "DestinoIntercambioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CadastroIntercambio_DuracaoIntercambio_DuracaoIntercambioId",
                        column: x => x.DuracaoIntercambioId,
                        principalTable: "DuracaoIntercambio",
                        principalColumn: "DuracaoIntercambioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CadastroIntercambio_TipoIntercambio_TipoIntercambioId",
                        column: x => x.TipoIntercambioId,
                        principalTable: "TipoIntercambio",
                        principalColumn: "TipoIntercambioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgendamentoViagem_CompanhiaAereaId",
                table: "AgendamentoViagem",
                column: "CompanhiaAereaId");

            migrationBuilder.CreateIndex(
                name: "IX_CadastroIntercambio_DestinoIntercambioId",
                table: "CadastroIntercambio",
                column: "DestinoIntercambioId");

            migrationBuilder.CreateIndex(
                name: "IX_CadastroIntercambio_DuracaoIntercambioId",
                table: "CadastroIntercambio",
                column: "DuracaoIntercambioId");

            migrationBuilder.CreateIndex(
                name: "IX_CadastroIntercambio_TipoIntercambioId",
                table: "CadastroIntercambio",
                column: "TipoIntercambioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgendamentoProfissional");

            migrationBuilder.DropTable(
                name: "AgendamentoViagem");

            migrationBuilder.DropTable(
                name: "CadastroDoCliente");

            migrationBuilder.DropTable(
                name: "CadastroIntercambio");

            migrationBuilder.DropTable(
                name: "CompanhiaAerea");

            migrationBuilder.DropTable(
                name: "DestinoIntercambio");

            migrationBuilder.DropTable(
                name: "DuracaoIntercambio");

            migrationBuilder.DropTable(
                name: "TipoIntercambio");
        }
    }
}
