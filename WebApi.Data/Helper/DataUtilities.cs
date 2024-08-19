using mMoser.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace mMoser.Data.Helpers
{
    public class DataUtilities
    {

        private readonly mMoserApplicationDbContext _context;

        public DataUtilities(mMoserApplicationDbContext context)
        {
            _context = context;
        }


        
        public static string[] SortTypes = { "ASC", "DESC" };

  
    }
}
