using Microsoft.AspNetCore.Mvc;

namespace trello
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            List<Project> Projects = RepoTools.repoProject.ReadAll();
            return View(Projects);
        }

        public IActionResult Details(int id)
        {
            return View(RepoTools.repoProject.Read(id));
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project Project)
        {
            RepoTools.repoProject.Create(Project);
            return RedirectToAction("Index");
        }

        public IActionResult EditProject(int id)
        {
            return View(RepoTools.repoProject.Read(id));
        }

        // [HttpPost]
        // public IActionResult EditProject(Project updatedProject)
        // {
        //     Project row = RepoTools.repoProject.Read(updatedProject.ID);
        //     row.Name = updatedProject.Name;
        //     row.Email = updatedProject.Email;

        //     // // foreach(var tmp in updatedProject.GetType().GetProperties())
        //     // // {
                
        //     // // }
        //     // foreach(var item in row.GetType().GetProperties())
        //     // {

        //     //     System.Console.WriteLine(item.GetValue(row).GetType());
        //     // }

        //     RepoTools.repoProject.Update();
        //     return RedirectToAction("Index");
        // }

        public IActionResult DeleteProject(int id)
        {
            RepoTools.repoProject.Delete(id);
            return RedirectToAction("Index");
        }
    }
}