namespace Homemade.Services.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;
    using Homemade.Services.Contracts;

    public class OrdersService : BaseService, IOrderService
    {
        public void AddOrUpdate(Order order)
        {
            this.UnitOfWork.Orders.AddOrUpdate(order);
            this.UnitOfWork.Commit();
        }

        public Order GetById(int orderId)
        {
            return this.UnitOfWork.Orders.FindById(orderId);
        }

        public ICollection<Order> GetConfirmed()
        {
            return this.UnitOfWork.Orders.FindBy(order => order.Confirmed == true).ToList();
        }

        public ICollection<Order> GetNonConfirmed()
        {
            return this.UnitOfWork.Orders.FindBy(order => order.Confirmed == false).ToList();
        }

        public bool OrderState(int orderId)
        {
            return this.UnitOfWork.Orders.FindById(orderId).Confirmed;
        }

        public void ChangeState(int orderId)
        {
            Order order = this.UnitOfWork.Orders.FindById(orderId);
            order.Confirmed = order.Confirmed == true ? false : true;
            this.UnitOfWork.Orders.AddOrUpdate(order);
            this.UnitOfWork.Commit();
        }
    }
}
