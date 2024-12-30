using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samples
{
    public interface IdModel
    {
        int Id { get; set; }
    }
    public record Model : IdModel
    {
        public int Id { get; set; } 
        public int RandomData { get; set; }
    }
}
