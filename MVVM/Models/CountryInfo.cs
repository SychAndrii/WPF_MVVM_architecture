using System.Collections.Generic;

namespace MVVM.Models
{
    internal class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> Provinces { get; set; }
    }
}