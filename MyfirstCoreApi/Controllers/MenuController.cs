using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyfirstCoreApi.IServices;
using MyfirstCoreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyfirstCoreApi.Controllers
{
    [ApiController]
    [EnableCors("any")]
    [Route("api/[controller]")]
    [Authorize]
    public class MenuController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public MenuController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }


        [HttpGet]
        public IActionResult Menu()
        {
            menu menu = new menu();
            menu.data = new List<menudetail>
            {
                new menudetail
                {
                    id = 101,
                   authName = "用户管理",
                   children = new List<menudetail>
                 {
                     new menudetail
                     {
                       id = 102,
                       authName = "用户列表",
                       path="users"
                     },    
                 }
               } ,
                new menudetail
                {
                    id = 105,
                   authName = "权限管理",
                   children = new List<menudetail>
                 {
                     new menudetail
                     {
                       id = 106,
                       authName = "角色列表",
                       path="roles"
                     },
                       new menudetail
                     {
                       id = 107,
                       authName = "权限列表",
                       path="rights"
                     },
                 }
               },
                new menudetail
                {
                    id = 109,
                   authName = "商品管理",
                   children = new List<menudetail>
                 {
                     new menudetail
                     {
                       id = 110,
                       authName = "商品列表",
                       path="user"
                     },
                       new menudetail
                     {
                       id = 111,
                       authName = "商品列表",
                       path="user"
                     },
                         new menudetail
                     {
                       id = 112,
                       authName = "商品列表",
                       path="user"
                     },

                 }
               },
                new menudetail
                {
                    id = 113,
                   authName = "订单管理",
                   children = new List<menudetail>
                 {
                     new menudetail
                     {
                       id = 114,
                       authName = "商品列表",
                       path="user"
                     },
                       new menudetail
                     {
                       id = 115,
                       authName = "商品列表",
                       path="user"
                     },
                         new menudetail
                     {
                       id = 116,
                       authName = "商品列表",
                       path="user"
                     },

                 }
               },
                 new menudetail
                {
                    id = 117,
                   authName = "数据统计管理",
                   children = new List<menudetail>
                 {
                     new menudetail
                     {
                       id = 118,
                       authName = "商品列表",
                       path="user"
                     },
                       new menudetail
                     {
                       id = 119,
                       authName = "商品列表",
                       path="user"
                     },
                         new menudetail
                     {
                       id = 120,
                       authName = "商品列表",
                       path="user"
                     },

                 }
                 }
           };
            menu.meta.msg = "获取菜单列表成功";
            menu.meta.status = 200;
            return Ok(menu);
        }
    }
}
