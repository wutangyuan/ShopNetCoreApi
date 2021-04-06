using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyfirstCoreApi.IServices;
using MyfirstCoreApi.Models;
using MyfirstCoreApi.Services;
using Shop.EF.Core;
using Swashbuckle.AspNetCore.Filters;

namespace MyfirstCoreApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //配置跨域问题
            services.AddCors(o => o.AddPolicy("any", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


            //添加jwt配置服务
            //注册获取配置
            services.Configure<JwtTokenManagerMent>(Configuration.GetSection("JwtTokenManagerMent"));
            var token = Configuration.GetSection("JwtTokenManagerMent").Get<JwtTokenManagerMent>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey=true,  //是否验证SecurityKey
                    IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret)),
                    ValidIssuer=token.Issuer,
                    ValidAudience=token.Audience,
                    ValidateIssuer=true,  ////是否验证Issuer 
                    ValidateAudience = true,  //是否验证Audience
                    ValidateLifetime=true, //是否验证失效时间
                    ClockSkew=TimeSpan.Zero, //设置时间的偏移量，默认为300s
                };
            });

            //注入服务，以便控制器在构造函数中可以获取到对应的服务
            services.AddTransient<IAuthenticateService, TokenAuthenticationService>();

            //增加swagger接口文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Email = "ty635725964@qq.com",
                        Name = "MyfirstApi",
                        //Url = ""
                    },
                    Description = "Api文档",
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Api许可证"
                    },
                    Title = "MyfirstApi",
                    Version="V1"
                }) ;

                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                c.OperationFilter<SecurityRequirementsOperationFilter>();

                c.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Description= "JWT授权(数据将在请求头中进行传递)直接在下面框中输入Bearer {token}(注意两者之间是一个空格) \"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });

            });

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseCors("any");
            app.UseRouting();

            app.UseAuthorization();


           
            //使用跨域
            app.UseCors();  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //使用swagger,需要引用swaggerui的包
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","MyFirstApix");
                c.RoutePrefix = "api"; //启动直接域名/api
            });


        }
    }
}
