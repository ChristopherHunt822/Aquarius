using Aquarius.Data;
using Aquarius.Models.AcctModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarius.Models.InvestorModels
{
    public class InvestorListItem
    {
        
        public int InvestorID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName
        {
            get => FirstName + " " + LastName;
        }

        public List<AcctListItem> Accts { get; set; }
    }
}
