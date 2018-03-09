using PyramidStore.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PyramidStore.DL
{
    public class PyramidStoreRepository: IPyramidStoreRepository
    {
        private IPyramidStoreContext _context;
        public PyramidStoreRepository(IPyramidStoreContext context)
        {
            _context = context;
        }
    }
}
