﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWD392.Models.Models;
using SWD392.Repository.GenericRepository;
using SWD392.Repository.IRepository;

namespace SWD392.Repository.ImplementRepository
{
    public class AnswerRepository : GennericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(SWD_Summer2023Context context) : base(context) { }
    }
}