using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    [Serializable]
    class Customer
    {
        public Customer(string customerId, string customerName, string customerPhone,
           string customerCity)
        {
            _customerId = customerId;
            _customerName = customerName;
            _customerPhone = customerPhone;
            _customerCity = customerCity;
        }

        public Customer()
        {

        }

        private string _customerId;
        public string CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }
        private string _customerName;
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        private string _customerPhone;
        public string CustomerPhone
        {
            get { return _customerPhone; }
            set { _customerPhone = value; }
        }

        private string _customerCity;
        public string CustomerCity
        {
            get { return _customerCity; }
            set { _customerCity = value; }
        }
    }
}
