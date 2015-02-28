using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;
namespace tyxlj
{
    class SqlHelper
    {
        /// <summary>
        /// 连接数据库
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            string Server = ConfigurationManager.AppSettings["Server"];
            
            string conString = "Data Source="+Server+";Initial Catalog=JNAJYH;Persist Security Info=True;User ID=sa;Password=wewell_2014";//定义连接数据库字符集
            return new SqlConnection(conString);//返回连接数据库对象
        }
        /// <summary>
        /// 用数据填充的方法查询
        /// </summary>
        /// <param name="type"></param>
        /// <param name="sql"></param>
        /// <param name="pares"></param>
        /// <returns></returns>
        public DataSet GetDataSet(CommandType type, string sql, params SqlParameter[] pares)
        {
            SqlConnection con = GetConnection();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.SelectCommand.CommandType = type;
            if (pares != null)
            {
                foreach (SqlParameter pare in pares)
                {
                    da.SelectCommand.Parameters.Add(pare);
                }
            }
            da.Fill(ds);
            return ds;
        }

        public DataSet GetDataSet(string sql, params SqlParameter[] pares)
        {
            return GetDataSet(CommandType.Text, sql, pares);
        }

        public SqlDataReader GetSqlDataReader(CommandType type, string sql, out SqlConnection con, params SqlParameter[] pares)
        {
            con = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = type;
            con.Open();
            if (pares != null)
            {
                foreach (SqlParameter pare in pares)
                {
                    cmd.Parameters.Add(pare);
                }
            }
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader GetSqlDataReader(string sql, out SqlConnection con, params SqlParameter[] pares)
        {
            return GetSqlDataReader(CommandType.Text, sql, out con, pares);
        }

        public bool MidfyDB(CommandType type, string sql, params SqlParameter[] pares)
        {
            bool falg = false;
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = type;
            if (pares != null)
            {
                foreach (SqlParameter pare in pares)
                {
                    cmd.Parameters.Add(pare);
                }
            }
            SqlTransaction trans = null;
            try
            {
                con.Open();
                trans = con.BeginTransaction();
                cmd.Transaction = trans;
                cmd.ExecuteNonQuery();
                trans.Commit();
                falg = true;
            }
            catch (Exception e)
            {
                trans.Rollback();
                throw e;
            }
            finally
            {
                con.Close();
            }
            return falg;
        }
        /// <summary>
        /// 执行Sql语句返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <returns>受影响的行数,失败则返回-1</returns>
        public int ExecuteNonQuery(string sqlStr)
        {
            int line = -1;
            SqlConnection con = GetConnection();
            try
            {
                con.Open();
                line = this.ExecuteNonQuery(sqlStr, CommandType.Text, null);
                con.Close();
            }
            catch (SqlException e) { if (con.State == ConnectionState.Open) con.Close(); throw e; }
            return line;
        }

        /// <summary>
        /// 使用指定的Sql语句,CommandType,SqlParameter数组执行Sql语句,返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>
        /// <param name="type">命令类型</param>
        /// <param name="paras">SqlParameter数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string sqlStr, CommandType type, SqlParameter[] paras)
        {
            int line = -1;
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand(sqlStr, con);
            cmd.CommandType = type;
            if (cmd == null)
                GetCommand(sqlStr);
            cmd.Parameters.Clear();
            cmd.CommandText = sqlStr;
            cmd.CommandType = type;
            if (paras != null)
                cmd.Parameters.AddRange(paras);
            try
            {
                con.Open();
                line = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException e) { if (con.State == ConnectionState.Open) con.Close(); throw e; }
            return line;
        }
        /// <summary>
        /// 使用指定的Sql语句,CommandType,SqlParameter数组执行Sql语句,返回受影响的行数
        /// </summary>
        /// <param name="sqlStr">Sql语句</param>

        /// <param name="paras">SqlParameter数组</param>
        /// <returns>受影响的行数</returns>
        /// 
        public int ExecuteNonQuery(string sqlStr, SqlParameter[] paras)
        {
            return this.ExecuteNonQuery(sqlStr, CommandType.Text, paras);
        }
        public bool MidfyDB(string sql, params SqlParameter[] pares)
        {
            return MidfyDB(CommandType.Text, sql, pares);
        }

        /// <summary>  
        /// 执行查询语句，返回MySqlDataReader ( 注意：调用该方法后，一定要对MySqlDataReader进行Close )  
        /// </summary>  
        /// <param name="strSQL">查询语句</param>  
        /// <returns>MySqlDataReader</returns>  
        public static SqlDataReader ExecuteReader(string SQLString, out SqlConnection connection, params SqlParameter[] cmdParms)
        {
            connection = GetConnection();
            SqlCommand cmd = new SqlCommand(SQLString, connection);

            SqlDataReader myReader = null;
            try
            {
                connection.Open();
                PreparedCommand(cmd, cmdParms);
                myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (SqlException e)
            {
                if (connection.State == ConnectionState.Open) connection.Close();
                throw e;
            }
            finally
            {


            }
        }
        /// <summary>  
        /// 执行查询语句，返回DataSet  
        /// </summary>  
        /// <param name="SQLString">查询语句</param>  
        /// <returns>DataTable</returns>  
        public static DataTable ExecuteDataTable(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = GetConnection())
            {
                SqlCommand cmd = new SqlCommand(SQLString, connection);

                PreparedCommand(cmd, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                        connection.Close();
                    }
                    catch (SqlException ex)
                    {
                        if (connection.State == ConnectionState.Open) connection.Close();
                        throw new Exception(ex.Message);
                    }
                    return ds.Tables[0];
                }
            }
        }
        /// <summary>
        /// 查询聚合函数类
        /// </summary>
        /// <param name="type">数据库操作的类型 如:StoredProcedure(存储过程)、Text(文本)</param>
        /// <param name="sql">数据库操作字符集</param>
        /// <param name="paras">查询数据库时所用的参数</param>
        /// <returns>object(一般为单个值)</returns>
        public object GetScalar(CommandType type, string sql, params SqlParameter[] paras)
        {
            SqlConnection con = GetConnection();//创建数据集对象
            SqlCommand cmd = new SqlCommand(sql, con);//操作数据库对象
            cmd.CommandType = type;//数据库操作的类型
            //如果参数不为空
            if (paras != null)
            {
                //遍历参数数组
                foreach (SqlParameter para in paras)
                {
                    cmd.Parameters.Add(para);//给操作数据库对象加上参数
                }
            }
            con.Open();//打开数据库连接
            object obj = cmd.ExecuteScalar();//返回一个一行一列的植
            con.Close();//关闭数据库连接
            return obj;
        }

