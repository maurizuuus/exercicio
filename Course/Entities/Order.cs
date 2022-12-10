using System;
using System.Globalization;
using Course.Entities.Enums;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> Item { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Item.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Item.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Item)
            {
                sum += item.SubTotal();
            }
            return sum;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString());
            sb.AppendLine("Order status: " + Status.ToString());
            sb.AppendLine($"Client: {Client.Name} ({Client.Birth.ToString("dd/MM/yyyy")}) - {Client.Email}");
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Item)
            {
                sb.AppendLine(item.Product.Name + ", $" + item.Price.ToString("F2", CultureInfo.InvariantCulture) + ", Quantity: " + item.Quantity + ", Subtotal: $" + item.Price.ToString("F2", CultureInfo.InvariantCulture));

            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
