using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace TradingStock.Business.CQRS.Utils
{
    public class EnumerableGeneric<TClass, TInterface> : IEnumerable<TInterface> where TClass : TInterface
    {
        private IList<TClass> list;
        public EnumerableGeneric(IList<TClass> list)
        {
            this.list = list;
        }
        public IEnumerator<TInterface> GetEnumerator()
        {
            foreach (TClass item in list)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
