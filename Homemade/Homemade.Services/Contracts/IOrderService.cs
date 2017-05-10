namespace Homemade.Services.Contracts
{
    using System.Collections.Generic;
    using Homemade.Models.EntityModels;

    public interface IOrderService
    {
        void AddOrUpdate(Order order);

        Order GetById(int orderId);

        ICollection<Order> GetConfirmed();

        ICollection<Order> GetNonConfirmed();

        bool OrderState(int orderId);

        void ChangeState(int orderId);
    }
}
