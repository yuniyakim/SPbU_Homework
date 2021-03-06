﻿using _12._1.Models;
using _8._1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _12._1.Controllers
{
    /// <summary>
    /// Web-app controller
    /// </summary>
    public class HomeController : Controller
    {
        private History history = new History();
        private IWebHostEnvironment environment;
        private CompletedTestsInfo tests = new CompletedTestsInfo();
        private string path;
        private List<string> uploadedFiles;

        /// <summary>
        /// Controller's constructor
        /// </summary>
        /// <param name="history">History of assemblies and tests</param>
        /// <param name="environment">Web environment</param>
        public HomeController(IWebHostEnvironment environment)
        {
            this.environment = environment;
            path = environment.WebRootPath + "/files/";
            uploadedFiles = new List<string>();
            if (!IsDirectoryEmpty(path))
            {
                var directory = new DirectoryInfo(path);
                foreach (var file in directory.GetFiles())
                {
                    uploadedFiles.Add(file.Name);
                }
            }
        }

        /// <summary>
        /// Loads start page
        /// </summary>
        public IActionResult Index()
        {
            ViewBag.Files = uploadedFiles;
            return View("TestRunner", tests);
        }

        /// <summary>
        /// Uploads file to Files folder
        /// </summary>
        /// <param name="file">Added file</param>
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file != null)
            {
                using (var fileStream = new FileStream(environment.WebRootPath + "/files/" + file.FileName, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                uploadedFiles.Add(file.Name);
                ViewBag.Files = uploadedFiles;
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Checks if directory is empty
        /// </summary>
        /// <param name="path">Directory to check</param>
        /// <returns>True if directory is empty, false otherwise</returns>
        private bool IsDirectoryEmpty(string path) => !Directory.EnumerateFileSystemEntries(path).Any();

        /// <summary>
        /// Deletes all uploaded files
        /// </summary>
        public IActionResult DeleteUploadedFiles()
        {
            if (!IsDirectoryEmpty(path))
            {
                var directory = new DirectoryInfo(path);
                foreach (var file in directory.GetFiles())
                {
                    file.Delete();
                }
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Launches test runner
        /// </summary>
        [HttpPost]
        public IActionResult RunTests()
        {
            if (!IsDirectoryEmpty(path))
            {
                var directory = new DirectoryInfo(path);
                Info[] results;

                try
                {
                    var runner = new Runner();
                    results = runner.Run(path);
                }
                catch (Exception e)
                {
                    ViewBag.ErrorMessage = e.Message;
                    return View("Error");
                }

                foreach (var file in directory.EnumerateFiles())
                {
                    var assembly = history.Assemblies.Add(new AssemblyInfo { Name = file.Name });
                    history.SaveChanges();

                    tests.Assemblies.Add(assembly);

                    foreach (var result in results)
                    {
                        var test = new TestInfo { Name = result.Name, Result = result.Result, Time = result.Time, IgnoreReason = result.IgnoreReason };
                        tests.Tests.Add(test);
                        assembly.Tests.Add(test);
                        history.SaveChanges();
                    }
                }
            }

            ViewBag.Files = uploadedFiles;
            return View("TestRunner", tests);
        }

        /// <summary>
        /// Loads tests history page
        /// </summary>
        public IActionResult History() => View(history.Assemblies.Include("Tests").ToList());
    }
}