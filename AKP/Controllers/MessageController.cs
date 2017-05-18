using AKP.App_Start;
using AKP.Infrastructure;
using AKP.Models;
using AKP.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PagedList;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AKP.Controllers
{
    public class MessageController : Controller
    {
        private UnitOfWork unitofwork = null;
        public MessageController ()
        {
            unitofwork = new UnitOfWork();
        }
        
        public async Task<ActionResult> Inbox(int? page)
        {
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var ListView = unitofwork.MessageGetRepo.GetAllMessageDsc(user.person.PersonId);
            int PageSize = 10;
            int PageNumber = (page ?? 1);
            return View(ListView.ToPagedList(PageNumber, PageSize));
        }
        public ActionResult GetMessage(int id)
        {
            var message = unitofwork.MessageRepo.GetById(id);
            Person personSender = unitofwork.PersonRepo.GetById(message.PersonSenderId);
            MessageViewModel model = new MessageViewModel();
            model.message = message;
            model.person = personSender;           
            return View(model);
        }
        public ActionResult DeleteMessage(int id)
        {
            var message = unitofwork.MessageRepo.GetById(id);
            unitofwork.MessageRepo.Remove(message);
            return View();
        }
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessagePost(MessageViewModel model)
        {
            unitofwork.MessageRepo.Add(model.message);
            return View();
        }
        public JsonResult GetEmailList (string term)
        {
            var list = unitofwork.PersonGetRepo.GetMail(term);
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> SendMessage(int? page)
        {
            try
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                var message = unitofwork.MessageGetRepo.GetAllMessageSend(user.person.PersonId);
                int PageSize = 10;
                int PageNumber = (page ?? 1);
                return View(message.ToPagedList(PageNumber, PageSize));
            }
            catch
            {
                return HttpNotFound();
            }
        }
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}