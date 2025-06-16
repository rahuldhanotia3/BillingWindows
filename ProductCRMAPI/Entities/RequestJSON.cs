using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCRMAPI.Entities
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class RequestJSON
    {
        public string vchTokenNumber { get; set; }
        public List<LineOfBusinessDetail> LineOfBusinessDetails { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
        public List<CoverDetail> CoverDetails { get; set; }
        public List<GroupPolicyTagging> GroupPolicyTagging { get; set; }
        public List<PolicyCoverTagging> PolicyCoverTagging { get; set; }
    }
    public class LineOfBusinessDetail
    {
        public string vchLobCode { get; set; }
        public string vchLob { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
    public class ProductDetail
    {
        public string vchPolicyType { get; set; }
        public string vchProductName { get; set; }
        public string vchProductCode { get; set; }
        public string vchProductSchema { get; set; }
        public string vchIRDACode { get; set; }
        public string mnyMinLimit { get; set; }
        public string mnyMaxLimit { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
    public class CoverDetail
    {
        public string vchCoverType { get; set; }
        public string vchSection { get; set; }
        public string vchSectionCode { get; set; }
        public string vchCoverPerilCode { get; set; }
        public string vchCoverDesc { get; set; }
        public string vchCoverCode { get; set; }
        public string vchLimitType { get; set; }
        public string mnyMinLimit { get; set; }
        public string mnyMaxLimit { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public List<CoverPartDetail> CoverPartDetails { get; set; }
    }
    public class GroupPolicyTagging
    {
        public string vchPolicyNumber { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
    public class PolicyCoverTagging
    {
        public string mnySumInsured { get; set; }
        public List<CoverTagging> CoverTagging { get; set; }
    }
    public class CoverPartDetail
    {
        public string vchCoverPartDesc { get; set; }
        public string Status { get; set; }
        public string vchCoverCode { get; set; }
    }

    public class CoverTagging
    {
        public string vchCoverCode { get; set; }
        public string vchLimitType { get; set; }
        public string intUnit { get; set; }
        public string mnyLimit { get; set; }
        public string mnyMaxLimit { get; set; }
        public string intPreDays { get; set; }
        public string intPostDays { get; set; }
        public string fltDefaultValue { get; set; }
        public string vchRemarks { get; set; }
        public string Status { get; set; }
        public List<SubCoverTagging> SubCoverTagging { get; set; }
    }

    public class SubCoverTagging
    {
        public string vchCoverType { get; set; }
        public string vchCoverPartCode { get; set; }
        public string vchLimitType { get; set; }
        public string intUnit { get; set; }
        public string mnyLimit { get; set; }
        public string mnyMaxLimit { get; set; }
        public string intPreDays { get; set; }
        public string intPostDays { get; set; }
        public string fltDefaultValue { get; set; }
        public string vchRemarks { get; set; }
        public string Status { get; set; }
    }
}
