using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyfirstCoreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyfirstCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class RightsController : MyBaseController
    {
        [HttpGet("{type}")]
        public IActionResult GetAllRights(string type)
        {

            RightModel rightModel = new RightModel();

            rightModel.data = new List<RightDetail>
            {
                new RightDetail
                {
                     id= 101,
                     authName="商品管理",
                     level="0",
                      pid= 0,
                      path="order",
                },
                new RightDetail
                {
                     id= 102,
                     authName="订单管理",
                     level="0",
                      pid= 0,
                       path="goods",
                },
                new RightDetail
                {
                     id= 103,
                     authName="用户管理",
                     level="0",
                      pid= 0,
                       path="orders",
                }
            };
            rightModel.meta.msg = "获取权限列表成功";
            rightModel.meta.status = 200;

            return Ok(rightModel);
        }
       
    }
}
