using Core.Entities.OrderAggregate;

namespace Core.Specifications
{
    public class OrderItemSpecification : BaseSpecification<OrderItem>
    {
        public OrderItemSpecification() : base()
        {
            AddInclude(x => x.ItemOrdered);
        }
    }
}
