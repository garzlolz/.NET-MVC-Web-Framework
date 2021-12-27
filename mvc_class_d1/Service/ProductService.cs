using KSIKernel.Database;
using mvc_class_d1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace mvc_class_d1.Service
{
    public class ProductService
    {
        DBController dbc = new DBController("UseDB");


        //取全部資料
        public List<ProductModel> GetAll()
        {
            List<ProductModel> datalist = new List<ProductModel>();
            string _SQL = "select * from product order by crt_date desc";
            datalist = dbc.FillToList<ProductModel>(_SQL,new System.Collections.Hashtable());
            return datalist;
        }
        

        public List<ProductModel> GetSearch(string product_id)
        {
            Hashtable ht = new Hashtable();
            ht.Add(@"product_id", new StructureSQLParameter(product_id, System.Data.SqlDbType.NVarChar));
            string _SQL = $"select * from Product where product_id like '%{product_id}% order by crt_date desc'";
            List<ProductModel> datalist = dbc.FillToList<ProductModel>(_SQL,ht);
            return datalist;
        }

        public void InsetProduct(ProductCreate data)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@product_id", new StructureSQLParameter(data.product_id, SqlDbType.VarChar));
            ht.Add("@name", new StructureSQLParameter(data.name, SqlDbType.VarChar));
            ht.Add("@unit", new StructureSQLParameter(data.unit, SqlDbType.VarChar));
            ht.Add("@spec", new StructureSQLParameter(data.spec, SqlDbType.VarChar));
            ht.Add("@description", new StructureSQLParameter(data.description, SqlDbType.VarChar));
            ht.Add("@price", new StructureSQLParameter(data.price, SqlDbType.Int));
            string _sql = "insert into PRODUCT (product_id,name,unit,spec,description,price)VALUES(@product_id,@name,@unit,@spec,@description,@price)";

            dbc.DbExecuteNonQuery(_sql, ht);
        }

        public void Delete(string product_id)
        {
            Hashtable ht = new Hashtable();
            ht.Add(@"product_id", new StructureSQLParameter(product_id, System.Data.SqlDbType.NVarChar));
            string _SQL = $"select * from Product where product_id like '%{product_id}% order by crt_date desc'";
            List<ProductModel> datalist = dbc.FillToList<ProductModel>(_SQL, ht);
        }


        public ProductEdit GetOne(string product_id)
        {
            ProductEdit data = new ProductEdit();
            Hashtable ht = new Hashtable();
            ht.Add("@product_id",new StructureSQLParameter(product_id,SqlDbType.NVarChar));
            data = dbc.FillToList<ProductEdit>("select * from PRODUCT where product_id=@product_id", ht)[0];
            DbDataReader reader = dbc.DbExecuteReader("select * from PRODUCT where product_id = @product_id", ht);

            while (reader.Read())
            {
                data.product_id = reader["product_id"].ToString();
                data.name = reader["Name"].ToString();
                data.spec = reader["spec"].ToString();
                data.description = reader["Description"].ToString();
                data.price = Convert.ToInt32(reader["price"]);
            }

            return data;
        }

        public bool UpdateProduct(ProductEdit Model)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@product_id", new StructureSQLParameter(Model.product_id, SqlDbType.NVarChar));
            ht.Add("@name", new StructureSQLParameter(Model.name, SqlDbType.NVarChar));
            ht.Add("@unit", new StructureSQLParameter(Model.unit, SqlDbType.NVarChar));
            ht.Add("@spec", new StructureSQLParameter(Model.spec, SqlDbType.NVarChar));
            ht.Add("@description", new StructureSQLParameter(Model.description, SqlDbType.NVarChar));
            ht.Add("@price", new StructureSQLParameter(Model.price, SqlDbType.Decimal));

            int res = dbc.DbExecuteNonQuery
                ("UPDATE PRODUCT SET name=@name,unit=@unit , " +
                "spec = @spec, " +
                "description = @description, " +
                "price = @price " +
                "where product_id = @product_id",ht);
            if(res>0)
                return true;
            else
                return false;
        }


        public bool DeleteProduct(string product_id)
        {
            Hashtable ht = new Hashtable();
            ht.Add("@product_id",new StructureSQLParameter(product_id,SqlDbType.NVarChar));
            int res = dbc.DbExecuteNonQuery("DELETE PRODUCT WHERE product_id = @product_id",ht);
            
            if(res>0)
                return true;
            else
                return false;
        }
    }
}