﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.ClickVende.Business.DTOs
{
    public class ClientDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
    }
}
