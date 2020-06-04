using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_experience.Medium
{
    [Serializable]
    public abstract class Media
    {
        public DateTime published { get; set; }

        public string Name { get ; set; } = "";

    }
}
