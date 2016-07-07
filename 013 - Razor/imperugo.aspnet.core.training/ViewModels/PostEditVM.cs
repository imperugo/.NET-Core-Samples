using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace imperugo.aspnet.core.training.ViewModels
{
    public class PostEditVM
    {
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }

        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset PublishDate { get; set; }
    }
}
