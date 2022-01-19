using Bussiness.JsonConverters;
using Bussiness.Models;
using Newtonsoft.Json;
using TsoftSimpleClientApp.Helpers.JsonConverters;

namespace TsoftSimpleClientApp.Models
{
    [Serializable]
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            Message = new List<ResponseMessage>();
        }

        [JsonProperty("success")] public bool Success { get; set; }

        [JsonProperty("data")] public T Data { get; set; }

        [JsonProperty("message")] public List<ResponseMessage> Message { get; set; }

        [JsonProperty("summary")] public ResponseSummary Summary { get; set; }
    }

    [Serializable]
    public class ResponseSummary
    {
        [JsonProperty("totalRecordCount")]
        public string TotalRecordCount { get; set; }
        [JsonProperty("primaryKey")]
        public string PrimaryKey { get; set; }
    }

    [Serializable]
    public class ResponseMessage
    {
        public ResponseMessage()
        {
            ErrorField = new List<string>();
            Text = new List<string>();
        }

        [JsonProperty("type")] public int? Type { get; set; }
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("index")] public int? Index { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("subid")] public string SubId { get; set; }
        [JsonProperty("text")] public List<string> Text { get; set; }
        [JsonProperty("errorField")] public List<string> ErrorField { get; set; }
    }

    [Serializable]
    public class LoginResponseModel
    {
        [JsonProperty("userId")] public string UserId { get; set; }
        [JsonProperty("username")] public string Username { get; set; }
        [JsonProperty("token")] public string Token { get; set; }
        [JsonProperty("secretKey")] public string SecretKey { get; set; }

        [JsonProperty("expirationTime"),JsonConverter(typeof(DateTimeFormatConverter))]
        public DateTime ExpirationTime { get; set; }

        [JsonProperty("limited")] public int Limited { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("tableId")] public string TableId { get; set; }
    }

    public class TsoftProductLabel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class TsoftProductCategory
    {
        public string CategoryId { get; set; }
        public string CategoryCode { get; set; }
    }

    public class TsoftProductImage
    {
        public string ImageUrl { get; set; }
        public string ListNo { get; set; }
        public string PropertyId { get; set; }
    }


    public class ProductResponse
    {
        public ProductResponse()
        {
            Categories = new List<TsoftProductCategory>();
            PackageProducts = new List<dynamic>();
            ImageUrls = new List<TsoftProductImage>();
        }
        
        public string SubProductId { get; set; }
        public string SubProductCode { get; set; }

        public string MainProductId { get; set; }

        public string Property1 { get; set; }
        
        public string Property2 { get; set; }
        
        public string PropertyId1 { get; set; }
        
        public string PropertyId2 { get; set; }
        
        public string Property1ListNo { get; set; }
        
        public string Property2ListNo { get; set; }
        
        public string CBM { get; set; }
        
        public string SupplierSubProductCode { get; set; }
        public string MainProductCode { get; set; }

        public bool MainProductIsActive { get; set; }
        
        public string MainProductImageUrl { get; set; }
        
        public string ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string DefaultCategoryId { get; set; }

        public string DefaultCategoryName { get; set; }

        public string DefaultCategoryPath { get; set; }

        public string SupplierProductCode { get; set; }

        public string Barcode { get; set; }

        public string Stock { get; set; }

        [JsonConverter(typeof(ZeroOneBooleanConverter),BooleanJsonConvertOption.ZeroOne)]
        public bool IsActive { get; set; }

        public bool ComparisonSites { get; set; }

        public bool IsApproved { get; set; }

        [JsonConverter(typeof(ZeroOneBooleanConverter),BooleanJsonConvertOption.TrueFalse)]
        public bool HasSubProducts { get; set; }

        public bool HasImages { get; set; }

        public string Vat { get; set; }

        public string CurrencyId { get; set; }

        public string BuyingPrice { get; set; }

        public string SellingPrice { get; set; }

        public string SellingPriceVatIncludedNoDiscount { get; set; }

        public double? SellingPriceVatIncluded { get; set; }

        public string DiscountedSellingPrice { get; set; }

        public string SeoLink { get; set; }

        public string StockUnit { get; set; }

        public string StockUnitId { get; set; }

        public string SearchKeywords { get; set; }

        public bool DisplayOnHomepage { get; set; }

        public bool IsNewProduct { get; set; }

        public bool OnSale { get; set; }

        public bool IsDisplayProduct { get; set; }

        public bool VendorDisplayOnly { get; set; }

        public bool DisplayWithVat { get; set; }

        public string Brand { get; set; }

        public string BrandId { get; set; }

        public string BrandLink { get; set; }

        public string Model { get; set; }

        public string ModelId { get; set; }

        public string SupplierId { get; set; }

        public string CustomerGroupDisplay { get; set; }

        public string Additional1 { get; set; }

        public string Additional2 { get; set; }

        public string Additional3 { get; set; }
        
        public string Additional4 { get; set; }
        
        public string ImageUrl { get; set; }

        public bool Magnifier { get; set; }

        public string MemberMinOrder { get; set; }

        public string MemberMaxOrder { get; set; }

        public string VendorMinOrder { get; set; }

        public string VendorMaxOrder { get; set; }

        public bool FreeDeliveryMember { get; set; }

        public bool FreeDeliveryVendor { get; set; }

        public string ShortDescription { get; set; }
        

        [JsonConverter(typeof(ProductDateTimeFormatConverter))]
        public DateTime SavingDate { get; set; }

        public long? CreateDateTimeStamp { get; set; }

        [JsonConverter(typeof(ProductDateTimeFormatConverter))]
        public DateTime CreateDate { get; set; }

        public string FilterGroupId { get; set; }

        public string ListNo { get; set; }

        public string OwnerId { get; set; }

        [JsonConverter(typeof(ProductDateTimeFormatConverter))]
        public DateTime StockUpdateDate { get; set; }

        public string StockUpdatePlatform { get; set; }

        [JsonConverter(typeof(ProductDateTimeFormatConverter))]
        public DateTime PriceUpdateDate { get; set; }

        public string PriceUpdatePlatform { get; set; }

        public string Gender { get; set; }

        public string OpportunityProduct { get; set; }

        public string OpportunityStart { get; set; }

        public string OpportunityFinish { get; set; }

        public string DisablePaymentTypes { get; set; }

        public string AgeGroup { get; set; }

        public string Point { get; set; }

        public string Numeric1 { get; set; }

        public string DefaultSubProductId { get; set; }

        public string DisableCargoCompany { get; set; }

        public string HomepageSort { get; set; }

        public string MostSoldSort { get; set; }

        public string NewestSort { get; set; }

        public string EftRate { get; set; }

        public string RelatedProductsBlock1 { get; set; }
        
        public string RelatedProductsBlock2 { get; set; }
        
        public string RelatedProductsBlock3 { get; set; }

        public TsoftProductLabel Label1 { get; set; }
        
        public TsoftProductLabel Label2 { get; set; }
        
        public TsoftProductLabel Label3 { get; set; }
        
        public TsoftProductLabel Label4 { get; set; }
        
        public TsoftProductLabel Label5 { get; set; }
        
        public TsoftProductLabel Label6 { get; set; }
        
        public TsoftProductLabel Label7 { get; set; }
        
        public TsoftProductLabel Label8 { get; set; }
        
        public TsoftProductLabel Label9 { get; set; }
        
        public TsoftProductLabel Label10 { get; set; }

        public string DefaultCategoryCode { get; set; }

        public string Currency { get; set; }

        public string Supplier { get; set; }

        public double? DiscountedSellingPriceTl { get; set; }

        public List<TsoftProductCategory> Categories { get; set; }

        public string Details { get; set; }

        public string Width { get; set; }

        public string Height { get; set; }

        public string Depth { get; set; }

        public string Weight { get; set; }

        public string Cbm { get; set; }

        public string WarrantyInfo { get; set; }

        public string DeliveryInfo { get; set; }

        public string DeliveryTime { get; set; }

        public string ProductNote { get; set; }

        public string Document { get; set; }

        public string Warehouse { get; set; }

        public string PersonalizationId { get; set; }

        public string SeoTitle { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        public string SeoSettingsId { get; set; }

        public string Gtip { get; set; }

        public string CountryOfOrigin { get; set; }

        public List<dynamic> PackageProducts { get; set; }

        public List<TsoftProductImage> ImageUrls { get; set; }
    }
}