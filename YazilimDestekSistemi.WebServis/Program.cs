
using NLog.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using YazilimDestekSistemi.WebServis.Common.Helpers;
using YazilimDestekSistemi.WebServis.Services.Interfaces;
using YazilimDestekSistemi.WebServis.Services.Implementations;

namespace YazilimDestekSistemi.WebServis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();

            // Add services to the container.
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("AllowAll", policy =>
                    {
                        policy.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
                });

                builder.Services.AddHealthChecks();

                builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();

            // Encryption settings and crypto service
                builder.Services.Configure<EncryptionSettings>(builder.Configuration.GetSection("EncryptionSettings"));
                builder.Services.AddScoped<IAesHmacService, AesHmacService>();

            // Authentication (JWT)
                builder.Services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    var secretKey = builder.Configuration["Jwt:SecretKey"];
                    if (string.IsNullOrWhiteSpace(secretKey))
                        throw new ArgumentNullException("Jwt:SecretKey yapılandırması eksik veya boş.");

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });

            // Swagger with JWT security
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "YDS API",
                        Version = "v1",
                        Description = "Yazılım Destek Sistemi için API Dokümantasyonu"
                    });

                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
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
                            Array.Empty<string>()
                        }
                    });
                });

                var app = builder.Build();

            // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseCors("AllowAll");

                app.UseAuthentication();

                app.UseAuthorization();


                app.MapControllers();
                app.MapHealthChecks("/health");

                app.Run();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Host terminated unexpectedly");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
