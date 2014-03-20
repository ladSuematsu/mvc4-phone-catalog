using Mvc4PhoneCatalog.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc4PhoneCatalog.Controllers
{
    public class PhoneController : Controller
    {
        private PhoneRepository _db = new PhoneRepository();
        
        //
        // GET: /Phone/
        //public ActionResult Index()
        //{
        //    return View();
        //}

        protected void Dispose(bool disposed)
        {
            if (_db != null)
            {
                _db.Dispose();
            }

            base.Dispose(disposed);

        }


        public ActionResult SearchPhone(string searchTerm = null)
        {
            //Models.Phone phone = _db.ListPhone().First(r => searchTerm == null || r.ModelName.StartsWith(searchTerm));

            List<Models.Phone> phoneSearchResult = _db.ListPhoneSearch(searchTerm);

            return View(phoneSearchResult);

        }

        public ActionResult ListPhones()
        {
            

            var phoneList = _db.ListPhone();

            return View(phoneList);

        }

        public PartialViewResult PhoneDetails(string id)
        {
            Models.Phone phone = new Models.Phone();

            int phoneId = -1;

            if(int.TryParse(id, out phoneId))
            {
                phone = _db.PhoneSearch(phoneId);
            }

            return PartialView("_PhoneDetails",phone);
        }

        [HttpGet]
        public PartialViewResult PhoneInsert()
        {

            return PartialView();
        }

        [HttpPost]
        public ActionResult PhoneInsert (Models.Phone phone)
        {

            ViewBag.OperationSuccess = true;
            
            try
            {
                _db.CreatePhone(phone);

            }
            catch
            {
                ViewBag.OperationSuccess = false;
            }
            finally
            {
                
            }

            return View();
                
        }

        [HttpGet]
        public ActionResult PhoneEdit(int id)
        {
            Models.Phone phone = _db.PhoneSearch(id);
            
            return PartialView("_PhoneEdit", phone);
        }

        [HttpPost]
        public ActionResult PhoneEdit(Models.Phone phone)
        {
            _db.EditPhone(phone);

            return View();
        }

        public ActionResult PhoneDelete(int id)
        {

            _db.DeletePhone(id);

            return View();
        }

    }
}
