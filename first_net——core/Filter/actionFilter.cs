using DTO.Implement;
using DTO.Interface;
using DTO.single;
using first_net__core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace first_net__core.Filter
{
    public class actionFilter: IActionFilter
    {
        private readonly ConcurrentDictionary<string, string> _concurrentDictionary;
        private readonly IMath _iMath_gouzao;
        private readonly MySingle _mySingle;
        public actionFilter(IMath iMath_gouzao, MySingle mySingle)//貌似没法吧泛型传过来
        {
            _concurrentDictionary = new ConcurrentDictionary<string, string>();
            _iMath_gouzao = iMath_gouzao;
            _mySingle = mySingle;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //过滤器中使用依赖注入
            //直接拿
            IMath my_IMAth= (IMath)context.HttpContext.RequestServices.GetService(typeof(IMath));
            int re1 = my_IMAth.sum(4, 5);
           
            //构造函数注入
             int re2= _iMath_gouzao.sum(70, 80);

            //获取单例类
            string getSingle = _mySingle.reStr.GetHashCode().ToString();

        }
    }
}
