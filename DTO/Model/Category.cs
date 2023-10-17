using System;

namespace DTO.Model
{
    public class Category
    {
        public int IDCat { get; set; }
        public string TypeProduct { get; set; } = "";
        public bool IsBlocked { get; set; } = false;
        public int SupplierID { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }


        public bool Equals(Category obj)
        {
            return obj != null
                && obj.IDCat == this.IDCat
                && obj.TypeProduct == this.TypeProduct
                && obj.IsBlocked == this.IsBlocked
                && obj.RowInsertTime == this.RowInsertTime
                && obj.RowUpdateTime == this.RowUpdateTime;
        }

        public void ChangeObjName(string nameNew)
        {
            TypeProduct = nameNew;

        }
        public void ChangeBlockValue(bool option)
        {
            IsBlocked = option;
        }

        public string InfoString()
        {
            return $"Id: {IDCat}\tCategory: {TypeProduct}\tIsBlocked: {IsBlocked}\tInsert Time: {RowInsertTime}\tUpdate: {RowUpdateTime}";
        }
    }
}
