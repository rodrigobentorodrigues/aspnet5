using Course.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Course.ViewModels
{
    public class NewCustomerViewModel
    {

        public SelectList Types { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}