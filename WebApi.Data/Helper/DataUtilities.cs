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

        private readonly WebApiApplicationDbContext _context;

        public DataUtilities(WebApiApplicationDbContext context)
        {
            _context = context;
        }


        
        public static string[] SortTypes = { "ASC", "DESC" };

  
    }
}
