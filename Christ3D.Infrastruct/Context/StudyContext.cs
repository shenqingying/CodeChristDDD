using Christ3D.Domain.Models;
using Christ3D.Infrastruct.DB;
using Christ3D.Infrastruct.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Christ3D.Infrastruct.Context
{
    public class StudyContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// 重写自定义Map配置
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentMap());

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 重写连接数据库
        /// </summary>
        /// <param name="optionsBuilder"></param>
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();

        //    //定义要使用的数据库
        //    //正确的是这样，直接连接字符串即可
        //    //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //    //我是读取的文件内容，为了数据安全
        //    optionsBuilder.UseSqlServer(DbConfig.InitConn(config.GetConnectionString("DefaultConnection_file"), config.GetConnectionString("DefaultConnection")));
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               // .UseLoggerFactory(ConsoleLoggerFactory)
                .UseSqlServer(
                "server=.;uid=sa;pwd=shen;database=ChristDDD;MultipleActiveResultSets =true"
                );
        }

    }
}
