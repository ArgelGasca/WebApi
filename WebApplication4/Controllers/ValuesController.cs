using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.OleDb;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            string[] str;
            string strAccessConn = "Provider=VFPOLEDB.1;Data Source=C:\\Users\\Argel\\Documents\\Visual FoxPro Projects";
            string strAccessSelect = "SELECT * FROM sv_artic";
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            myAccessConn = new OleDbConnection(strAccessConn);
            OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
            OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

            myAccessConn.Open();
            myDataAdapter.Fill(myDataSet, "sv_artic");
            myAccessConn.Close();
            int largo = myDataSet.Tables["sv_artic"].Rows.Count;
            int ancho = myDataSet.Tables["sv_artic"].Columns.Count;
            int i = 0;
            int j = 0;
            str = new string[largo];
            foreach(DataRow dr in myDataSet.Tables["sv_artic"].Rows)
            {
                    str[i] = myDataSet.Tables["sv_artic"].Rows[i][0].ToString().Trim();
                    i++;    
            }

            return str;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/values
        [HttpPost]
        public string Post([FromBody]string value)
        {

            return value;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
