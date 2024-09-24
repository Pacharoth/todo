using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using tracer_backend;
using tracer_backend.AutoMapper;
using tracer_backend.Repositories;
using tracer_backend.Services;
using tracer_backend.Utilities;
var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    // c.OperationFilter<SecurityRequirementsOperationFilter>();
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});
builder.Services.AddControllers();
builder.Services.AddScoped<DataContextDapper>();

//Add scope for ITaskService, T
builder.Services.AddScoped<ITaskService,TaskService>();
// Add scope for ITaskRepository
builder.Services.AddScoped<ITaskRepository,TaskRepository>();
// Add Scope for JWT
builder.Services.AddAuthentication(cfg=>{
    cfg.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    cfg.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
#pragma warning disable CS8604 // Possible null reference argument.
    x.TokenValidationParameters = new TokenValidationParameters {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8
            .GetBytes(builder.Configuration["ApplicationSettings:JWT_Secret"])
        ),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
#pragma warning restore CS8604 // Possible null reference argument.
});
var MyAllowSpecificOriginsDev = "DevCors";
builder.Services.AddCors(options=>{
    // Cors to allow frontend dev to access the api
    options.AddPolicy(MyAllowSpecificOriginsDev,(corsBuilder)=>{
        corsBuilder
        .AllowAnyOrigin()
        .AllowAnyHeader().AllowAnyMethod();
    });
    // Cors to allow product dev to access the 
    options.AddPolicy("ProdCors",(corsBuilder)=>{
        // corsBuilder.WithOrigins("https://")
        corsBuilder.WithOrigins("http://localhost:5173/")
        .AllowAnyOrigin()
        .AllowAnyHeader().AllowAnyMethod();
        // .AllowCredentials();
    });
});

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(MyAllowSpecificOriginsDev);

    app.UseDeveloperExceptionPage();
}else{
    app.UseHttpsRedirection();
}

app.MapControllers();
app.UseAuthorization();
app.Run();


