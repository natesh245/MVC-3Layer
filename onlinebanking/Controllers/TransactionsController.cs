﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onlinebanking.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        public ActionResult Index()
        {
            return View();
        }
    }
}