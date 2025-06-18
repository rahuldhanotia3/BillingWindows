using ProductCRMAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCRMAPI.DAL
{
    class DALIintegration : IDisposable
    {
        public void Dispose()  {    }
        public DataSet GetMasterPolicyList(ParametersEntity obj) //RKS
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[0] = new SqlParameter("@ProcAction", obj.ProcAction);
            Param[1] = new SqlParameter("@Policyno", obj.Policyno);
            Param[2] = new SqlParameter("@Policyinfoid", obj.Policyinfoid);
            Param[3] = new SqlParameter("enumIsMasterPolicy",obj.enumIsMasterPolicy);
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "usp_GetTotalMasterPolicyList", Param);
        }

        public DataSet APILog(ParametersEntity obj) //RKS
        {
            SqlParameter[] Param = new SqlParameter[5];
            Param[1] = new SqlParameter("@VchUrl", obj.VchUrl);
            Param[2] = new SqlParameter("@VchRequest", obj.VchRequest);
            Param[3] = new SqlParameter("@VchResponse", obj.VchResponse);
            return SqlHelper.ExecuteDataset(SqlHelper.ConnectionString, CommandType.StoredProcedure, "usp_ProductCRMApiLog", Param);
        }
    }
}
