using System.Collections.Generic;

namespace MVVM.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ConfirmedCount> ProvinceCounts { get; set; }
    }
}