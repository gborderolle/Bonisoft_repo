using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text;

namespace Bonisoft_2.Data_Generic
{
    public class DataAccessObject : DataAccessContext_MySQL
    {
        protected DataAccessObject()
            : base()
        {
        }

        #region DataTable Returns

        /// <summary>
        /// Returns a DataTable with rows from stored procedure.
        /// </summary>
        /// <param name="storedProcedureName">stored procedure name</param>
        /// <param name="param">hashtable list of parameter name, parameter value.</param>
        /// <example>ExecuteDataTable("my_sproc", new Hashtable().Add("@UserID, userID))</example>
        public static DataTable ExecuteDataTable(string storedProcedureName, Hashtable param)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.GetDataTable(storedProcedureName, param);
        }

        /// <summary>
        /// Returns a DataTable with rows from stored procedure.
        /// Use this function when the stored procedure requires only one parameter
        /// </summary>
        /// <param name="storedProcedureName">stored procedure name</param>
        /// <param name="param">the MySqlParameter required by the sproc</param>
        public static DataTable ExecuteDataTable(string storedProcedureName, MySqlParameter param)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.GetDataTable(storedProcedureName, param);
        }

        /// <summary>
        /// Returns a DataTable with rows from stored procedure.
        /// Use this function when you need to increase the default db timeout value.
        /// (DB timeout default value is 60sec)
        /// </summary>
        /// <param name="storedProcedureName">stored procedure name</param>
        /// <param name="param">hashtable list of parameter name, parameter value.</param>
        /// <param name="timeOutSeconds">db timeout value in seconds.</param>
        public static DataTable ExecuteDataTable(string storedProcedureName, Hashtable param, int timeOutSeconds)
        {
            DataAccessObject dao = new DataAccessObject();
            dao.TimeOutSeconds = timeOutSeconds;
            return dao.GetDataTable(storedProcedureName, param, timeOutSeconds);
        }

        /// <summary>
        /// Returns a DataTable with rows from query.
        /// </summary>
        /// <param name="query">the query</param>
        public static DataTable ExecuteDataTable(string query)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.GetDataTableQuery(query);
        }

        /// <summary>
        /// Returns a DataTable with rows from query.
        /// </summary>
        /// <param name="query">the query</param>
        /// <param name="param">parameters of the query</param>
        /// <param name="timeout">Timeout in miliseconds.</param>
        public static DataTable ExecuteDataTableQuery(string query, Hashtable param, int timeout = 0)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.GetDataTableQuery(query, param, timeout);
        }

        #endregion DataTable Returns

        #region ExecuteScalar

        /// <summary>
        /// Executes a stored procedure and returns the first column of the first row in resultset
        /// </summary>
        public static int ExecuteScalar(string storedProcedureName, Hashtable param, int timeout = 0)
        {
            DataAccessObject dao = new DataAccessObject();
            if (timeout > 0)
            {
                dao.TimeOutSeconds = timeout;
            }
            return dao.ExecuteNonQueryFromSproc(storedProcedureName, param, string.Empty, true);
        }

        public static object ExecuteScalar(bool IsStoredProcedure, string query, Hashtable param, int timeout = 0)
        {
            DataAccessObject dao = new DataAccessObject();
            if (timeout > 0)
            {
                dao.TimeOutSeconds = timeout;
            }
            return dao.ExecuteScalarQuery(IsStoredProcedure, query, param);
        }

        #endregion ExecuteScalar

        #region Execute Non Query (for inserts/updates)

        /// <summary>
        /// Executes a stored procedure and returns the first column of the first row in result set when idParam is provided.
        /// </summary>
        /// <param name="storedProcedureName">the name of the stored procedure to be executed</param>
        /// <param name="idParam">name of the ID field for sprocs that return an incremental ID as integer</param>
        /// <param name="param">a Hashtable list of parameters and values required by the stored procedure.</param>
        public static int ExecuteNonQuery(string storedProcedureName, Hashtable param, string idParam)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.ExecuteNonQueryFromSproc(storedProcedureName, param, idParam, false);
        }

        /// <summary>
        /// Returns a int with affected rows from the query.
        /// </summary>
        /// <param name="query">The Select query</param>
        public static int ExecuteNonQuery(string query)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.ExecuteNonQueryFromQuery(query);
        }

        /// <summary>
        /// Returns a int with affected rows from the query.
        /// </summary>
        /// <param name="query">The Select query</param>
        /// <param name="param">Hashtable with parameters</param>
        public static int ExecuteNonQuery(string query, Hashtable param)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.ExecuteNonQueryFromQuery(query, param);
        }

        #endregion Execute Non Query (for inserts/updates)

        #region MySqlDataReader returns

        /// <summary>
        /// Execute a proc and return the results as a data reader.
        /// The reader and connection must be closed by the calling function!
        /// </summary>
        /// <remarks>
        /// For speed optimisations.
        /// </remarks>
        /// <example>
        /// using(SqlDataReader results = Data.DataAccessObject.ExecuteDataReader("mysproc", param)){
        ///     while(result.Read()) {
        ///         this._outcompanyID = results["out_company"];
        ///     }
        /// }
        /// result.close();
        /// </example>
        public static MySqlDataReader ExecuteDataReader(string storedProcedureName, Hashtable param, int timeout = 0)
        {
            DataAccessObject dao = new DataAccessObject();
            dao.TimeOutSeconds = timeout;
            MySqlDataReader reader = dao.ExecuteReader(storedProcedureName, param);
            return reader;
        }

        public static MySqlDataReader ExecuteDataReaderQuery(string query, Hashtable param, int timeout = 0)
        {
            DataAccessObject dao = new DataAccessObject();
            dao.TimeOutSeconds = timeout;
            MySqlDataReader reader = dao.ExecuteReaderQuery(query, param);
            return reader;
        }

        #endregion MySqlDataReader returns

        #region DataSet returns

        /// <summary>
        /// Execute a Stored Procedure and returns the result as a DataSet
        /// </summary>
        protected DataSet ExecuteDataSet(string storedProcedureName
                                    , Hashtable param, int timeout = 0)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.GetDataSet(storedProcedureName, param, timeout);
        }

        /// <summary>
        /// Execute a Query and returns the result as a DataSet
        /// </summary>
        public static DataSet ExecuteDataSet(string query)
        {
            DataAccessObject dao = new DataAccessObject();
            return dao.GetDataSet(query);
        }

        #endregion DataSet returns

    }
}