using System.Collections.Generic;
using MVC_Thehegeo.Models.BlogModels;

public interface IBlogRepository
{
    IEnumerable<Post> GetList();
}