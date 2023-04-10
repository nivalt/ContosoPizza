namespace ContosoPizza.Models;

public enum PizzaSize
{
    Small,
    Medium,
    Large
}
[Flags]
public enum Topping
{
    None = 0,
    Pepperoni = 1,
    Onion = 2,
    Mushrooms = 4,
    Olives = 8,
    Pineapple = 16,
    Bacon= 32,
    All =   Pepperoni | Onion | Mushrooms | Olives | Pineapple | Bacon
}

public class Pizza
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool? IsGlutenFree { get; set; }
    public PizzaSize? Size { get; set; }
    public Topping? Toppings { get; set; }
}