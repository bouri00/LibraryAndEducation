﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin_pro.Controllers
{
    public class MailboxController : Controller
    {
        // GET: Mailbox
        public ActionResult Mail()
        {
            return View();
        }
    }
}