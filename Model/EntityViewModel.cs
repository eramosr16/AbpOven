using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpOven.Model
{
    public class EntityViewModel
    {
        public EntityViewModel(string subType, string entityName)
        {
            switch (subType.ToLower())
            {
                case "m":
                    Multitenant = true;
                    break;
                case "s":
                    SoftDelete = true;
                    break;
                case "ms":
                    Multitenant = true;
                    SoftDelete = true;
                    break;
                default:
                    Multitenant = false;
                    SoftDelete = false;
                    break;
            }
            var tmp = entityName.Split('.');
            Directory = tmp.Length == 2 ? tmp[1] : Helper.PluralizeElement(tmp[0]);
            EntityName = tmp[0];
        }
        /// <summary>
        /// Directory inside the project 
        /// where entity will be added 
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Entity Name
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// Set Multitenancy Flag
        /// </summary>
        public bool Multitenant { get; set; }
       

        /// <summary>
        /// Set SoftDelete Flag
        /// </summary>
        public bool SoftDelete { get; set; }


    }
}
