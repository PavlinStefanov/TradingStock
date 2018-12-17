using System;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Utils
{
    internal static class PrivateReflectionDynamicObjectExtensions
    {
        public static dynamic AsDynamic(this object o)
        {
            return PrivateReflectionDynamicObject.WrapObjectIfNeeded(o);
        }
    }
}
