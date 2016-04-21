using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;
using CheckParametrs;

namespace WorkWithBooks
{
    public class CompareByName : Check, IComparer<Book>
    {
        #region Public Methods
        public int Compare(Book first, Book second)
        {
            CheckRefOnNull(first);
            CheckRefOnNull(second);
            return first.Name.CompareTo(second.Name);
        }
        #endregion
    }
}
