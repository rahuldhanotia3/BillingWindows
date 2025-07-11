using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProductCRMAPI.Entities;
using ProductCRMAPI.DAL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Newtonsoft.Json;
using System.IO;
using System.Configuration;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ProductCRMAPI
{
    public partial class Form1 : Form
    {
        DALIintegration OblDALIintegration = new DALIintegration();
        ParametersEntity objParametersEntity = new ParametersEntity();
        RequestJSON objrequestJSON = new RequestJSON();
        string ReqJason = "";
        public static string AuthTokenAPIUrl { get { return ConfigurationManager.AppSettings["AuthUrl"].ToString(); } }
        public static string AuthTokenAPIUserName { get { return ConfigurationManager.AppSettings["UserId"].ToString(); } }
        public static string AuthTokenAPIPsw { get { return ConfigurationManager.AppSettings["Password"].ToString(); } }
        public static string DataPostUrl { get { return ConfigurationManager.AppSettings["DataPostUrl"].ToString(); } }
        public Form1()
        {
            InitializeComponent();
            GetPolicyList();
            Application.Exit();
        }

        void GetPolicyList()
        {
            try
            {
                DataSet ds = new DataSet();
                objParametersEntity.ProcAction = "GetPolicyList";
                ds = OblDALIintegration.GetMasterPolicyList(objParametersEntity);
                if (ds.Tables[0] != null)
                {
                    for (int t = 0; t < ds.Tables[0].Rows.Count; t++)
                    {
                        string Policyno = ds.Tables[0].Rows[t]["vchPolicyNumber"].ToString();
                        string Policyinfoid = ds.Tables[0].Rows[t]["IntPolicyinfoid"].ToString();
                        string enumIsMasterPolicy = ds.Tables[0].Rows[t]["enumIsMasterPolicy"].ToString();
                        string AuthReqJason = "{\r\n    \"UserId\" : \"" + AuthTokenAPIUserName + "\",\r\n    \"Password\" : \"" + AuthTokenAPIPsw + "\"\r\n}";
                        string sTrResponse = string.Empty;
                        // ApiPaymentLog(AuthTokenAPIUrl, AuthReqJason,"");
                        sTrResponse = APIPostMethod(AuthReqJason, AuthTokenAPIUrl);
                        ApiPaymentLog(AuthTokenAPIUrl, AuthReqJason, sTrResponse, Policyno);
                        if (sTrResponse != null)
                        {
                            AuthApiResp myDeserializedClass = JsonConvert.DeserializeObject<AuthApiResp>(sTrResponse);
                            if (myDeserializedClass.status == "success")
                            {
                                string TokenNumber = myDeserializedClass.Data.TokenNumber;
                                GetDataByPolicyInfoID(Policyno, Policyinfoid, enumIsMasterPolicy, TokenNumber);
                            }
                        }


                    }

                }

            }
            catch (Exception Ex)
            {

                //throw Ex;
            }


        }

        void GetDataByPolicyInfoID(string Policyno, string Policyinfoid, string enumIsMasterPolicy, string Vchtoken)
        {
            string vchTokenNumber = Vchtoken;
            DataSet ds = new DataSet();
            objParametersEntity.ProcAction = "GetPolicyDataByID";
            objParametersEntity.Policyno = Policyno;
            objParametersEntity.Policyinfoid = Policyinfoid;
            objParametersEntity.enumIsMasterPolicy = enumIsMasterPolicy;
            ds = OblDALIintegration.GetMasterPolicyList(objParametersEntity);
            if (ds.Tables[0] != null)
            {
                for (int t = 0; t < ds.Tables[0].Rows.Count; t++)
                {

                    #region vchTokenNumber
                    objrequestJSON.vchTokenNumber = vchTokenNumber;
                    #endregion
                    #region LineOfBusinessDetail
                    List<LineOfBusinessDetail> listLineOfBusinessDetail = new List<LineOfBusinessDetail>();
                    LineOfBusinessDetail objLineOfBusinessDetail = new LineOfBusinessDetail();
                    objLineOfBusinessDetail.vchLobCode = ds.Tables[0].Rows[t]["vchLobCode"].ToString();
                    objLineOfBusinessDetail.vchLob = ds.Tables[0].Rows[t]["vchLob"].ToString();
                    objLineOfBusinessDetail.Status = ds.Tables[0].Rows[t]["Status"].ToString();
                    objLineOfBusinessDetail.Remarks = ds.Tables[0].Rows[t]["Remarks"].ToString();
                    listLineOfBusinessDetail.Add(objLineOfBusinessDetail);
                    objrequestJSON.LineOfBusinessDetails = listLineOfBusinessDetail;
                    #endregion LineOfBusinessDetail
                }


            }
            if (ds.Tables[1] != null)
            {
                for (int t = 0; t < ds.Tables[1].Rows.Count; t++)
                {
                    #region ProductDetail
                    List<ProductDetail> listproductDetails = new List<ProductDetail>();

                    ProductDetail objProductDetail = new ProductDetail();
                    objProductDetail.vchPolicyType = ds.Tables[1].Rows[t]["vchPolicyType"].ToString();
                    objProductDetail.vchProductName = ds.Tables[1].Rows[t]["vchProductName"].ToString();
                    objProductDetail.vchProductCode = ds.Tables[1].Rows[t]["vchProductCode"].ToString();
                    objProductDetail.vchProductSchema = ds.Tables[1].Rows[t]["vchProductSchema"].ToString();
                    objProductDetail.vchIRDACode = ds.Tables[1].Rows[t]["vchIRDACode"].ToString();
                    objProductDetail.mnyMinLimit = ds.Tables[1].Rows[t]["mnyMinLimit"].ToString();
                    objProductDetail.mnyMaxLimit = ds.Tables[1].Rows[t]["mnyMaxLimit"].ToString();
                    objProductDetail.Status = ds.Tables[1].Rows[t]["Status"].ToString();
                    objProductDetail.Remarks = ds.Tables[1].Rows[t]["Remarks"].ToString();
                    listproductDetails.Add(objProductDetail);
                    objrequestJSON.ProductDetails = listproductDetails;
                    #endregion ProductDetail
                }

            }
            if (ds.Tables[2] != null)
            {
                List<CoverDetail> listCoverDetail = new List<CoverDetail>();
                for (int t = 0; t < ds.Tables[2].Rows.Count; t++)
                {
                    #region CoverDetails
                    CoverDetail objCoverDetail = new CoverDetail();
                    objCoverDetail.vchCoverType = ds.Tables[2].Rows[t]["vchCoverType"].ToString();
                    objCoverDetail.vchSection = ds.Tables[2].Rows[t]["vchSection"].ToString();
                    objCoverDetail.vchSectionCode = ds.Tables[2].Rows[t]["vchSectionCode"].ToString();
                    objCoverDetail.vchCoverPerilCode = ds.Tables[2].Rows[t]["vchCoverPerilCode"].ToString();
                    objCoverDetail.vchCoverDesc = ds.Tables[2].Rows[t]["vchCoverDesc"].ToString();
                    objCoverDetail.vchCoverCode = ds.Tables[2].Rows[t]["vchCoverCode"].ToString();
                    objCoverDetail.vchLimitType = ds.Tables[2].Rows[t]["vchLimitType"].ToString();
                    objCoverDetail.mnyMinLimit = ds.Tables[2].Rows[t]["mnyMinLimit"].ToString();
                    objCoverDetail.mnyMaxLimit = ds.Tables[2].Rows[t]["mnyMaxLimit"].ToString();
                    objCoverDetail.Status = ds.Tables[2].Rows[t]["Status"].ToString();
                    objCoverDetail.Remarks = ds.Tables[2].Rows[t]["Remarks"].ToString();
                    List<CoverPartDetail> objListCoverPartDetails = new List<CoverPartDetail>();
                    #endregion CoverDetails
                    if (ds.Tables[3] != null)
                    {
                        if (ds.Tables[2].Columns.Contains("vchCoverCode") && (ds.Tables[3].AsEnumerable().Where(r => r.Field<string>("vchCoverCode") == ds.Tables[2].Rows[t]["vchCoverCode"].ToString()).Count() > 0))
                        {
                            DataTable SubCover = ds.Tables[3].AsEnumerable().Where(r => r.Field<string>("vchCoverCode") == ds.Tables[2].Rows[t]["vchCoverCode"].ToString()).CopyToDataTable();

                            for (int t3 = 0; t3 < SubCover.Rows.Count; t3++)
                            {
                                CoverPartDetail objCoverPartDetail = new CoverPartDetail();
                                objCoverPartDetail.vchCoverPartDesc = SubCover.Rows[t3]["vchCoverPartDesc"].ToString();
                                objCoverPartDetail.Status = SubCover.Rows[t3]["Status"].ToString();
                                objCoverPartDetail.vchCoverCode = SubCover.Rows[t3]["vchCoverCode"].ToString();
                                objListCoverPartDetails.Add(objCoverPartDetail);
                            }


                        }
                    }
                    objCoverDetail.CoverPartDetails = objListCoverPartDetails;
                    listCoverDetail.Add(objCoverDetail);
                    objrequestJSON.CoverDetails = listCoverDetail;
                }
            }


            if (ds.Tables[4] != null)
            {
                for (int t = 0; t < ds.Tables[4].Rows.Count; t++)
                {
                    #region ProductDetail
                    List<GroupPolicyTagging> listGroupPolicyTagging = new List<GroupPolicyTagging>();
                    GroupPolicyTagging objGroupPolicyTagging = new GroupPolicyTagging();
                    objGroupPolicyTagging.vchPolicyNumber = ds.Tables[4].Rows[t]["vchPolicyNumber"].ToString();
                    objGroupPolicyTagging.Status = ds.Tables[4].Rows[t]["Status"].ToString();
                    objGroupPolicyTagging.Remarks = ds.Tables[4].Rows[t]["Remarks"].ToString();
                    objGroupPolicyTagging.vchProductCode = ds.Tables[4].Rows[t]["vchProductCode"].ToString();
                    listGroupPolicyTagging.Add(objGroupPolicyTagging);
                    objrequestJSON.GroupPolicyTagging = listGroupPolicyTagging;
                    #endregion ProductDetail
                }

            }
            if (ds.Tables[5] != null)
            {
                List<PolicyCoverTagging> listPolicyCoverTagging = new List<PolicyCoverTagging>();
                List<CoverTagging> listCoverTagging = new List<CoverTagging>();

                for (int t = 0; t < ds.Tables[5].Rows.Count; t++)
                {
                    PolicyCoverTagging objPolicyCoverTagging = new PolicyCoverTagging();
                    objPolicyCoverTagging.mnySumInsured = ds.Tables[5].Rows[t]["mnySumInsured"].ToString();
                    objPolicyCoverTagging.vchGroupId = ds.Tables[5].Rows[t]["vchGroupId"].ToString();

                    if (ds.Tables[6] != null)
                    {
                        if (ds.Tables[5].Columns.Contains("intPolicyGroupDefId") && (ds.Tables[6].AsEnumerable().Where(r => r.Field<Int64>("intPolicyGroupDefId") == Convert.ToInt64(ds.Tables[5].Rows[t]["intPolicyGroupDefId"])).Count() > 0))
                        {
                            DataTable PolicyCover = ds.Tables[6].AsEnumerable().Where(r => r.Field<Int64>("intPolicyGroupDefId") == Convert.ToInt64(ds.Tables[5].Rows[t]["intPolicyGroupDefId"])).CopyToDataTable();

                            for (int t1 = 0; t1 < PolicyCover.Rows.Count; t1++)
                            {
                                CoverTagging objCoverTagging = new CoverTagging();
                                objCoverTagging.mnySumInsured = PolicyCover.Rows[t1]["mnySumInsured"].ToString();
                                objCoverTagging.vchGroupId = PolicyCover.Rows[t1]["vchGroupId"].ToString();
                                objCoverTagging.vchCoverCode = PolicyCover.Rows[t1]["vchCoverCode"].ToString();
                                objCoverTagging.vchLimitType = PolicyCover.Rows[t1]["vchLimitType"].ToString();
                                objCoverTagging.intUnit = PolicyCover.Rows[t1]["intUnit"].ToString();
                                objCoverTagging.mnyLimit = PolicyCover.Rows[t1]["mnyLimit"].ToString();
                                objCoverTagging.mnyMaxLimit = PolicyCover.Rows[t1]["mnyMaxLimit"].ToString();
                                objCoverTagging.intPreDays = PolicyCover.Rows[t1]["intPreDays"].ToString();
                                objCoverTagging.intPostDays = PolicyCover.Rows[t1]["intPostDays"].ToString();
                                objCoverTagging.fltDefaultValue = PolicyCover.Rows[t1]["fltDefaultValue"].ToString();
                                objCoverTagging.vchRemarks = PolicyCover.Rows[t1]["vchRemarks"].ToString();
                                objCoverTagging.Status = PolicyCover.Rows[t1]["Status"].ToString();
                                objCoverTagging.vchCoverType = PolicyCover.Rows[t1]["vchCoverType"].ToString(); 
                                objCoverTagging.vchProductCode= PolicyCover.Rows[t1]["vchProductCode"].ToString();
                                List<SubCoverTagging> ListsubCoverTaggings = new List<SubCoverTagging>();

                                if (ds.Tables[7] != null)
                                {
                                    if (ds.Tables[6].Columns.Contains("vchCoverCode") && (ds.Tables[7].AsEnumerable().Where(r => r.Field<string>("vchCoverCode") == ds.Tables[6].Rows[t1]["vchCoverCode"].ToString()).Count() > 0))
                                    {
                                        DataTable PolicySubCover = ds.Tables[7].AsEnumerable().Where(r => r.Field<string>("vchCoverCode") == ds.Tables[6].Rows[t1]["vchCoverCode"].ToString()).CopyToDataTable();

                                        for (int t2 = 0; t2 < PolicySubCover.Rows.Count; t2++)
                                        {
                                            SubCoverTagging objsubCoverTagging = new SubCoverTagging();
                                            objsubCoverTagging.mnySumInsured = PolicySubCover.Rows[t2]["mnySumInsured"].ToString();
                                            objsubCoverTagging.vchGroupId = PolicySubCover.Rows[t2]["vchGroupId"].ToString();
                                            objsubCoverTagging.vchCoverType = PolicySubCover.Rows[t2]["vchCoverType"].ToString();
                                            objsubCoverTagging.vchCoverPartCode = PolicySubCover.Rows[t2]["vchCoverPartCode"].ToString();
                                            objsubCoverTagging.vchLimitType = PolicySubCover.Rows[t2]["vchLimitType"].ToString();
                                            objsubCoverTagging.intUnit = PolicySubCover.Rows[t2]["intUnit"].ToString();
                                            objsubCoverTagging.mnyLimit = PolicySubCover.Rows[t2]["mnyLimit"].ToString();
                                            objsubCoverTagging.mnyMaxLimit = PolicySubCover.Rows[t2]["mnyMaxLimit"].ToString();
                                            objsubCoverTagging.intPreDays = PolicySubCover.Rows[t2]["intPreDays"].ToString();
                                            objsubCoverTagging.intPostDays = PolicySubCover.Rows[t2]["intPostDays"].ToString();
                                            objsubCoverTagging.fltDefaultValue = PolicySubCover.Rows[t2]["fltDefaultValue"].ToString();
                                            objsubCoverTagging.vchRemarks = PolicySubCover.Rows[t2]["vchRemarks"].ToString();
                                            objsubCoverTagging.Status = PolicySubCover.Rows[t2]["Status"].ToString();
                                            ListsubCoverTaggings.Add(objsubCoverTagging);

                                        }
                                    }

                                }
                                objCoverTagging.SubCoverTagging = ListsubCoverTaggings;
                                listCoverTagging.Add(objCoverTagging);
                            }
                        }


                    }
                    RoomExpenseTagging objroomExpenseTagging = new RoomExpenseTagging();
                    List<RoomExpenseTagging> lstroomExpenseTaggings = new List<RoomExpenseTagging>();
                    if (ds.Tables[8] != null)
                    {

                        for (int t3 = 0; t3 < ds.Tables[8].Rows.Count; t3++)
                        {

                            objroomExpenseTagging.isRoomExpenseAvailable = Convert.ToBoolean(ds.Tables[8].Rows[t3]["isRoomExpenseAvailable"]);
                            objroomExpenseTagging.mnySumInsured = ds.Tables[8].Rows[t3]["mnySumInsured"].ToString();
                            objroomExpenseTagging.vchGroupId = ds.Tables[8].Rows[t3]["vchGroupId"].ToString();
                            objroomExpenseTagging.vchRoomType = ds.Tables[8].Rows[t3]["vchRoomType"].ToString();
                            objroomExpenseTagging.vchVolumeType = ds.Tables[8].Rows[t3]["vchVolumeType"].ToString();
                            objroomExpenseTagging.mnyVolumneLimit = ds.Tables[8].Rows[t3]["mnyVolumneLimit"].ToString();
                            objroomExpenseTagging.mnyUpto = ds.Tables[8].Rows[t3]["mnyUpto"].ToString();
                        }
                        lstroomExpenseTaggings.Add(objroomExpenseTagging);
                    }

                    listPolicyCoverTagging.Add(objPolicyCoverTagging);
                    objPolicyCoverTagging.CoverTagging = listCoverTagging;
                    objPolicyCoverTagging.RoomExpenseTagging = lstroomExpenseTaggings;
                    objrequestJSON.PolicyCoverTagging = listPolicyCoverTagging;
                }

                ReqJason = JsonConvert.SerializeObject(objrequestJSON);

                string sTrResponse = "";
                sTrResponse = APIPostMethodForData(ReqJason, DataPostUrl, vchTokenNumber);
                ApiPaymentLog(DataPostUrl, ReqJason, sTrResponse, Policyno);
                if (sTrResponse != null)
                {
                    ResponceProduct myDeserializedClass = JsonConvert.DeserializeObject<ResponceProduct>(sTrResponse);
                    if (myDeserializedClass.OverallStatus == "Completed")
                    {

                    }
                }
            }

        }
        public string APIPostMethod(string Json, string url)
        {
            string resultof = "";
            try
            {
                //WriteLog(Environment.NewLine + string.Format("** inside  APIPostMethodForPayment "));
                //Below Line added by NIA
                //System.Net.ServicePointManager.Expect100Continue = false;
                // declare ascii encoding
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                ASCIIEncoding encoding = new ASCIIEncoding();
                string strResult = string.Empty;
                // sample xml sent to Service & this data is sent in POST
                string postData = Json.ToString();
                // convert xmlstring to byte using ascii encoding
                byte[] data = encoding.GetBytes(postData);
                // declare httpwebrequet wrt url defined above
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                //webrequest.Credentials = new NetworkCredential("CignaAPIIntegration", "n199cH}@'HE;!@#");
                //string strAuth="Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("CignaAPIIntegration:n199cH}@'HE;!@#"));
                //webrequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("CignaAPIIntegration:n199cH}@'HE;!@#"));
                // webrequest.Credentials = CredentialCache.DefaultNetworkCredentials;
                webrequest.Timeout = 999999;
                //webrequest.KeepAlive = true;
                // set method as post
                webrequest.Method = "POST";
                // set content type 
                //webrequest.Headers["WWW-Authenticate"] = strAuth.ToString();

                /*
                webrequest.Headers.Add("Username", "CignaAPIIntegration");
                webrequest.Headers.Add("Password", "n199cH}@'HE;!@#");
                 */
                /*For New API*/
                /*
                webrequest.Headers.Add("app_key", "61e67f4ed7614ad822b494977444c7aa");
                webrequest.Headers.Add("app_id", "17449a01");
               */
                // webrequest.Headers.Add("app_key", app_key);
                // webrequest.Headers.Add("app_id", app_id);

                webrequest.ContentType = "application/json";
                webrequest.Accept = "application/json";
                // set content length
                webrequest.ContentLength = data.Length;
                //webrequest.Credentials = new 
                // get stream data out of webrequest object
                Stream newStream = webrequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                // declare & read response from service
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                // set utf8 encoding
                Encoding enc = System.Text.Encoding.UTF8;
                // read response stream from response object
                StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                // read string from stream data
                strResult = loResponseStream.ReadToEnd();
                // close the stream object
                loResponseStream.Close();
                // close the response object
                webresponse.Close();
                // below steps remove unwanted data from response string
                //return strResult.Replace("</string>", "");
                resultof = Convert.ToString(strResult);
            }
            catch (Exception ex)
            {
                // WriteLog(Environment.NewLine + string.Format("** Exception in bank api call " + ex.Message.ToString(), ex.Message.ToString()));
                //WriteLog(Environment.NewLine + string.Format("** Exception jason " + Json.ToString()));
                return resultof;
            }

            return resultof;
        }
        public string APIPostMethodForData(string Json, string url, string Token)
        {
            string resultof = null;
            try
            {
                //WriteLog(Environment.NewLine + string.Format("** inside  APIPostMethodForPayment "));
                //Below Line added by NIA
                //System.Net.ServicePointManager.Expect100Continue = false;
                // declare ascii encoding
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

                ASCIIEncoding encoding = new ASCIIEncoding();
                string strResult = string.Empty;
                // sample xml sent to Service & this data is sent in POST
                string postData = Json.ToString();
                // convert xmlstring to byte using ascii encoding
                byte[] data = encoding.GetBytes(postData);
                // declare httpwebrequet wrt url defined above
                HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
                //webrequest.Credentials = new NetworkCredential("CignaAPIIntegration", "n199cH}@'HE;!@#");
                //string strAuth="Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("CignaAPIIntegration:n199cH}@'HE;!@#"));
                //webrequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("CignaAPIIntegration:n199cH}@'HE;!@#"));
                // webrequest.Credentials = CredentialCache.DefaultNetworkCredentials;
                webrequest.Timeout = 999999;
                //webrequest.KeepAlive = true;
                // set method as post
                webrequest.Method = "POST";
                // set content type 
                //webrequest.Headers["WWW-Authenticate"] = strAuth.ToString();

                /*
                webrequest.Headers.Add("Username", "CignaAPIIntegration");
                webrequest.Headers.Add("Password", "n199cH}@'HE;!@#");
                 */
                /*For New API*/
                /*
                webrequest.Headers.Add("app_key", "61e67f4ed7614ad822b494977444c7aa");
                webrequest.Headers.Add("app_id", "17449a01");
               */
                webrequest.Headers.Add("Authorization", Token);
                // webrequest.Headers.Add("app_id", app_id);

                webrequest.ContentType = "application/json";
                webrequest.Accept = "application/json";
                // set content length
                webrequest.ContentLength = data.Length;
                //webrequest.Credentials = new 
                // get stream data out of webrequest object
                Stream newStream = webrequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                // declare & read response from service
                HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
                // set utf8 encoding
                Encoding enc = System.Text.Encoding.UTF8;
                // read response stream from response object
                StreamReader loResponseStream = new StreamReader(webresponse.GetResponseStream(), enc);
                // read string from stream data
                strResult = loResponseStream.ReadToEnd();
                // close the stream object
                loResponseStream.Close();
                // close the response object
                webresponse.Close();
                // below steps remove unwanted data from response string
                //return strResult.Replace("</string>", "");
                resultof = Convert.ToString(strResult);
            }
            catch (Exception ex)
            {
                // WriteLog(Environment.NewLine + string.Format("** Exception in bank api call " + ex.Message.ToString(), ex.Message.ToString()));
                //WriteLog(Environment.NewLine + string.Format("** Exception jason " + Json.ToString()));
                return resultof;
            }

            return resultof;
        }
        public void ApiPaymentLog(string VchUrl, string VchRequest, string VchResponse,string Vchpolicynumber)
        {
            ParametersEntity objDash = new ParametersEntity();
            objDash.VchUrl = VchUrl;
            objDash.VchRequest = VchRequest;
            objDash.VchResponse = VchResponse;
            objDash.Policyno = Vchpolicynumber;
            DataSet ds = new DataSet();
            ds = OblDALIintegration.APILog(objDash);
            if (ds.Tables[0] != null)
            {
                // OblDALIintegration.Payment_APILog(objDash);
                //return objDash.IntCPALId;
            }
        }
    }
}
