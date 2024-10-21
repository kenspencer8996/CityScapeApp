using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityScapeApp.Objects.Entities
{
    internal class RobberyMessageDetailEntity
    {
        public string RobberName;
        public BusinessContent Business;
        internal RobberyMessageDetailEntity(string RobberName, BusinessContent Business)
        {
            this.RobberName= RobberName.Trim();
            this.Business = Business;
        }
    }
}
