﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entity
{
	public class NotificationMessage
	{
		public Order Order { get; set; }
        public string Messages { get; set; }
    }
}
