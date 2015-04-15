using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "URL")]
        public string UrlName { get; set; }

        /// <summary>
        /// Number of "On" requests for Enterprise Mode for the URL
        /// </summary>
        [Display(Name = "Enterprise Mode turned ON")]
        public int NumOn { get; set; }
        
        /// <summary>
        /// Number of "Off" requests for Enterprise Mode for the URL
        /// </summary>
        [Display(Name = "Enterprise Mode turned OFF")]
        public int NumOff { get; set; }


        [NotMapped]
        [Display(Name = "Delta")]
        public int Delta { get { return (NumOn - NumOff); } }

        /// <summary>
        /// The date of the last time a user toggled Enterprise Mode on or off for the website
        /// </summary>
        [Display(Name = "Last Reported")]
        [DataType(DataType.Date)]
        public DateTime LastReported { get; set; }
    }

    /// <summary>
    /// Class which maps to the POST message sent by IE
    /// </summary>
    public class Report
    {
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