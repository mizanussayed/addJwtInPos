using System.Text;
using FastReport.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using POSSolution.Application;
using POSSolution.Core.Models;
using POSSolution.Infrastructure;
using POSSolution.Infrastructure.ModelRepository;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("posPolicy", policy =>
policy.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()));

builder.Services.AddScoped<IRepository<Country>, Repository<Country>>();

builder.Services.AddDbContext<POSContext>(options => 
  options.UseSqlServer(builder.Configuration.GetConnectionString("PosSolutionConnection")));
  
builder.Services.AddIdentity<IdentityUser, IdentityRole>(ob=>
 {
    ob.Password.RequireDigit = false;
    ob.Password.RequireLowercase = false;
    ob.Password.RequireNonAlphanumeric = false;
    ob.User.RequireUniqueEmail = true;

}
).AddEntityFrameworkStores<POSContext>().AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer =builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "POSSolution.API", Version = "v1" });
});


FastReport.Utils.RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

var app = builder.Build();


if(app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "POSSolution.API v1"));
}
//app.UseCors(ob => ob.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
app.UseStaticFiles();
app.UseCors("posPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastReport();
app.UseEndpoints(endpoints =>
{
  endpoints.MapControllers();
});
app.Run();
