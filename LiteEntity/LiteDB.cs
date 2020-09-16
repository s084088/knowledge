using LiteEntity.Tables;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LiteEntity
{
    public class LiteDB : DbContext
    {
        /// <summary>
        /// 取表中非删除的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Sets<T>() where T : DbBase => Set<T>().Where(l => l.DeleteFlag == 0);

        /// <summary>
        /// 数据库配置
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Data Source=Local.db");
        }

        /// <summary>
        /// 模型建立
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<KP>(entity =>
            {
                entity.HasMany(l => l.Extends).WithOne(l => l.Origin).HasForeignKey(l => l.OriginID);
                entity.HasMany(l => l.Preconditions).WithOne(l => l.Target).HasForeignKey(l => l.TargetID);
            });
            Seed(modelBuilder);
        }

        /// <summary>
        /// 映射对应表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelBuilder"></param>
        private void SetTable<T>(ModelBuilder modelBuilder) where T : DbBase, new()
        {
            modelBuilder.Entity<T>();
        }

        /// <summary>
        /// 初始化的数据
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void Seed(ModelBuilder modelBuilder)
        {
        }

        /// <summary>
        /// 生产环境初始化
        /// </summary>
        public void DbInit()
        {
            Database.EnsureCreated();
        }
    }
}