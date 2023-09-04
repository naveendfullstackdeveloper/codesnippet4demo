using PageUPCouriersBAL.Interfaces;
using PageUPCouriersDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageUPCouriersBAL
{
    public class RuleEngine
    {
        public class HeavyParcelRule : IRuleEngine
        {
            public bool IsMatch(double volume)
            {

                if (volume < 1500)
                {
                    return true;
                }
                return false;
            }
        }

        public class SmallParcelRule : IRuleEngine
        {
            public bool IsMatch(double volume)
            {
                return volume > 1500;
            }
        }

        public class MediumParcelRule : IRuleEngine
        {
            public bool IsMatch(double volume)
            {
                return volume > 1500 && volume < 2500;

            }
        }

        public class LargeParcelRule : IRuleEngine
        {
            public bool IsMatch(double volume)
            {
                throw new NotImplementedException();
            }
        }



    }
}
