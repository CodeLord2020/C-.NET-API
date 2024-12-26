namespace MyFirstApi.Models;


public class Post 
{
    public int Id { get; set;}
    public int UserId { get; set;}
    public string Title { get; set;} = string.Empty;
    public string Body { get; set;} = string.Empty ;
    public DateTime CreatedDate { get; set;}
    
}
