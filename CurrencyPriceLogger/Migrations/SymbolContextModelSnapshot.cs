// <auto-generated />
using CurrencyPriceLogger.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyPriceLogger.Migrations
{
    [DbContext(typeof(SymbolContext))]
    partial class SymbolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("CurrencyPriceLogger.Models.SymbolBookData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("BestAskPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BestAskQuantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BestBidPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BestBidQuantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrderBookUpdateId")
                        .HasColumnType("decimal(20,0)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Symbols");
                });
#pragma warning restore 612, 618
        }
    }
}
