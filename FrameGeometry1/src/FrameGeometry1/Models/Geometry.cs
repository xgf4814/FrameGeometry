using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FrameGeometry1.Models
{
    public class Geometry
    {
        public int ID { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string size { get; set; }
        public double bbdrop { get; set; }
        public double stack { get; set; }
        public double reach { get; set; }
        public double wheelbase { get; set; }
        public double chainstay { get; set; }
        [Display(Name = "seat tube angle")]
        public double STA { get; set; }
        [Display(Name = "seat tube length")]
        public double STL { get; set; }
        [Display(Name = "head tube angle")]
        public double HTA { get; set; }
        [Display(Name = "head tube length")]
        public double HTL { get; set; }
        [Display(Name = "standover (N/A for MTB, use 0)")]
        public double standover { get; set; }
        public string color { get; set; }
        public bool enabled { get; set; }
        [Display(Name = "wheel + tire diameter")]
        public double wheeldiameter { get; set; }
        public string userGUID { get; set; }
    }
}
