using ApplicationLayer.Commands.Users;
using ApplicationLayer.Commands.Users.HandlerServices;
using ApplicationLayer.Requests.Users;
using ApplicationLayer.Requests.Users.HandleServices;
using DomainLayer.Contracts.Applications;
using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Factory.UserFactory;
using InfrastructureLayer.Documents.UserDocuments;
using InfrastructureLayer.Mappers.Users;
using InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.Services.Commands.Abstract;
using Shared.Services.Queries.Abstract;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please provide tocken",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<String>()
        }
    });

});
const string container = "Users";
const string partitionKey = "/partitionKey";
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddMvc();

builder.Services
    .AddCosmosRepository(options =>
    {
        options.DatabaseId = "NoSqlDatabase";
        options.CosmosConnectionString = "AccountEndpoint=https://kierendatabase.documents.azure.com:443/;AccountKey=ttHoEsXeA3NIfsgGSTwKUTBCoQppAstDYDsYoHjXiolsKf3fxeOYr9zJrlxHVTduXjq2YfsW2CgAACDbyZMi7Q==";
        options.ContainerId = container;
        options.ContainerBuilder.Configure<UserDocument>(containerOptions =>
        {
            containerOptions.WithPartitionKey(partitionKey);
        });
        options.IsAutoResourceCreationIfNotExistsEnabled = true;
        options.ContainerPerItemType = builder.Configuration.GetValue<bool>("ContainerPerItemType");
    });


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                        RoleClaimType = ClaimTypes.Role
                    };
                });
builder.Services.AddControllers();
builder.Services
    .AddSingleton<IPasswordService, PasswordProtectionService>()
    .AddSingleton<IUserFactory, UserFactory>()
    .AddSingleton<ICommandHandler<UserRegistration>, UserRegistrationService>()
    .AddSingleton<IQueryHandler<UserLogin, string>, UserLoginService>()
     .AddSingleton<IUserMapper, UserMapper>()
    .AddSingleton<IUsersRepository, UsersRepository>();
    


var app = builder.Build();

// Configure the HTTP request pipeline.
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