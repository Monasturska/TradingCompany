using System;

namespace DTO.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string NameObj { get; set; }
        public int PriceIn { get; set; }
        public int PriceOut { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public bool Equals(Product obj)
        {
            return obj != null
                && obj.Id == this.Id
                && obj.NameObj == this.NameObj
                && obj.PriceIn == this.PriceIn
                && obj.PriceOut == this.PriceOut
                && obj.RowInsertTime == this.RowInsertTime
                && obj.RowUpdateTime == this.RowUpdateTime;
        }
        public void ChangeObjName(string nameNew)
        {
            NameObj = nameNew;
        }
        public string InfoString()
        {
            return $"Id: {Id}\tName: {NameObj}\tPrice in/out: {PriceIn}/{PriceOut}\tCategoryId: {CategoryID}" +
                $"\tSupplierId: {SupplierID}\tInsert Time: {RowInsertTime}\tUpdate: {RowUpdateTime}";
        }
    }
}

