using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneHomeSample.Models
{
    /// <summary>
    /// Class to hold information about each website reported
    /// </summary>
    public class Record
    {
        public int ID { get; set; }
        public string UrlName { get; set; }
        /// <summary>
        /// Number of "On" requests for Enterprise Mode for the URL
        /// </summary>
        public int NumOn { get; set; }
        /// <summary>
        /// Number of "Off" requests for Enterprise Mode for the URL
        /// </summary>
        public int NumOff { get; set; }
        /// <summary>
        /// The date of the last time a user toggled Enterprise Mode on or off for the website
        /// </summary>
        public DateTime LastReported { get; set; }
    }

    /// <summary>
    /// Class which maps to the POST message sent by IE
    /// </summary>
    public class Report
    {
        public int ReportID { get; set; }
        /// <summary>
        /// The URL in the report
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// Direction of the toggle, e.g. On or Off
        /// </summary>
        public string EnterpriseMode { get; set; }
    }
}