﻿using StudentAppServer.Data.Enums;
using System;

namespace StudentAppServer.Data.Entities
{
    public class Feedback
    {
        public string Id { get; set; }

        public string Name { set; get; }

        public string Email { set; get; }

        public string Message { set; get; }

        public Status Status { set; get; }
        public DateTime? DateCreated { set; get; }
        public DateTime? DateModified { set; get; }
    }
}