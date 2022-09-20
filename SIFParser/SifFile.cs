namespace SIFParser
{
    /// <summary>
    /// S-, S%=<Discount Percentage, i.e.: Sell Price = PL ? (PL * S- * 0.01)>
    /// P%, B%=<Purchase/Buy Percentage, i.e.: Purchase Cost = PL ? (PL * P % *0.01) >
    /// </summary>

    public class SIFFile
    {
        public string ProductNumber { get; set; }
        public string ProductDescription { get; set; }
        public string ManufacturerCode { get; set; }
        public string SideMark { get; set; }
        public string Quantity { get; set; }
        public string ListPrice { get; set; }
        public string OptionNumber { get; set; }
        public string OptionDescription { get; set; }
        public string AttributeNumber { get; set; }
        public string AttributeDescription { get; set; }
        public string ProductPicture { get; set; }
        public string DesignManagerSalesCategory { get; set; }
        public string ItemBudgetAmount { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string ManufacturerName { get; set; }
        public string Color { get; set; }
    }
}