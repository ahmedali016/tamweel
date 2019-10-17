using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using noteLogic.ViewModel;
using noteLogic;
using System.Web;

namespace ang.Api2Controller
{
    public class ClientsController : ApiController
    {
        clients c = new clients();

        public IEnumerable<clientView> GetClients()
        {
            var list = c.displayClient();
            return list;
        }

        public clientView GetClient(int id)
        {
            var list = c.displayClientById(id);
            return list;
        }

        public int PostClient()
        {
            var fullname = HttpContext.Current.Request.Params["name"];
            var birth = HttpContext.Current.Request.Params["birth"];
            var mail = HttpContext.Current.Request.Params["mail"];
            var depart = HttpContext.Current.Request.Params["department"];
            var job = HttpContext.Current.Request.Params["job"];
            var pass = HttpContext.Current.Request.Params["pass"];
            var phones = HttpContext.Current.Request.Params["phones"];
            var p = phones.Split('"');
            List<phone> nphone = new List<phone>();
            foreach (var itm in p)
            {
                if (itm.Length > 1)
                {
                    nphone.Add(new phone { phones = itm });
                }
            }
            var addresses = HttpContext.Current.Request.Params["addresses"];
            var a= addresses.Split('"');
            List<address> naddress = new List<address>();
            foreach (var item in a)
            {
                if (item.Length > 1)
                {
                    naddress.Add(new address { addres = item });
                }
            }
            string imgName = "";
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var img = HttpContext.Current.Request.Files[0];
                imgName = HttpContext.Current.Server.MapPath("..\\images")+"\\" + img.FileName;
               
                img.SaveAs(imgName);
            }
            DateTime birthdate = DateTime.Parse(birth);
            int age = 0;
            age = DateTime.Now.Year - birthdate.Year;
            if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
                age = age - 1;

            clientView v = new clientView();
            v.birthdate = birth;
            v.clientName = fullname;
            v.departmentId = int.Parse(depart);
            v.job = int.Parse(job);
            v.age = age;
            v.mail = mail;
            v.photo = imgName;
            v.password = pass;
            v.clientPhone = nphone;
            v.clientAddress = naddress;
            var result=c.AddClient(v);
            return result;
        }

        
       
        public IEnumerable<clientView> DeleteClient(int id)
        {
            var result = c.DeleteClient(id);
            var list = c.displayClient();
            return list;
        }

        public bool PutClient()
        {
            var id = HttpContext.Current.Request.Params["id"];
            var fullname = HttpContext.Current.Request.Params["name"];
            var birth = HttpContext.Current.Request.Params["birth"];
            var mail = HttpContext.Current.Request.Params["mail"];
            var depart = HttpContext.Current.Request.Params["department"];
            var job = HttpContext.Current.Request.Params["job"];
            var pass = HttpContext.Current.Request.Params["pass"];
            var phones = HttpContext.Current.Request.Params["phones"];
            var p = phones.Split('"');
            List<phone> nphone = new List<phone>();
            foreach (var itm in p)
            {
                if (itm.Length > 5 && itm!= "clientId" && itm!= "phones")
                {
                    nphone.Add(new phone { phones = itm });
                }
            }
            var addresses = HttpContext.Current.Request.Params["addresses"];
            var a = addresses.Split('"');
            List<address> naddress = new List<address>();
            foreach (var item in a)
            {
                if (item.Length > 5 && item != "addres" && item!= "clientId")
                {
                    naddress.Add(new address { addres = item });
                }
            }
            string imgName = "";
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                var img = HttpContext.Current.Request.Files[0];
                imgName = HttpContext.Current.Server.MapPath("..\\images") + "\\" + img.FileName;

                img.SaveAs(imgName);
            }
            int age = 0;
            if (birth.Length > 5)
            {
                DateTime birthdate = DateTime.Parse(birth);

                age = DateTime.Now.Year - birthdate.Year;
                if (DateTime.Now.DayOfYear < birthdate.DayOfYear)
                    age = age - 1;
            }
            

            clientView v = new clientView();
            v.clientId = int.Parse(id);
            v.birthdate = birth;
            v.clientName = fullname;
            v.departmentId = int.Parse(depart);
            v.job = int.Parse(job);
            v.age = age;
            v.mail = mail;
            v.photo = imgName;
            v.password = pass;
            v.clientPhone = nphone;
            v.clientAddress = naddress;
            
            var result= c.EditClient(v);
            return result;
        }
    }
}
