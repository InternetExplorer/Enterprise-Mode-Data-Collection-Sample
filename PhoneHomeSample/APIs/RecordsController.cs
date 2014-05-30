using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using PhoneHomeSample.Models;

namespace PhoneHomeSample.APIs
{
    public class RecordsController : ApiController
    {
        PhoneHomeDBContext db = new PhoneHomeDBContext();

        // POST api/records
        [HttpPost]
        public HttpResponseMessage Post(Report request)
        {
            var error = Request.CreateResponse(HttpStatusCode.BadRequest);
            if (request == null)
            {
                return error;
            }

            string newUrl = request.URL;

            Record existingUrl = db.Records.FirstOrDefault((url) => url.UrlName == newUrl);

            if (existingUrl == null)
            {
                Record report = new Record();
                report.UrlName = newUrl;
                report.LastReported = DateTime.Now;

                if (request.EnterpriseMode == "On")
                {
                    report.NumOn = 1;
                    report.NumOff = 0;
                }
                else
                {
                    report.NumOn = 0;
                    report.NumOff = 1;
                }

                if (ModelState.IsValid)
                {
                    db.Records.Add(report);
                    db.SaveChanges();
                    return Request.CreateResponse<String>(HttpStatusCode.Created, "OK"); ;
                }
            }
            else
            {
                if (request.EnterpriseMode == "On")
                {
                    existingUrl.NumOn++;
                }
                else
                {
                    existingUrl.NumOff++;
                }

                if (ModelState.IsValid)
                {
                    existingUrl.LastReported = DateTime.Now;
                    db.SaveChanges();
                    return Request.CreateResponse<String>(HttpStatusCode.OK, "OK");
                }
            }

            return error;
        }
    }
}