namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orderSystem = new OrderSystem();
            var orderHandler = new OrderHandler();

            orderSystem.OrderPlaced += orderHandler.OnOrderPlaced;

            orderSystem.PlaceOrder(12345);
        }
    }

    
    public class OrderEventArgs : EventArgs
    {
        public int OrderId { get; set; }

        public OrderEventArgs(int orderId)
        {
            OrderId = orderId;
        }
    }

   
    public delegate void OrderPlacedEventHandler(object sender, OrderEventArgs e);

    
    public class OrderSystem
    {
        
        public event OrderPlacedEventHandler OrderPlaced;

       
        public void PlaceOrder(int orderId)
        {
           
            OnOrderPlaced(new OrderEventArgs(orderId));
        }

        
        protected virtual void OnOrderPlaced(OrderEventArgs e)
        {
            
            OrderPlaced?.Invoke(this, e);
        }
    }

    
    public class OrderHandler
    {
        public void OnOrderPlaced(object sender, OrderEventArgs e)
        {
            Console.WriteLine($"Order with ID {e.OrderId} has been placed.");
        }
    }

}
