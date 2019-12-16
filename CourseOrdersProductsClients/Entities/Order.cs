using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using CourseOrdersProductsClients.Entities.Enums;

namespace CourseOrdersProductsClients.Entities {
    class Order {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public Order() {
        }

        public Order(DateTime moment, OrderStatus status, Client client) {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item) {
            OrderItems.Add(item);
        }

        public void RemoveItem(OrderItem item) {
            OrderItems.Remove(item);
        }

        public double Total() {
            double sum = 0.00;
            foreach (OrderItem i in OrderItems) {
                sum = i.SubTotal();
            }
            return sum;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            double totalPrice = 0.0;
            sb.AppendLine();
            sb.AppendLine("ORDER SUMMARY: ");
            sb.AppendLine();
            sb.AppendLine("Order moment: " + Moment);
            sb.AppendLine("Order status: " + Status);
            sb.Append("Client: " + Client.Name);
            sb.Append(Client.birthDate.ToString(" (dd/MM/yyyy) "));
            sb.AppendLine(" - " + Client.Email);
            sb.AppendLine("Order items: ");
            foreach (OrderItem p in OrderItems) {
                sb.Append(p.Product.Name);
                sb.Append(", $" + p.Price.ToString("F2", CultureInfo.InvariantCulture) + ", ");
                sb.Append("Quantity: " + p.Quantity);
                sb.AppendLine(", Subtotal: $" + p.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
                totalPrice += p.SubTotal();
            }

            sb.AppendLine("Total price: $" + totalPrice.ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}