        public object GetScalar(string sql, params SqlParameter[] paras)
        {
            return GetScalar(CommandType.Text, sql, paras);
        }

        #region 数据填充DataTable

        public static DataTable DataFill(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            cmd.Connection = GetConnection();
            SqlDataAdapter _da = new SqlDataAdapter(cmd);
            _da.Fill(dt);
            return dt;
        }
        #endregion

        //public DataTable DateTel(string sql)
        //{
        //    SqlConnection con = GetConnection();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    return dt;
        //}

        /// <summary>
        /// 对获取的数据进行分页
        /// </summary>
        /// <param name="page">页数</param>
        /// <param name="rows">每页行数</param>
        /// <param name="dr">数据读写器</param>
        /// <returns>指定页的数据dt</returns>
        public DataTable DataTableForPage(int page, int rows, SqlDataReader dr, out int totalRecord)
        {
            DataSet ds = new DataSet();
            ds.Load(dr, LoadOption.OverwriteChanges, "");
            if (ds.Tables[0].Rows.Count > 0) //创建一个内存表，用来放置分页后的数据
            {
                int startindex = rows * (page - 1);
                int endindex = rows * page - 1;
                endindex = endindex < ds.Tables[0].Rows.Count ? endindex : ds.Tables[0].Rows.Count - 1;
                DataTable dt = new DataTable();
                for (int c = 0; c < ds.Tables[0].Columns.Count; c++)
                {
                    dt.Columns.Add(ds.Tables[0].Columns[c].ColumnName, ds.Tables[0].Columns[c].DataType);
                }
                for (int i = startindex; i <= endindex; i++)
                {
                    DataRow row = ds.Tables[0].NewRow();
                    row = ds.Tables[0].Rows[i];
                    dt.ImportRow(row);
                }

                totalRecord = ds.Tables[0].Rows.Count;
                return dt;
            }
            else
            {
                totalRecord = 0;
                return null;
            }
        }



        public static SqlCommand GetCommand(string text)
        {
            SqlCommand cmdObject = new SqlCommand();
            cmdObject.CommandText = text;
            return cmdObject;
        }

        public static void PreparedCommand(SqlCommand cmd, SqlParameter[] pars)
        {
            foreach (SqlParameter p in pars)
            {
                cmd.Parameters.Add(p);
            }
        }

      
    }
}
