using ASPProjekt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPProjekt.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            return View(_bookService.FindAll());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            var model = new Book();
            model.PublisherList = _bookService
                .FindAllPublishers()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Name })
                .ToList();
            return View("Create",model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(model);
                return RedirectToAction("Index");
            }
            return View("Create");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult CreateApi()
        {
            return View("CreateApi");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult CreateApi(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Add(model);
                return RedirectToAction("Index");
            }
            return View("CreateApi", model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            return View("Update", _bookService.FindById(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(Book model)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(model);
                return RedirectToAction("Index");
            }
            return View("Update");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_bookService.FindById(id));
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _bookService.Delete(model.Id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            return View("Details",_bookService.FindById(id));
        }

        [Authorize(Roles ="admin")]
        [HttpGet]
        public IActionResult CreatePublisher()
        {
            return View("CreatePublisher");
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult CreatePublisher(Publisher model)
        {
            if (ModelState.IsValid)
            {
                _bookService.AddPublisher(model);
                return RedirectToAction("Index");
            }
            return View("CreatePublisher",model); //ponownie wyswitl form
        }

        public IActionResult PagedIndex(int page = 1, int size = 2)
        {
            return View(_bookService.FindPage(page, size));
        }
    }
}
