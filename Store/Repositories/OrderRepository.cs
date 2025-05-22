using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        IQueryable<Order> IOrderRepository.Orders => _context.Orders.Include(o => o.Lines) //siparişleri daha rahat görüntülemek için yazdık
        .ThenInclude(c1 => c1.Product)
        .OrderBy(o => o.Shipped)
        .ThenByDescending(o => o.OrderId);

        int IOrderRepository.NumberOfInProcess => _context.Orders.Count(o => o.Shipped.Equals(false));

        void IOrderRepository.Complete(int id)
        {
            var order = FindByCondition(o => o.OrderId.Equals(id), true);
            if (order is null)
                throw new Exception("Order could not found!");
            order.Shipped = true;

        }

        Order? IOrderRepository.GetOneOrder(int id)
        {
            return FindByCondition(o => o.OrderId.Equals(id), false);
        }

        void IOrderRepository.SaveOrder(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if (order.OrderId == 0)
                _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetOrdersByEmail(string email)
{
    return _context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Product)
        .Where(o => o.Email == email)
        .OrderByDescending(o => o.OrderedAt)
        .ToList();
}

    }
    
}