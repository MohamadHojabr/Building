﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building.Common.Helpers
{
    [Serializable]
    public class UserProfileSessionData
    {
        public int UserId { get; set; }

        public string EmailAddress { get; set; }

        public string FullName { get; set; }
    }
}
