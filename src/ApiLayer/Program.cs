using ApiLayer.ExceptionHandling;
using ApplicationLayer.Commands.Application;
using ApplicationLayer.Commands.Users;
using ApplicationLayer.Commands.Users.HandlerServices;
using ApplicationLayer.DTO.Visa.Suggestions;
using ApplicationLayer.Requests.Users;
using ApplicationLayer.Requests.Users.HandleServices;
using ApplicationLayer.Services.Jwt;
using DomainLayer.Contracts.Applications;
using DomainLayer.Contracts.Infrastructure;
using DomainLayer.Factory.ApplicationFactory;
using DomainLayer.Factory.UserFactory;
using DomainLayer.Objects.Applications;
using DomainLayer.Objects.Visas;
using InfrastructureLayer.Documents.ApplicationDocuments;
using InfrastructureLayer.Documents.UserDocuments;
using InfrastructureLayer.Mappers.Applications;
using InfrastructureLayer.Mappers.Users;
using InfrastructureLayer.Mappers.Visas;
using InfrastructureLayer.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.Services.Auth.PasswordSecurity;
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
        options.CosmosConnectionString = "AccountEndpoint=https://kierendatabase.documents.azure.com:443/;AccountKey=ttHoEsXeA3NIfsgGSTwKUTBCoQppAstDYDsYoHjXiolsKf3fxeOYr9zJrlxHVTduXjq2YfsW2CgAACDbyZMi7Q==;";

        // Configure the "User" container
        options.ContainerBuilder.Configure<UserDocument>(containerOptions =>
        {
            containerOptions.WithContainer("Users");
            containerOptions.WithPartitionKey("/partitionKey");
        });
        options.ContainerBuilder.Configure<VisaDocument>(containerOptions =>
        {
            containerOptions.WithContainer("Visa");
            containerOptions.WithPartitionKey("/partitionKey");
        });
        options.ContainerBuilder.Configure<ApplicationDocument>(containerOptions =>
        {
            containerOptions.WithContainer("Visa");
            containerOptions.WithPartitionKey("/partitionKey");
        });
        options.IsAutoResourceCreationIfNotExistsEnabled = true;
        options.ContainerPerItemType = true; // builder.Configuration.GetValue<bool>("ContainerPerItemType");
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
    .AddSingleton<IUserFactory, UserFactory>()
    .AddSingleton<IPasswordProtectionService, PasswordProtectionService>()
    .AddSingleton<IJwtGeneration, JwtGeneration>()
    .AddSingleton<ICommandHandler<UserRegistration>, UserRegistrationService>()
    .AddSingleton<ICommandHandler<ApplicationSubmission>, ApplicationSubmissionService>()
    .AddSingleton<IQueryHandler<UserLogin, string>, UserLoginService>()
    .AddSingleton<IQueryHandler<VisaSuggestion, VisaDto>, VisaSuggestionServiceHandler>()
    .AddSingleton<IQueryHandler<GetCountriesVisas, CountryVisaDto>, CountriesVisasServiceHandler>()
    .AddSingleton<IQueryHandler<GetVisa, VisaDto>, VisaServiceHandler>()
    .AddSingleton<IUserMapper, UserMapper>()
    .AddSingleton<IQueryHandler<ApplicationForVisa, IApplication>, ApplicationForVisaServiceHandler>()
    .AddSingleton<IVisaMapper, VisaMapper>()
    .AddSingleton<IApplicationMapper, ApplicationMapper>()
    .AddSingleton<IVisaIntegrationService, VisaIntegrationService>()
    .AddSingleton<IVisaFactory, VisaFactory>()
    .AddSingleton<IExceptionHandler, ExceptionHandler>()
    .AddSingleton<IApplicationFactory, ApplicationFactory>()
    .AddSingleton<IUsersReadRepository, UsersReadRepository>()
    .AddSingleton<IUsersWriteRepository, UsersWriteRepository>();
    


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