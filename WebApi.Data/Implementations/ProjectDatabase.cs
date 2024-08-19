using Microsoft.EntityFrameworkCore;
using mMoser.Data.Helpers;
using mMoser.Data;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using X.PagedList;
using System;
using Microsoft.EntityFrameworkCore.Storage;
using System.Globalization;
using Microsoft.Data.SqlClient;
using JetBrains.Annotations;
using System.Transactions;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace mMoser.Data
{
    public class ProjectDatabase : IProjectDatabase
    {
        private readonly mMoserApplicationDbContext _context;
        private readonly DataUtilities _utilities;
       
        public ProjectDatabase(mMoserApplicationDbContext context, DataUtilities utilities)
        {
            _context = context;
            _utilities = utilities;
        }



    }
}


//SpContactdetailsExternal objSpContactdetailsExternal = new SpContactdetailsExternal();
//objSpContactdetailsExternal.userName = "Mike";
//objSpContactdetailsExternal.contactTypeId = 4;
//objSpContactdetailsExternal.contactid = 2;
//objSpContactdetailsExternal.contactCompanyId = 1;
//objSpContactdetailsExternal.officeId = 1;
//objSpContactdetailsExternal.projectId = "2015651925151496260836";
//objSpContactdetailsExternal.contactEmail = "mike@email.com";
////-----------------------------client------------------------
//SpContactdetailsExternal obj2SpContactdetailsExternal = new SpContactdetailsExternal();
//obj2SpContactdetailsExternal.userName = "Mike";
//obj2SpContactdetailsExternal.contactTypeId = 4;
//obj2SpContactdetailsExternal.contactid = 2;
//obj2SpContactdetailsExternal.contactCompanyId = 1;
//obj2SpContactdetailsExternal.officeId = 1;
//obj2SpContactdetailsExternal.projectId = "2015651925151496260836";
//obj2SpContactdetailsExternal.contactEmail = "mike@email.com";

//return objSpContactdetailsExternal;

//SpContactdetailsExternal objSpContactdetailsExternal = new SpContactdetailsExternal();
//objSpContactdetailsExternal.userName= "Mike";    
//objSpContactdetailsExternal.contactTypeId = 4;
//objSpContactdetailsExternal.contactid = 2;
//objSpContactdetailsExternal.contactCompanyId = 1;
//objSpContactdetailsExternal.officeId= 1 ;
//objSpContactdetailsExternal.projectId = "2015651925151496260836";
//objSpContactdetailsExternal.contactEmail = "mike@email.com";
//return objSpContactdetailsExternal;