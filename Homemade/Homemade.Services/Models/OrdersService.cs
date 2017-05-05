namespace Homemade.Services.Models
{
    using System.Linq;
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;

    public class OrdersService : BaseService<Order>
    {
        public void AddOrUpdate(Order order)
        {
            this.Repository.AddOrUpdate(order);
        }

        public Order GetById(int orderId)
        {
            return this.Repository.FindById(orderId);
        }

        public ICollection<Order> GetConfirmed()
        {
            return this.Repository.FindBy(order => order.Confirmed == true).ToList();
        }

        public ICollection<Order> GetNonConfirmed()
        {
            return this.Repository.FindBy(order => order.Confirmed == false).ToList();
        }

        public bool OrderState(int orderId)
        {
            return this.Repository.FindById(orderId).Confirmed;
        }

        public void ChangeState(int orderId)
        {
            Order order = this.Repository.FindById(orderId);
            order.Confirmed = order.Confirmed == true ? false : true;
            this.Repository.AddOrUpdate(order);
        }
    }
}
