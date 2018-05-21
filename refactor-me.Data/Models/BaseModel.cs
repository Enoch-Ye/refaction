using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_me.Data.Models
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid Id { get; set; }
        
        //TODO: Added cluster index on auto increment column
    }
}
