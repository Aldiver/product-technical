using System.ComponentModel.DataAnnotations;

namespace add_cart_exam.Server;

public class Products{
    [Key]
    public int ProductId {get; set;}
    public string ProductName {get; set;} = null!;
    public int Cost {get; set;}
    public int Quantity {get; set;}
    public int Amount {get; set;}
}