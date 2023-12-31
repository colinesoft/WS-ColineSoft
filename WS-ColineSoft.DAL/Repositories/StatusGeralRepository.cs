﻿using WS_ColineSoft.DAL.Context;
using WS_ColineSoft.Domain.Entities;
using WS_ColineSoft.Domain.Interfaces.Repositories;

namespace WS_ColineSoft.DAL.Repositories
{
    public class StatusGeralRepository: BaseRepository<StatusGeralEntity>, IStatusGeralRepository
    {
        public StatusGeralRepository(ColineSoftContext context) : base(context)
        {            
        }
    }
}
