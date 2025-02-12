﻿using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoices
{
    public interface IInvoiceRepository : IGenericRepository<Invoice, InvoiceId> 
    {

    }
}
