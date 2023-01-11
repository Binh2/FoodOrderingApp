namespace WEBAPI.Models
{
    public interface IOrderStateType
    {
        int OrderStateTypeID { get; set; }
        int OrderStateTypeName { get; set; }
        int OrderStateTypeIsDone { get; set; }
    }
    public class OrderStateType : IOrderStateType
    {
        public int OrderStateTypeID { get; set; }
        public int OrderStateTypeName { get; set; }
        public int OrderStateTypeIsDone { get; set; }
    }
}