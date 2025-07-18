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
        public string vchProductCode { get; set; }
        public List<CoverPartDetail> CoverPartDetails { get; set; }
    }
    public class GroupPolicyTagging
    {
        public string vchPolicyNumber { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
        public string vchProductCode { get; set; }
    }
    public class PolicyCoverTagging
    {
        public string mnySumInsured { get; set; }
        public string vchGroupId { get; set; }
        public List<CoverTagging> CoverTagging { get; set; }
        public List<RoomExpenseTagging> RoomExpenseTagging { get; set; }
    }
    public class CoverPartDetail
    {
        public string vchCoverPartDesc { get; set; }
        public string Status { get; set; }
        public string vchCoverCode { get; set; }
    }
    public class CoverTagging
    {
        public string mnySumInsured { get; set; }
        public string vchGroupId { get; set; }
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
        public string vchCoverType { get; set; }
        public string vchProductCode { get; set; }
        public List<SubCoverTagging> SubCoverTagging { get; set; }
    }

    public class RoomExpenseTagging
    {
        public bool isRoomExpenseAvailable { get; set; }
        public string mnySumInsured { get; set; }
        public string vchGroupId { get; set; }
        public string vchRoomType { get; set; }
        public string vchVolumeType { get; set; }
        public string mnyVolumneLimit { get; set; }
        public string mnyUpto { get; set; }
    }
    public class SubCoverTagging
    {
        public string mnySumInsured { get; set; }
        public string vchGroupId { get; set; }
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

    public class AuthApiResp
    {
        public string status { get; set; }
        public string Message { get; set; }
        public Data Data { get; set; }
    }
    public class Data
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string TokenNumber { get; set; }
        public string ExpireAt { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Cover
    {
        public string Message { get; set; }
    }

    public class CoverPartDetail1
    {
        public string Message { get; set; }
    }

    public class CoverTagging1
    {
        public string Message { get; set; }
    }

    public class GroupPolicyTagging1
    {
        public string Message { get; set; }
    }

    public class LOB
    {
        public string Message { get; set; }
    }

    public class PolicyCoverTagging1
    {
        public string Message { get; set; }
    }

    public class Product
    {
        public string Message { get; set; }
    }

    public class Result
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LOB> LOB { get; set; }
        public List<Product> Product { get; set; }
        public List<Cover> Cover { get; set; }
        public List<GroupPolicyTagging1> GroupPolicyTagging { get; set; }
        public List<PolicyCoverTagging1> PolicyCoverTagging { get; set; }
        public List<CoverPartDetail1> CoverPartDetails { get; set; }
        public List<CoverTagging1> CoverTagging { get; set; }
        public List<SubCoverTagging1> SubCoverTagging { get; set; }
    }

    public class ResponceProduct
    {
        public string OverallStatus { get; set; }
        public List<Result> Results { get; set; }
    }

    public class SubCoverTagging1
    {
        public string Message { get; set; }
    }




}
