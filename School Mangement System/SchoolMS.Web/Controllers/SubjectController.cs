﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMS.Core.Models;
using SchoolMS.Service.Contacts;
using SchoolMS.Web.ViewModels;

namespace SchoolMS.Web.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IClassLevelService _classLevelService;
        public SubjectController(ISubjectService subjectService, IClassLevelService classLevelService)
        {
            _subjectService = subjectService;
            _classLevelService = classLevelService; 

        }
        public async Task<IActionResult> Index()
        {
            var obj = new ClassView();
            obj.ClassList= _classLevelService.GetAll().Result.Select(x=>new SelectListItem
            {
                Value=x.Id.ToString(),
                Text=x.Name
            }).ToList();
            return View(obj);
        }
        [HttpPost]
        public IActionResult Create(ClassView obj)
        {
            var model = new Subjects();
            model.ListSubjects = new List<SubjectView>();
            var subjectview = new SubjectView()
            {
                ClassId = obj.ClassId
            };
            model.ListSubjects.Add(subjectview);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>CreateSubject(Subjects subjects)
        {
            //foreach (var subject in subjects.ListSubjects)
            // {
            //     var obj = new Subject();
            //     obj.Name = subject.Name;
            //     obj.ClassId = subject.ClassId;
            //     obj.Code= subject.Code;
            //    await _subjectService.Add(obj);
            // }
            var model = new List<Subject>();
           foreach (var subject in subjects.ListSubjects) {
            var obj=new Subject();
                
                obj.Name= subject.Name;
                obj.Code= subject.Code;
                obj.ClassId= subject.ClassId;
                var state = _subjectService.AddValidation(obj);
                if(state)
                {
                    model.Add(obj);
                }
            
            }
           if(model.Count>0)
            {
                await _subjectService.MultipleSubjectAdd(model);
            }
         

           return RedirectToAction("Index");
        }
      

    }
}
