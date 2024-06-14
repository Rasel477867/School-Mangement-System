using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SchoolMS.Core.Models;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;

namespace SchoolMS.Web.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationService _designationService;
        private readonly IMapper _mapper;
        public DesignationController(IDesignationService designationService,IMapper mapper)
        {
            _designationService = designationService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var model=await _designationService.GetAll();
            return View(model);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DesignationView model)
        {
            if (ModelState.IsValid)
            {
                var NewDesignation = _mapper.Map<Designation>(model);
               await _designationService.Add(NewDesignation);
                TempData["Success"] = " Designation Created Successfully";
                return RedirectToAction("Index");

            }
            else
            {  
                return View(model);
            }
           
        }
        public async Task<IActionResult> Details(int id)
        {
            var model=await _designationService.GetById(id);
            if (model != null)
            {
                var obj=_mapper.Map<DesignationView>(model);
                return View(obj);
            }
            else
                return View();
        }
        public async Task<IActionResult>Edit(int id)
        {
            var model=await _designationService.GetById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Designation model)
        {
            if (ModelState.IsValid)
            {
               await _designationService.Update(model);
                TempData["Update"] = "Update Successfully";
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var obj= await _designationService.GetById(id);
            return View(obj);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Designation model)
        {
             await _designationService.Delete(model);
            TempData["Delete"] = "Delete Successfully";
            return RedirectToAction("Index");

        }
    }
}
