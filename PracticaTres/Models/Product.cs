using PracticaTres.Data;
namespace PracticaTres.Models{

 public class Product{

    public int? Id {get;set;}
    public string? Name {get;set;}

    public string? Description {get;set;}

    public DateTime? ExpirationDate {get;set;}

    public double? Price {get;set;}
    public int? Amount {get;set;}

    public int? UserId {get;set;}


    


 } 

}