using System.Collections.Generic;

namespace Synchronization
{
    public class SaleLog
    {
        private readonly object _sync = new object();

        private decimal _total;

        private readonly List<string> _saleDetails = new List<string>();

        public decimal Total
        {
            get
            {
                lock (_sync)
                {
                    return _total;
                }
            }
        }

        public void AddSale(string item, decimal price)
        {
            string details = $"{item} sold at {price}";
            lock (_sync)
            {
                _total += price;
                _saleDetails.Add(details);
            }
        }

        public string[] GetDetails(out decimal total)
        {
            lock (_sync)
            {
                total = _total;
                return _saleDetails.ToArray();
            }
        }
    }
}