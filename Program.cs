using System.Text;
using Inventory_final_task_.Brokers.DateTimes;
using Inventory_final_task_.Brokers.Loggings;
using Inventory_final_task_.Brokers.Security;
using Inventory_final_task_.Brokers.Storages;
using Inventory_final_task_.Services.Foundations.AccessEntries;
using Inventory_final_task_.Services.Foundations.Comments;
using Inventory_final_task_.Services.Foundations.FieldConfigurations;
using Inventory_final_task_.Services.Foundations.Emails;
using Inventory_final_task_.Services.Foundations.IdElements;
using Inventory_final_task_.Services.Foundations.Inventories;
using Inventory_final_task_.Services.Foundations.InventoryTags;
using Inventory_final_task_.Services.Foundations.Items;
using Inventory_final_task_.Services.Foundations.Likes;
using Inventory_final_task_.Services.Foundations.Security;
using Inventory_final_task_.Services.Foundations.Tags;
using Inventory_final_task_.Services.Foundations.Users;
using Inventory_final_task_.Services.Orchestrations.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Inventory_final_task_.Brokers.Emails;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// Database
builder.Services.AddDbContext<StorageBroker>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Brokers
builder.Services.AddScoped<IStorageBroker, StorageBroker>();
builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
builder.Services.AddScoped<IHashBroker, HashBroker>();
builder.Services.AddScoped<IRandomBroker, RandomBroker>();
builder.Services.AddScoped<IEmailBroker, EmailBroker>();

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
builder.Services.AddScoped<IAccessEntryService, AccessEntryService>();
builder.Services.AddScoped<IPasswordHashService, PasswordHashService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!))
        };
    });

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
