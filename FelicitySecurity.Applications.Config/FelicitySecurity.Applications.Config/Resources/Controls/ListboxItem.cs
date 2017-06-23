using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelicitySecurity.Applications.Config.Resources.Controls
{
    public class ListboxItem
    {
        /// <summary>
        /// The items Id 
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// The list boxes item text: email or first name. 
        /// </summary>
        public string ItemText { get; set; }

        /// <summary>
        /// The list boxes second item text: first name or last name
        /// </summary>

        public string ItemText2 { get; set; }

        /// <summary>
        /// ensures the returned text is of type: string
        /// </summary>
        /// <returns>Column one</returns>
        public override string ToString()
        {
            return ItemText;
        }
    }
}
