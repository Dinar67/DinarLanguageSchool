using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Base;

namespace LanguageSchool.Base
{
    public partial class Service
    {
        public string costTimeStr
        {
            get
            {
                if (Discount == 0)
                    return $"{Cost} рублей за {DurationInSeconds / 60} минут";
                else
                    return $"{Cost - (Cost * (decimal)Discount / 100):0} рублей за {DurationInSeconds / 60} минут";
            }
        }
    }
}
