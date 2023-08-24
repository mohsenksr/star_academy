using System;
using System.Linq;
using Models;
using System.Text.Json;



using var db = new BloggingContext();


db.Blogs.RemoveRange(db.Blogs);
db.SaveChanges();
// Write

IList<Blog> blogs = new List<Blog>() {
    new Blog() {Url = "aaa"},
    new Blog() {Url = "bbb"},
    new Blog() {Url = "ccc"},
    new Blog() {Url = "ddd"},
};

db.AddRange(blogs);
db.SaveChanges();

Console.WriteLine( JsonSerializer.Serialize(blogs));


// Read
var blog = db.Blogs.Single(b => b.Url == "ccc");
var allBlogs = db.Blogs;

Console.WriteLine( JsonSerializer.Serialize(allBlogs));

var data = from db_blog in db.Blogs
    where db_blog.Url != "ccc"
    orderby db_blog.BlogId descending
    select db_blog;

foreach (var selected_blog in data)
{
    Console.Write(selected_blog.BlogId + " ");
}

// Update
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello", Content = "Mello!" });
db.SaveChanges();

// Delete

db.Remove(blog);
db.SaveChanges();