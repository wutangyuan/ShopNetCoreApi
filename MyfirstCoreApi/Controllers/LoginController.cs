using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyfirstCoreApi.IServices;
using MyfirstCoreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyfirstCoreApi.Controllers
{
    [EnableCors("any")]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        const string UserName = "admin";
        const string PassWord = "123456";
        private readonly IAuthenticateService _authenticateService;
        public LoginController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            ShopModel shopModel = new ShopModel();
            if (loginModel == null || loginModel.PassWord != PassWord || loginModel.UserName != UserName)
            {
                shopModel.data = null;

                shopModel.meta.msg = "登陆失败";
                shopModel.meta.status = 404;
                return BadRequest(shopModel);
            }
            else
            {
                var token = string.Empty;
                if (_authenticateService.IsAuthenticated(out token))
                {
                    shopModel.data.id = 200;
                    shopModel.data.username = loginModel.UserName;
                    shopModel.data.token = "Bearer " + token;
                    shopModel.meta.msg = "登陆成功";
                    shopModel.meta.status = 200;
                    return Ok(shopModel);
                }

            }
            return BadRequest();
        }
    }
}
