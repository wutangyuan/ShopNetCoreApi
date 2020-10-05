using System;
using System.Collections.Generic;

namespace MyfirstCoreApi.Models
{
    public class ShopModel
    {
        public ShopModel() { }

        public Data data { get; set; } = new Data();

        public Meta meta { get; set; } = new Meta();

    }

    public class Data
    {
        public int id { get; set; }

        public int rid { get; set; } = 0;
        public string username { get; set; }
        public string mobile { get; set; } = "123";
        public string email { get; set; } = "123@qq.com";
        public string token { get; set; }

    }

    public class Meta
    {
        public string msg { get; set; }

        public int status { get; set; }

        /*

        | *状态码* | *含义*                | *说明*                                              |
| -------- | --------------------- | --------------------------------------------------- |
| 200      | OK                    | 请求成功                                            |
| 201      | CREATED               | 创建成功                                            |
| 204      | DELETED               | 删除成功                                            |
| 400      | BAD REQUEST           | 请求的地址不存在或者包含不支持的参数                |
| 401      | UNAUTHORIZED          | 未授权                                              |
| 403      | FORBIDDEN             | 被禁止访问                                          |
| 404      | NOT FOUND             | 请求的资源不存在                                    |
| 422      | Unprocesable entity   | [POST/PUT/PATCH] 当创建一个对象时，发生一个验证错误 |
| 500      | INTERNAL SERVER ERROR | 内部错误                                            |
|          |                       |                                                     |
*/
    }

    public class menudetail
    {
        public int id { get; set; }

        public string authName { get; set; }

        public string path { get; set; } = null;

        public List<menudetail> children { get; set; }
    }

    public class menu
    {
        public List<menudetail> data { get; set; } = new List<menudetail>();

        public Meta meta { get; set; } = new Meta();
    }
}
