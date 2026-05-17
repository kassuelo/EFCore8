using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curso.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes");

            migrationBuilder.AlterColumn<int>(
                name: "DiretorId",
                table: "Filmes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Diretores",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg" },
                    { 2, "Christopher Nolan" },
                    { 3, "Quentin Tarantino" },
                    { 4, "Martin Scorsese" },
                    { 5, "James Cameron" },
                    { 6, "Ridley Scott" },
                    { 7, "Peter Jackson" },
                    { 8, "Tim Burton" },
                    { 9, "Clint Eastwood" },
                    { 10, "David Fincher" }
                });

            migrationBuilder.InsertData(
                table: "Filmes",
                columns: new[] { "Id", "Ano", "DiretorId", "Titulo" },
                values: new object[,]
                {
                    { 1, 2010, 2, "Inception" },
                    { 2, 2014, 2, "Interstellar" },
                    { 3, 2017, 2, "Dunkirk" },
                    { 4, 1994, 3, "Pulp Fiction" },
                    { 5, 2003, 3, "Kill Bill Vol. 1" },
                    { 6, 2004, 3, "Kill Bill Vol. 2" },
                    { 7, 2013, 4, "The Wolf of Wall Street" },
                    { 8, 1976, 4, "Taxi Driver" },
                    { 9, 1990, 4, "Goodfellas" },
                    { 10, 2009, 5, "Avatar" },
                    { 11, 1997, 5, "Titanic" },
                    { 12, 1986, 5, "Aliens" },
                    { 13, 2000, 6, "Gladiator" },
                    { 14, 1979, 6, "Alien" },
                    { 15, 1982, 6, "Blade Runner" },
                    { 16, 2001, 7, "The Lord of the Rings: The Fellowship of the Ring" },
                    { 17, 2002, 7, "The Lord of the Rings: The Two Towers" },
                    { 18, 2003, 7, "The Lord of the Rings: The Return of the King" },
                    { 19, 1990, 8, "Edward Scissorhands" },
                    { 20, 1988, 8, "Beetlejuice" },
                    { 21, 1989, 8, "Batman" },
                    { 22, 2008, 9, "Gran Torino" },
                    { 23, 2004, 9, "Million Dollar Baby" },
                    { 24, 1992, 9, "Unforgiven" },
                    { 25, 1999, 10, "Fight Club" },
                    { 26, 1995, 10, "Se7en" },
                    { 27, 2014, 10, "Gone Girl" },
                    { 28, 1993, 1, "Jurassic Park" },
                    { 29, 1982, 1, "E.T." },
                    { 30, 1993, 1, "Schindler's List" },
                    { 31, 2002, 1, "Catch Me If You Can" },
                    { 32, 2004, 1, "The Terminal" },
                    { 33, 2005, 1, "War of the Worlds" },
                    { 34, 2015, 3, "The Hateful Eight" },
                    { 35, 2009, 3, "Inglourious Basterds" },
                    { 36, 2010, 4, "Shutter Island" },
                    { 37, 2006, 4, "The Departed" },
                    { 38, 2004, 4, "The Aviator" },
                    { 39, 2012, 6, "Prometheus" },
                    { 40, 2015, 6, "The Martian" },
                    { 41, 2012, 7, "The Hobbit: An Unexpected Journey" },
                    { 42, 2013, 7, "The Hobbit: The Desolation of Smaug" },
                    { 43, 2014, 7, "The Hobbit: The Battle of the Five Armies" },
                    { 44, 2003, 8, "Big Fish" },
                    { 45, 2005, 8, "Charlie and the Chocolate Factory" },
                    { 46, 2014, 9, "American Sniper" },
                    { 47, 2003, 9, "Mystic River" },
                    { 48, 2007, 10, "Zodiac" },
                    { 49, 2010, 10, "The Social Network" },
                    { 50, 2011, 10, "The Girl with the Dragon Tattoo" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes",
                column: "DiretorId",
                principalTable: "Diretores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes");

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Filmes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Diretores",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<int>(
                name: "DiretorId",
                table: "Filmes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Diretores_DiretorId",
                table: "Filmes",
                column: "DiretorId",
                principalTable: "Diretores",
                principalColumn: "Id");
        }
    }
}
