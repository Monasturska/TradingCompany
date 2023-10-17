using System;

namespace DTO.Model
{
    public class Supplier
    {
        public int Id { get; set; }
        public string NameSupplier { get; set; }
        public bool IsBlocked { get; set; } = false;
        public DateTime ArrivingTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public bool Equals(Supplier obj)
        {
            return obj != null
                && obj.Id == this.Id
                && obj.NameSupplier == this.NameSupplier
                && obj.IsBlocked == this.IsBlocked
                && obj.ArrivingTime == this.ArrivingTime
                && obj.RowUpdateTime == this.RowUpdateTime;
        }
        public void ChangeObjName(string nameNew)
        {
            NameSupplier = nameNew;
        }
        public void ChangeBlockValue(bool option)
        {
            IsBlocked = option;
        }
        public string InfoString()
        {
            return $"Id: {Id}\tSupplier: {NameSupplier}\tIsBlocked: {IsBlocked}\tTime arriving: {ArrivingTime}\tUpdate: {RowUpdateTime}";
        }
    }
}

