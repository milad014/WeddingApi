
using Blog.Aplication.Interfaces;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Database Connection (EF Core 9)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 🔹 Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

//// 🔹 Register Services (Application Layer)
//builder.Services.AddScoped<UserService>();
//builder.Services.AddScoped<PostService>();
//builder.Services.AddScoped<CommentService>();

// 🔹 Add Controllers
builder.Services.AddControllers();

// 🔹 Swagger / OpenAPI
builder.Services.AddOpenApi(); // در .NET 9 می‌تونی از این استفاده کنی به جای AddSwaggerGen()

var app = builder.Build();

// 🔹 Middleware
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // .NET 9 way
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
