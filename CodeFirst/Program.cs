using ClaimManagement.DAL.Entity;
using ClaimManagement.DAL.Repository;
using ClaimManagement.BLL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Description = "Insert JWT Token",
    Name = "Authorization",
    In = ParameterLocation.Header,
    Type = SecuritySchemeType.Http,
    Scheme = "bearer",
    BearerFormat = "JWT",
}));
// Add a security requirement to apply the "Bearer" scheme to all endpoints
builder.Services.AddSwaggerGen(w => w.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {
         new OpenApiSecurityScheme
         {
             Reference = new OpenApiReference
             {
                 Type = ReferenceType.SecurityScheme,
                 Id = "Bearer",
             }
         },
         new string[]{}
     }
 }));

//builder.Services.AddSwaggerGen();

var provider=builder.Services.BuildServiceProvider();
var config=provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<MyDbContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services.AddTransient<ISurveyorRepository, MySurveyorRepository>();
builder.Services.AddTransient<IClaimDetailsRepository, MyClaimDetailsRepository>();
builder.Services.AddTransient<IClaimDetailsService,MyClaimDetailsService>();
builder.Services.AddTransient<IPolicyService, MyPolicyService>();
builder.Services.AddTransient<ISurveyorService, MySurveyorService>();
builder.Services.AddTransient<IPolicyRepository, MyPolicyRepository>();
builder.Services.AddTransient<IPendingStatusReportRepository, MyPendingStatusReportRepository>();
builder.Services.AddTransient<IPendingStatusReportService, MyPendingStatusReportService>();
builder.Services.AddTransient<IPaymentOfClaimsRepository, MyPaymentOfClaimsRepository>();
builder.Services.AddTransient<IPaymentOfClaimService, MyPaymentOfClaimService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
