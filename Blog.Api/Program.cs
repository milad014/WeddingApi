using Blog.Aplication.Implement;
using Blog.Aplication.Interfaces;
using Blog.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// EF Core DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

// Register services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<PostService>();
builder.Services.AddScoped<CommentService>();

// Add controllers
builder.Services.AddControllers();

// ✅ OpenAPI/Swagger (.NET 9)
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // swagger-ui در /openapi.json و /swagger مسیر دهی می‌شود
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
