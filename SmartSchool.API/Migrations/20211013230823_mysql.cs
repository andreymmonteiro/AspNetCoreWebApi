using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class mysql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    DataNasc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobrenome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sobrenome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false),
                    PreRequisitoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Disciplinas_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Nota = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNasc", "Matricula", "Nome", "Sobrenome", "telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(5735), new DateTime(2005, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" },
                    { 2, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(7412), new DateTime(2005, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" },
                    { 3, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(7427), new DateTime(2004, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" },
                    { 4, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(7432), new DateTime(2010, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" },
                    { 5, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(7436), new DateTime(2008, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" },
                    { 6, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(7444), new DateTime(2006, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" },
                    { 7, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(7449), new DateTime(2006, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Tecnologia da Informação" },
                    { 2, "Sistemas de Informação" },
                    { 3, "Ciências da Informação" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 259, DateTimeKind.Local).AddTicks(4705), 321, "Lauro", "Pereira", null },
                    { 2, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 259, DateTimeKind.Local).AddTicks(5838), 123, "Roberto", "Silva", null },
                    { 3, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 259, DateTimeKind.Local).AddTicks(5845), 654, "Ronaldo", "Garcia", null },
                    { 4, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 259, DateTimeKind.Local).AddTicks(5847), 789, "Rodrigo", "Barbosa", null },
                    { 5, true, null, new DateTime(2021, 10, 13, 20, 8, 23, 259, DateTimeKind.Local).AddTicks(5848), 951, "Alexandre", "Peretti", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, 1, "Matemática", null, 1 },
                    { 3, 0, 3, "Português", null, 3 },
                    { 4, 0, 1, "Inglês", null, 4 },
                    { 9, 0, 3, "Inglês", null, 4 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 2, 1, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9248), null },
                    { 5, 4, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9321), null },
                    { 4, 4, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9319), null },
                    { 1, 4, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9241), null },
                    { 7, 3, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9332), null },
                    { 6, 3, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9326), null },
                    { 3, 3, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9256), null },
                    { 6, 4, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9328), null },
                    { 7, 4, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9333), null },
                    { 7, 1, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9330), null },
                    { 6, 1, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9324), null },
                    { 4, 1, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9317), null },
                    { 3, 1, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9253), null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 5, 0, 2, "Programação", 1, 5 },
                    { 2, 0, 3, "Física", 1, 2 },
                    { 8, 0, 1, "Português", 3, 3 },
                    { 6, 0, 2, "Matemática", 1, 1 },
                    { 7, 0, 3, "Física", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 1, 2, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(8746), null },
                    { 2, 2, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9249), null },
                    { 3, 2, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9255), null },
                    { 6, 2, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9325), null },
                    { 7, 2, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9331), null },
                    { 1, 5, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9246), null },
                    { 2, 5, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9252), null },
                    { 4, 5, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9320), null },
                    { 5, 5, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9322), null },
                    { 7, 5, null, new DateTime(2021, 10, 13, 20, 8, 23, 272, DateTimeKind.Local).AddTicks(9334), null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 2, "Programação", 2, 5 });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
