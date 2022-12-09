using LocalGoods.DAL.Interfaces;
using LocalGoods.DAL.Operations;
using LocalGoods.DAL.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using LocalGoods.BAL.Services.Interfaces;
using LocalGoods.BAL.Services.Implementation;
using LocalGoods.DAL.Repositories;
using System.Text.Json.Serialization;
using LocalGoods.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                      });
});

// Add services to the container.
builder.Services.AddDbContext<LocalGoodsDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var tokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:Secret"])),

    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"],

    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:Audience"],

    ValidateLifetime = true,
    ClockSkew = TimeSpan.Zero
};

builder.Services.AddSingleton(tokenValidationParameters);

//Add Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<LocalGoodsDbContext>()
    .AddDefaultTokenProviders();

//Add Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    //Add jwt bearer
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = tokenValidationParameters;
    });



//Added Scoped
builder.Services.AddScoped<IFarmRepository, FarmRepository>();
builder.Services.AddScoped<IFarmService, FarmService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();  
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IQuantityTypeRepository, QuantityTypeRepository>();
builder.Services.AddScoped<IQuantityTypeService, QuantityTypeService>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler= ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( optons => 
{
    optons.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();   
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();


//Seed the Database

AppDbInitializer.SeedRolesToDb(app).Wait();
AppDbInitializer.SeedQuantityTypesToDb(app).Wait();
AppDbInitializer.SeedCategoriesToDb(app).Wait();

app.MapControllers();

app.Run();
