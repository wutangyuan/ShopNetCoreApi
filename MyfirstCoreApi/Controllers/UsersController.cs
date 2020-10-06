using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MyfirstCoreApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyfirstCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : MyBaseController
    {
        static IList<User> CurrentUser = new List<User>();

        static UsersController()
        {
          
            var users = new List<User>
                {
                     new User
                     {
                           id=25,
                username= "admin",
                mobile= "18616358651",
                type=1,
                email= "tige112@163.com",
                create_time="2017-11-09T20:36:26.000Z",
                mg_state= true, // 当前用户的状态
                role_name= "炒鸡管理员"
                     },
                      new User
                     {
                           id=26,
                username= "wuty",
                mobile= "18616358651",
                type=1,
                email= "tige112@163.com",
                create_time="2017-11-09T20:36:26.000Z",
                mg_state= false, // 当前用户的状态
                role_name= "炒鸡管理员"
                     },
                       new User
                     {
                           id=27,
                username= "wuty123",
                mobile= "18616358651",
                type=1,
                email= "tige112@163.com",
                create_time="2017-11-09T20:36:26.000Z",
                mg_state= false, // 当前用户的状态
                role_name= "炒鸡管理员"
                     }


                };
            CurrentUser = users;

        }


        [HttpGet]
       public IActionResult Users(string query,int pagenum, int pagesize)
        {
            try
            {

                UserModel userModel = new UserModel();
                userModel.meta = new Meta();
                userModel.meta.msg = "获取成功";
                userModel.meta.status = 200;

                userModel.pagenum = pagenum;
               

                if (!string.IsNullOrWhiteSpace(query))
                {
                    var models = CurrentUser.Where(x => x.username.Contains(query) || x.email.Contains(query)).ToList();
                    userModel.users = models;
                }
                else
                {
                    userModel.users = CurrentUser;
                }
                userModel.totalpage = userModel.users.Count();
                return Ok(userModel);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{users}/state/{state}")]
        public IActionResult Put(int users, bool state)
        {
            
            if (CurrentUser!=null && CurrentUser.Count()>0)
            {
                var userinfo = CurrentUser.FirstOrDefault(x => x.id == users);
                userinfo.mg_state = state;

                UserInfo userInfo = new UserInfo();
                userInfo.data = userinfo;
                userInfo.meta.msg = "设置状态成功";
                userInfo.meta.status = 200;
                return Ok(userInfo);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserById(int id, [FromBody] UserResuest userResuest)
        {

            if (CurrentUser != null && CurrentUser.Count() > 0)
            {
                var userinfo = CurrentUser.FirstOrDefault(x => x.id == id);
                userinfo.email = userResuest.email;
                userinfo.mobile = userResuest.mobile;

                UserInfo userInfo = new UserInfo();
                userInfo.data = userinfo;
                userInfo.meta.msg = "修改用户成功";
                userInfo.meta.status = 200;
                return Ok(userInfo);
            }

            return BadRequest();
        }


        [HttpDelete("{id}")]
        public IActionResult DeletUserById(int id)
        {

            if (CurrentUser != null && CurrentUser.Count() > 0)
            {
                var userinfo = CurrentUser.FirstOrDefault(x => x.id == id);
                try
                {
                    CurrentUser.Remove(userinfo);
                }
                catch (Exception)
                {
                    return BadRequest();
                }

                UserInfo userInfo = new UserInfo();
                userInfo.data = null;
                userInfo.meta.msg = "删除用户成功";
                userInfo.meta.status = 200;
                return Ok(userInfo);
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserBase user)
        {

            var maxId = CurrentUser.Max(x => x.id)+1;

            User usermodel = new User();
            usermodel.id = maxId;
            usermodel.email = user.email;
            usermodel.mobile = user.mobile;
            usermodel.username = user.username;
            usermodel.rid = 3;
            usermodel.role_name = "普通用户";
            usermodel.create_time = DateTime.Now.ToString();
            usermodel.type = 1;
            usermodel.mg_state = true;

            UserInfo userInfo = new UserInfo();
            userInfo.data = usermodel;
            userInfo.meta.msg = "用户创建成功";
            userInfo.meta.status = 200;

            try
            {
                CurrentUser.Add(usermodel);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(userInfo);
        }
        
    }
}
