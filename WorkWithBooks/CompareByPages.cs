using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookClass;
using CheckParametrs;

namespace WorkWithBooks
{
    public class CompareByPages : Check, IComparer<Book>
    {
        #region Public Methods
        public int Compare(Book first, Book second)
        {
            CheckRefOnNull(first);
            CheckRefOnNull(second);

            return first.Pages.CompareTo(second.Pages);
        }
        #endregion
    }
}
