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

namespace ProductCRMAPI
{
    public partial class Form1 : Form
    {
        DALIintegration OblDALIintegration = new DALIintegration();
        ParametersEntity objParametersEntity = new ParametersEntity();
        RequestJSON objrequestJSON = new RequestJSON();
        string ReqJason = "";
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
                        GetDataByPolicyInfoID(Policyno, Policyinfoid, enumIsMasterPolicy);
                    }

                }

            }
            catch (Exception Ex)
            {

                //throw Ex;
            }


        }

        void GetDataByPolicyInfoID(string Policyno, string Policyinfoid, string enumIsMasterPolicy)
        {
            string vchTokenNumber = "cbf9fb36618642808ce3ea2762bb1a276263";
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
                CoverDetail objCoverDetail = new CoverDetail();
                List<CoverPartDetail> objListCoverPartDetails = new List<CoverPartDetail>();
                CoverPartDetail objCoverPartDetail = new CoverPartDetail();
                for (int t = 0; t < ds.Tables[2].Rows.Count; t++)
                {
                    #region CoverDetails
                   
                   
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
                    objCoverDetail.Remarks= ds.Tables[2].Rows[t]["Remarks"].ToString();
                   
                  
                    #endregion CoverDetails
                    if (ds.Tables[3] != null)
                    {
                        
                        for (int t1 = 0; t1 < ds.Tables[3].Rows.Count; t1++)
                        {
                            objCoverPartDetail.vchCoverPartDesc = ds.Tables[3].Rows[t1]["vchCoverPartDesc"].ToString();
                            objCoverPartDetail.Status = ds.Tables[3].Rows[t1]["Status"].ToString();
                            objCoverPartDetail.vchCoverCode = ds.Tables[3].Rows[t1]["vchCoverCode"].ToString();
                           
                        }

                    }
                   
                    listCoverDetail.Add(objCoverDetail);
                    objrequestJSON.CoverDetails = listCoverDetail;
                    objListCoverPartDetails.Add(objCoverPartDetail);
                    objCoverDetail.CoverPartDetails = objListCoverPartDetails;

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

                    listGroupPolicyTagging.Add(objGroupPolicyTagging);
                    objrequestJSON.GroupPolicyTagging = listGroupPolicyTagging;
                    #endregion ProductDetail
                }

            }
            if (ds.Tables[5] != null)
            {
                List<PolicyCoverTagging> listPolicyCoverTagging = new List<PolicyCoverTagging>();
                PolicyCoverTagging objPolicyCoverTagging = new PolicyCoverTagging();
                List<CoverTagging> listCoverTagging= new List<CoverTagging>();
                CoverTagging objCoverTagging=new CoverTagging();
                List<SubCoverTagging> ListsubCoverTaggings = new List<SubCoverTagging>();
                SubCoverTagging objsubCoverTagging=new SubCoverTagging();
                for (int t = 0; t < ds.Tables[5].Rows.Count; t++)
                {
                    objPolicyCoverTagging.mnySumInsured = ds.Tables[5].Rows[t]["mnySumInsured"].ToString();
                   
                   
                    if (ds.Tables[6] != null)
                    {

                        for (int t1 = 0; t1 < ds.Tables[6].Rows.Count; t1++)
                        {
                            objCoverTagging.vchCoverCode = ds.Tables[6].Rows[t1]["vchCoverCode"].ToString();
                            objCoverTagging.vchLimitType = ds.Tables[6].Rows[t1]["vchLimitType"].ToString();
                            objCoverTagging.intUnit = ds.Tables[6].Rows[t1]["intUnit"].ToString();
                            objCoverTagging.mnyLimit = ds.Tables[6].Rows[t1]["mnyLimit"].ToString();
                            objCoverTagging.mnyMaxLimit = ds.Tables[6].Rows[t1]["mnyMaxLimit"].ToString();
                            objCoverTagging.intPreDays = ds.Tables[6].Rows[t1]["intPreDays"].ToString();
                            objCoverTagging.intPostDays = ds.Tables[6].Rows[t1]["intPostDays"].ToString();
                            objCoverTagging.fltDefaultValue = ds.Tables[6].Rows[t1]["fltDefaultValue"].ToString();
                            objCoverTagging.vchRemarks = ds.Tables[6].Rows[t1]["vchRemarks"].ToString();
                            objCoverTagging.Status = ds.Tables[6].Rows[t1]["Status"].ToString();

                            if (ds.Tables[7] != null)
                            {

                                for (int t2 = 0; t2 < ds.Tables[7].Rows.Count; t2++)
                                {
                                    objsubCoverTagging.vchCoverType = ds.Tables[7].Rows[t2]["vchCoverType"].ToString();
                                    objsubCoverTagging.vchCoverPartCode = ds.Tables[7].Rows[t2]["vchCoverPartCode"].ToString();
                                    objsubCoverTagging.vchLimitType = ds.Tables[7].Rows[t2]["vchLimitType"].ToString();
                                    objsubCoverTagging.intUnit = ds.Tables[7].Rows[t2]["intUnit"].ToString();
                                    objsubCoverTagging.mnyLimit = ds.Tables[7].Rows[t2]["mnyLimit"].ToString();
                                    objsubCoverTagging.mnyMaxLimit = ds.Tables[7].Rows[t2]["mnyMaxLimit"].ToString();
                                    objsubCoverTagging.intPreDays = ds.Tables[7].Rows[t2]["intPreDays"].ToString();
                                    objsubCoverTagging.intPostDays = ds.Tables[7].Rows[t2]["intPostDays"].ToString();
                                    objsubCoverTagging.fltDefaultValue = ds.Tables[7].Rows[t2]["fltDefaultValue"].ToString();
                                    objsubCoverTagging.vchRemarks = ds.Tables[7].Rows[t2]["vchRemarks"].ToString();
                                    objsubCoverTagging.Status = ds.Tables[7].Rows[t2]["Status"].ToString();

                                }
                                ListsubCoverTaggings.Add(objsubCoverTagging);
                            }
                            listPolicyCoverTagging.Add(objPolicyCoverTagging);
                        }

                    }
                    objrequestJSON.PolicyCoverTagging = listPolicyCoverTagging;
                    listCoverTagging.Add(objCoverTagging);

                    objPolicyCoverTagging.CoverTagging = listCoverTagging;
                    
                   objCoverTagging.SubCoverTagging= ListsubCoverTaggings;

                }


            }

            ReqJason = JsonConvert.SerializeObject(objrequestJSON);
        }
    }
}
