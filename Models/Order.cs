public class Order
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public int DishId { get; set; }
    public Dish? Dish { get; set; }
}