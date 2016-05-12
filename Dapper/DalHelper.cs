using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Dapper.OrmHelper;

namespace Dapper
{
    /// <summary>
    /// Auth:陈明明
    /// date:2016年2月13日
    /// </summary>
    public class DalHelper
    {
        /// <summary>
        /// 构造函数 
        /// </summary>
        public DalHelper()
        {

        }

        public static DalHelper Instance = new DalHelper();

        //**************************************************************************************************************************************
        /// <summary>
        /// 执行增删改Sql语句,返回影响行数;查询数据则返回-1;
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <param name="parms">参数</param>
        /// <returns>数据库影响行数</returns>
        /// 注： 1. parms参数中必须覆盖SQl语句中的存在的参数;
        ///      2. 原则上参数名称映射不区分大小写,但应尽量保持一致
        public int ExcuteSql(string sql, object parms = null, IDbTransaction trans = null)
        {
            int excuteRes = 0;
            if (trans == null)
            {
                using (var con = Database.DbService())
                {
                    excuteRes = con.Execute(sql, parms);
                }
            }
            else
            {               
                excuteRes = trans.Connection.Execute(sql, parms, trans);
            }
            return excuteRes;
        }


        //**************************************************************************************************************************************
        /// <summary>
        /// 新增实体
        /// </summary>
        /// <typeparam name="T">泛行</typeparam>
        /// <param name="entity">实体对象</param>
        /// <returns>返回新增数据的主键</returns>
        /// 注:依赖PoCo对象,TableAttribute,KeyAttribute特性
        public int Insert<T>(T entity, IDbTransaction trans = null) where T : class
        {
            int excuteRes = 0;
            if (trans == null)
            {
                using (var con = Database.DbService())
                {
                    excuteRes = (int)con.Insert<T>(entity, trans);
                }
            }
            else
            {
                excuteRes = (int)trans.Connection.Insert<T>(entity, trans);
            }
            return excuteRes;
        }

        //**************************************************************************************************************************************

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">要更新的实体</param>
        /// <param name="trans">事务</param>
        /// <returns>true：更新成功;false:更新失败</returns>
        /// 注： 1. parms参数中必须覆盖SQl语句中的存在的参数;
        ///      2. 原则上参数名称映射不区分大小写,但应尽量保持一致
        public bool Edit<T>(T entity, IDbTransaction trans = null) where T : class
        {
            bool editRes = false;
            if (trans == null)
            {
                using (var con = Database.DbService())
                {
                    editRes = con.Update<T>(entity, trans);
                }
            }
            else
            {
              
                editRes = trans.Connection.Update<T>(entity, trans);
            }
            return editRes;
        }

        //**************************************************************************************************************************************
        /// <summary>
        /// 删除数据(只会根据主键值删除)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">要删除的对象(主键要有值)</param>
        /// <param name="trans">事务</param>
        /// <returns>删除是否成功</returns>
        public bool Delete<T>(T entity, IDbTransaction trans = null) where T : class
        {
            bool delRes = false;
            if (trans == null)
            {
                using (var con = Database.DbService())
                {
                    delRes = con.Delete<T>(entity, trans);
                }
            }
            else
            {
                delRes = trans.Connection.Delete<T>(entity, trans);
            }
            return delRes;
        }

        //**************************************************************************************************************************************
        /// <summary>
        /// 根据Sql查询单个实体,没有则返回默认对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selSql"></param>
        /// <param name="parms"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public T GetSqlDefaultEntity<T>(string selSql, object parms = null, IDbTransaction trans = null) where T : class, new()
        {
            T entity = new T();
            if (trans == null)
            {
                using (var con = Database.DbService())
                {
                    entity = con.Query<T>(selSql, parms).SingleOrDefault();
                }
            }
            else
            {
                entity = trans.Connection.Query<T>(selSql, parms, trans).SingleOrDefault();
            }
            return entity ?? new T();
        }

        //**************************************************************************************************************************************
        /// <summary>
        /// 跟据主键查询实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public T Get<T>(int key, IDbTransaction trans = null) where T : class, new()
        {
            T entity = new T();
            if (trans == null)
            {
                using (var con = Database.DbService())
                {
                    entity = con.Get<T>(key, trans);
                }
            }
            else
            {
                entity = trans.Connection.Get<T>(key, trans);
            }
            return entity ?? new T();
        }
        
        //**************************************************************************************************************************************
        /// <summary>
        /// 根据Sql查询单表实体列表数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selSql">Sql语句</param>
        /// <param name="parms">参数对象</param>
        /// <param name="trans">事务</param>
        /// <returns></returns>
        public List<T> GetList<T>(string selSql, object parms = null, IDbTransaction trans = null)
        {
            List<T> lstT = new List<T>();
            if (trans == null)
            {
                using (var con = Database.DbService())
                {
                    lstT = con.Query<T>(selSql, parms).ToList();
                }
            }
            else
            {
                lstT = trans.Connection.Query<T>(selSql, parms, trans).ToList();
            }
            return lstT ?? new List<T>();
        }

        //**************************************************************************************************************************************
        /// <summary>
        /// 分页查询页面
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dp"></param>
        /// <param name="selSql"></param>
        /// <param name="parms"></param>
        /// <param name="trans"></param>
        /// <returns></returns>
        public List<T> GetDpList<T>(string selFields, string afterFromSql, object parms, DataPage dp)
        {
            List<T> lstT = new List<T>();
            if (string.IsNullOrEmpty(selFields) || string.IsNullOrEmpty(afterFromSql)) return lstT;
            string tarSql = SqlHelper.GetDpSql(selFields, afterFromSql, dp);

            dp = dp ?? new DataPage();
            DynamicParameters tarParm = new DynamicParameters();
            tarParm.AddDynamicParams(parms);

            tarParm.AddDynamicParams(new
            {
                PageIndex = dp.PageIndex,
                PageSize = dp.PageSize,
            });
            var con = Database.DbService();
            using (con)
            {
                SqlMapper.GridReader gridReader = con.QueryMultiple(tarSql, tarParm);
                lstT = gridReader.Read<T>().ToList();
                dp.RowCount = gridReader.Read<int>().SingleOrDefault(); ;
            }
            return lstT ?? new List<T>();
        }
        //**************************************************************************************************************************************
        /// <summary>
        /// 重载
        /// </summary>
        public List<T> GetDpList<T>(List<string> lstString, string afterFromSql, object parms, DataPage dp)
        {
            return GetDpList<T>(string.Join(",", lstString), afterFromSql, parms, dp);
        }
        //**************************************************************************************************************************************
    }

    public class Database
    {
        /// 得到web.config里配置项的数据库连接字符串。  
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
        /// 得到工厂提供器类型  
        private static readonly string ProviderFactoryString = ConfigurationManager.AppSettings["DBProvider"].ToString();
        private static DbProviderFactory df = null;
        /// <summary>  
        /// 创建工厂提供器并且  
        /// </summary>  
        public static IDbConnection DbService()
        {
            if (df == null)
                df = DbProviderFactories.GetFactory(ProviderFactoryString);
            var connection = df.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();
            return connection;
        }
    }
}
