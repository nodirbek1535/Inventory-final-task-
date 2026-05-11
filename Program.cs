using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Services.Foundations.FieldConfigurations;
using Inventory_final_task_.Services.Foundations.Comments;
using Inventory_final_task_.Services.Foundations.IdElements;
using Inventory_final_task_.Services.Foundations.Inventories;
using Inventory_final_task_.Services.Foundations.InventoryTags;
using Inventory_final_task_.Services.Foundations.Items;
using Inventory_final_task_.Services.Foundations.Likes;
using Inventory_final_task_.Services.Foundations.Tags;
using Inventory_final_task_.Services.Foundations.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<StorageBroker>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStorageBroker, StorageBroker>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IFieldConfigurationService, FieldConfigurationService>();
builder.Services.AddScoped<IIdElementService, IdElementService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IInventoryTagService, InventoryTagService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ILikeService, LikeService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
