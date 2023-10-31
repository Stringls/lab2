using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WebApplicationExample2.Models;
using WebApplicationExample2.Services;

namespace WebApplicationExample2.Controllers
{
    public class MailController : Controller
    {
        private readonly ILogger<MailController> _logger;
        private readonly IMailService _mailService;

        public MailController(ILogger<MailController> logger, IMailService mailService)
        {
            _logger = logger;
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View(new SendMailViewModel());
        }

        public IActionResult SendMail()
        {
            return View(new SendMailViewModel());
        }

        [HttpPost]
        public IActionResult SendMail(SendMailViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            try
            {
                _mailService.SendMail(model.MailTo, model.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                ModelState.AddModelError("", ex.Message);

                return View(model);
            }

            return View();
        }
    }
}