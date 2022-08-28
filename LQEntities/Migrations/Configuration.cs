using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LatamQuants.Entities.Migrations
{
    partial class Configuration : ModelSnapshot
    {
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "6.0.8")
				.HasAnnotation("Relational:MaxIdentifierLength", 128);
#pragma warning restore 612, 618
		}
	}
}