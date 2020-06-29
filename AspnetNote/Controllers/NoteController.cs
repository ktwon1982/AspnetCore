﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.DataContext;
using AspnetNote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.Controllers
{
    public class NoteController : Controller
    {
        /// <summary>
        /// 게시판 리스트 
        /// </summary>
        /// <returns></returns>        
        public ActionResult Index()
        {
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태 
                return RedirectToAction("Login", "Account");
            }

            using(var db = new AspnetNoteDbContext())
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }

        /// <summary>
        /// 게시판 게시물 추가
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태 
                return RedirectToAction("Login", "Account");
            }

            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    db.Notes.Add(model);

                    if(db.SaveChanges() > 0)
                    {
                        return Redirect("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "게시물을 저장할 수 없습니다.");
            }
            return View(model);
        }

        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태 
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태 
                return RedirectToAction("Login", "Account");

            }
            return View();
        }
    }
}
