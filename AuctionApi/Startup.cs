using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using AuctionApi.Models;
using AuctionApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AuctionApi
{
  public class Startup
  {
    readonly string MyAllowAnyOrigin = "_myAllowAnyOrigin";

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // requires using Microsoft.Extensions.Options
      services.Configure<AuctionDatabaseSettings>(
          Configuration.GetSection(nameof(AuctionDatabaseSettings)));

      services.AddSingleton<IAuctionDatabaseSettings>(sp =>
          sp.GetRequiredService<IOptions<AuctionDatabaseSettings>>().Value);

      services.AddSingleton<UserService>();
      services.AddSingleton<ListingService>();

      services.AddControllers();
      DotNetEnv.Env.Load();

      services.AddCors(options =>
      {
        options.AddPolicy(name: MyAllowAnyOrigin,
                  builder =>
                  {
                    builder.AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                  });
      });

      var tokenKey = Encoding.ASCII.GetBytes(System.Environment.GetEnvironmentVariable("TOKEN_KEY"));
      var tokenIssuer = System.Environment.GetEnvironmentVariable("TOKEN_ISSUER");
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(token =>
      {
        token.RequireHttpsMetadata = false;
        token.SaveToken = true;
        token.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
          ValidateLifetime = true,
          ValidateIssuer = true,
          ValidIssuer = tokenIssuer,
          ValidateAudience = false
        };
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseCors(MyAllowAnyOrigin);


      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
