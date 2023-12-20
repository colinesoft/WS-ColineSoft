﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class CorRepository : BaseRepository<CorEntity>, ICorRepository
    {
        public CorRepository(ColineSoftContext context) : base(context)
        {
        }
    }
}
