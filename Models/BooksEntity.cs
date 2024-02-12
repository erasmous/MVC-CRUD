namespace MVC_CRUD.Models;


public class BooksEntity 
{
    public int Id { get; set; }
    public required string Title { get; set; }

    public required string Author { get; set; }

    public required string ISBN { get; set; }

}