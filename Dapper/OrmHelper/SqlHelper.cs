using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.OrmHelper
{
    public class SqlHelper
    {
        public static string GetDpSql(string sqlFields, string afterFromSql, DataPage dp = null)
        {
            StringBuilder sbSql = new StringBuilder();

            if (afterFromSql.ToLower().Contains("select"))
            {
                afterFromSql = string.Format("({0}) as tempTb", afterFromSql);
            }

            if (dp == null)
            {
                sbSql.AppendFormat("SELECT {0} FROM  {1};", sqlFields, afterFromSql);
            }
            else
            {
                sbSql.AppendFormat(@"   declare @totalCount int;
                                        SELECT @totalCount=count(1) FROM {1};
                                
                                        if(@PageIndex*@PageSize>@totalCount) set @PageIndex=@totalCount/@PageSize+1;

                                        SELECT *  FROM( 
                                                        SELECT ROW_NUMBER() OVER( ORDER BY {2} ) as RowID,{0}
                                                            FROM {1}
                                                        ) temp
                                        WHERE RowID BETWEEN (@PageIndex - 1) * @PageSize+1 AND @PageIndex * @PageSize; 
                                        SELECT @totalCount;"
                    , sqlFields, afterFromSql, dp.OrderField);
            }
            return sbSql.ToString();
        }
    }
}
