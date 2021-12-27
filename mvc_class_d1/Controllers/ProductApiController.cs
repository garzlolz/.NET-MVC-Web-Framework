using mvc_class_d1.Models;
using mvc_class_d1.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvc_class_d1.Controllers
{
    public class ProductApiController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult Post(ProductCreate data)
        {
            Dictionary<string, object> I_res = new Dictionary<string, object>();
            ProductService _service = new ProductService();         
            _service.InsetProduct(data);
            return Ok();
        }

        [HttpPut]  
        public IHttpActionResult Put(ProductEdit data)
        {
            Dictionary<string,object> I_res = new Dictionary<string,object>();
            ProductService _service = new ProductService();
            bool isSuccess = false;
            isSuccess = _service.UpdateProduct(data);
            
            try
            {
                if (isSuccess)
                {
                    I_res.Add("StatusCode", 200);
                    I_res.Add("Message", "修改成功");
                }
                else
                {
                    I_res.Add("StatusCode", 400);
                    I_res.Add("Message", "修改失敗");
                }          
            }
            catch (Exception ex)
            {
                I_res.Add("StatusCode", 500);
                I_res.Add("Message", ex.Message);
            }
            return Ok<Dictionary<string, object>>(I_res);
        }

        
        [HttpDelete]
        public IHttpActionResult Delete(string product_id)
        {     
            
            Dictionary<string, object> I_res = new Dictionary<string, object>();
            ProductService _service = new ProductService();
            bool isSuccess =  _service.DeleteProduct(product_id);
            try
            {
                if (isSuccess)
                {
                    I_res.Add("StatusCode", 200);
                    I_res.Add("Message", "已刪除");
                }
                else
                {
                    I_res.Add("StatusCode", 400);
                    I_res.Add("Message", "刪除失敗");
                }
            }
            catch (Exception ex)
            {
                I_res.Add("StatusCode", 500);
                I_res.Add("Message", ex.Message);
            }
            return Ok<Dictionary<string, object>>(I_res);
        }
    }
}
