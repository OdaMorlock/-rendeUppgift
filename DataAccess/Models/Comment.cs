﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Comment
    {

        public Comment()
        {

        }



        public Comment(long id, long issuedId, string description, DateTime created)
        {
            Id = id;
            IssueId = issuedId;
            Description = description;
            Created = created;
        }

        public long Id { get; set; }
        public long IssueId { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
