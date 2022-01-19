using Newtonsoft.Json;

namespace TsoftConsoleApp.Models;
public class GetProductModel
    {
        [JsonProperty("ProductId")]
        public string ProductId { get; set; }

        [JsonProperty("ProductCode")]
        public string ProductCode { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("DefaultCategoryId")]
        public string DefaultCategoryId { get; set; }

        [JsonProperty("DefaultCategoryName")]
        public string DefaultCategoryName { get; set; }

        [JsonProperty("DefaultCategoryPath")]
        public string DefaultCategoryPath { get; set; }

        [JsonProperty("SupplierProductCode")]
        public string SupplierProductCode { get; set; }

        [JsonProperty("Barcode")]
        public string Barcode { get; set; }

        [JsonProperty("Stock")]
        public string Stock { get; set; }

        [JsonProperty("IsActive")]
        public string IsActive { get; set; }

        [JsonProperty("IsApproved")]
        public string IsApproved { get; set; }

        [JsonProperty("HasSubProducts")]
        public string HasSubProducts { get; set; }

        [JsonProperty("ComparisonSites")]
        public string ComparisonSites { get; set; }

        [JsonProperty("Vat")]
        public string Vat { get; set; }

        [JsonProperty("CurrencyId")]
        public string CurrencyId { get; set; }

        [JsonProperty("BuyingPrice")]
        public string BuyingPrice { get; set; }

        [JsonProperty("SellingPrice")]
        public string SellingPrice { get; set; }

        [JsonProperty("DiscountedPrice")]
        public string DiscountedPrice { get; set; }

        [JsonProperty("SellingPriceVatIncludedNoDiscount")]
        public string SellingPriceVatIncludedNoDiscount { get; set; }

        [JsonProperty("SellingPriceVatIncluded")]
        public string SellingPriceVatIncluded { get; set; }

        [JsonProperty("SeoLink")]
        public string SeoLink { get; set; }

        [JsonProperty("StockUnit")]
        public string StockUnit { get; set; }

        [JsonProperty("StockUnitId")]
        public string StockUnitId { get; set; }

        [JsonProperty("SearchKeywords")]
        public string SearchKeywords { get; set; }

        [JsonProperty("DisplayOnHomepage")]
        public string DisplayOnHomepage { get; set; }

        [JsonProperty("IsNewProduct")]
        public string IsNewProduct { get; set; }

        [JsonProperty("OnSale")]
        public string OnSale { get; set; }

        [JsonProperty("IsDisplayProduct")]
        public string IsDisplayProduct { get; set; }

        [JsonProperty("VendorDisplayOnly")]
        public string VendorDisplayOnly { get; set; }

        [JsonProperty("DisplayWithVat")]
        public string DisplayWithVat { get; set; }

        [JsonProperty("Brand")]
        public string Brand { get; set; }

        [JsonProperty("BrandId")]
        public string BrandId { get; set; }

        [JsonProperty("BrandLink")]
        public string BrandLink { get; set; }

        [JsonProperty("Model")]
        public string Model { get; set; }

        [JsonProperty("ModelId")]
        public string ModelId { get; set; }

        [JsonProperty("SupplierId")]
        public string SupplierId { get; set; }

        [JsonProperty("CustomerGroupDisplay")]
        public string CustomerGroupDisplay { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("Magnifier")]
        public string Magnifier { get; set; }

        [JsonProperty("MemberMinOrder")]
        public string MemberMinOrder { get; set; }

        [JsonProperty("MemberMaxOrder")]
        public string MemberMaxOrder { get; set; }

        [JsonProperty("VendorMinOrder")]
        public string VendorMinOrder { get; set; }

        [JsonProperty("VendorMaxOrder")]
        public string VendorMaxOrder { get; set; }

        [JsonProperty("ShortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("SavingDate")]
        public string SavingDate { get; set; }

        [JsonProperty("CreateDateTimeStamp")]
        public string CreateDateTimeStamp { get; set; }

        [JsonProperty("CreateDate")]
        public DateTime CreateDate { get; set; }

        [JsonProperty("FilterGroupId")]
        public string FilterGroupId { get; set; }

        [JsonProperty("ListNo")]
        public string ListNo { get; set; }

        [JsonProperty("OwnerId")]
        public string OwnerId { get; set; }

        [JsonProperty("UpdateDate")]
        public string UpdateDate { get; set; }

        [JsonProperty("StockUpdateDate")]
        public string StockUpdateDate { get; set; }

        [JsonProperty("PriceUpdateDate")]
        public string PriceUpdateDate { get; set; }

        [JsonProperty("StockUpdatePlatform")]
        public string StockUpdatePlatform { get; set; }

        [JsonProperty("PriceUpdatePlatform")]
        public string PriceUpdatePlatform { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("OpportunityProduct")]
        public string OpportunityProduct { get; set; }

        [JsonProperty("OpportunityStart")]
        public string OpportunityStart { get; set; }

        [JsonProperty("OpportunityFinish")]
        public string OpportunityFinish { get; set; }

        [JsonProperty("AgeGroup")]
        public string AgeGroup { get; set; }

        [JsonProperty("CommentRate")]
        public string CommentRate { get; set; }

        [JsonProperty("DisablePaymentTypes")]
        public object DisablePaymentTypes { get; set; }

        [JsonProperty("DisableCargoCompany")]
        public object DisableCargoCompany { get; set; }

        [JsonProperty("StatViews")]
        public string StatViews { get; set; }

        [JsonProperty("StatRecommendations")]
        public string StatRecommendations { get; set; }

        [JsonProperty("HomepageSort")]
        public string HomepageSort { get; set; }

        [JsonProperty("MostSoldSort")]
        public string MostSoldSort { get; set; }

        [JsonProperty("NewestSort")]
        public string NewestSort { get; set; }

        [JsonProperty("Point")]
        public string Point { get; set; }

        [JsonProperty("EftRate")]
        public string EftRate { get; set; }

        [JsonProperty("Numeric1")]
        public string Numeric1 { get; set; }

        [JsonProperty("HasImages")]
        public string HasImages { get; set; }

        [JsonProperty("DefaultSubProductId")]
        public string DefaultSubProductId { get; set; }

        [JsonProperty("RelatedProductsIds1")]
        public string RelatedProductsIds1 { get; set; }

        [JsonProperty("RelatedProductsIds2")]
        public string RelatedProductsIds2 { get; set; }

        [JsonProperty("RelatedProductsIds3")]
        public string RelatedProductsIds3 { get; set; }

        [JsonProperty("FreeDeliveryMember")]
        public string FreeDeliveryMember { get; set; }

        [JsonProperty("FreeDeliveryVendor")]
        public string FreeDeliveryVendor { get; set; }

        [JsonProperty("Label1")]
        public string Label1 { get; set; }

        [JsonProperty("Label2")]
        public string Label2 { get; set; }

        [JsonProperty("Label3")]
        public string Label3 { get; set; }

        [JsonProperty("Label4")]
        public string Label4 { get; set; }

        [JsonProperty("Label5")]
        public string Label5 { get; set; }

        [JsonProperty("Label6")]
        public string Label6 { get; set; }

        [JsonProperty("Label7")]
        public string Label7 { get; set; }

        [JsonProperty("Label8")]
        public string Label8 { get; set; }

        [JsonProperty("Label9")]
        public string Label9 { get; set; }

        [JsonProperty("Label10")]
        public string Label10 { get; set; }

        [JsonProperty("Additional1")]
        public string Additional1 { get; set; }

        [JsonProperty("Additional2")]
        public string Additional2 { get; set; }

        [JsonProperty("Additional3")]
        public string Additional3 { get; set; }

        [JsonProperty("Additional4")]
        public string Additional4 { get; set; }

        [JsonProperty("Additional5")]
        public string Additional5 { get; set; }

        [JsonProperty("Additional6")]
        public string Additional6 { get; set; }

        [JsonProperty("Currency")]
        public string Currency { get; set; }

        [JsonProperty("Supplier")]
        public string Supplier { get; set; }

        [JsonProperty("DefaultCategoryCode")]
        public string DefaultCategoryCode { get; set; }

        [JsonProperty("ImageUrlCdn")]
        public string ImageUrlCdn { get; set; }
    }

