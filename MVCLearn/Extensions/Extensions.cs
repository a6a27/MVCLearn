using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCLearn.Extensions
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// 透過Automapper轉為指定類型(屬性名稱需相同)
        /// </summary>
        /// <typeparam name="TSouce">Source Type</typeparam>
        /// <typeparam name="TDestination">Target Type</typeparam>
        /// <param name="source">source</param>
        /// <returns>Target</returns>
        public static TDestination MapperTo<TSouce, TDestination>(this TSouce source)
        {
            var config = new AutoMapper.MapperConfiguration(d => d.CreateMap<TSouce, TDestination>());
            var mapper = config.CreateMapper();

            return mapper.Map<TDestination>(source);
        }

        /// <summary>
        /// 透過Automapper轉為指定類型(屬性名稱需相同)
        /// </summary>
        /// <typeparam name="TSouce">Source Type</typeparam>
        /// <typeparam name="TDestination">Target Type</typeparam>
        /// <param name="source">source</param>
        /// <returns>Target</returns>
        public static IEnumerable<TDestination> MapperToList<TSouce, TDestination>(this IEnumerable<TSouce> source)
        {
            var config = new AutoMapper.MapperConfiguration(d => d.CreateMap<TSouce, TDestination>());
            var mapper = config.CreateMapper();

            return mapper.Map<IEnumerable<TDestination>>(source);
        }

        ///// <summary>
        ///// Mod by 奇緯 20211031 
        ///// </summary>
        ///// <typeparam name="TEntity"></typeparam>
        ///// <param name="set"></param>
        ///// <param name="entities"></param>
        //public static void AddOrUpdateList<TEntity>(this System.Data.Entity.IDbSet<TEntity> set, params TEntity[] entities) where TEntity : class
        //{
        //}
    }   
}