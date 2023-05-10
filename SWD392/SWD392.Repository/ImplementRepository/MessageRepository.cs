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
    public class MessageRepository : GennericRepository<Message>, IMessageRepository
    {
        public MessageRepository(SWD_Summer2023Context context) : base(context) { }
    }
}