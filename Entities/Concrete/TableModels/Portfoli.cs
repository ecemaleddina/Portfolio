using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class Portfoli:BaseEntity
    {
        public string Title { get; set; }
        public int WorkCategoryId { get; set; }
        public string WorkImgPath { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile WorkImageFile { get; set; }
        public WorkCategory WorkCategory { get; set; }
    }
}
