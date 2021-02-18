using System;
using System.Collections.Generic;
using System.Linq;

namespace BlueModas.Libraries.Pagination
{
    public class PaginationEngine<T>
    {
        public int PageIndex { get; private set; }
        private int PageLength;
        public int TotalPages { get; private set; }
        public List<T> Elementos;
        public PaginationEngine(int? PageIndex, int PageLength, int QtdItens, List<T> elementos)
        {
            this.PageIndex = PageIndex ?? 1;
            this.TotalPages = (int)Math.Ceiling(QtdItens / (double)PageLength);
            this.PageLength = PageLength;
            this.Elementos = elementos.Skip((this.PageIndex-1)*PageLength).Take(PageLength).ToList();
        }
        public bool HasNextPage { get { return PageIndex < TotalPages && Elementos.Count()==PageLength; } }
        public bool HasPreviousPage { get { return PageIndex > 1; } }
    }
}
