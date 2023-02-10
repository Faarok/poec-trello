using Microsoft.AspNetCore.Mvc;

namespace trello
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = RepoTools.repoUser.ReadAll();
            return View(users);
        }

        public IActionResult Details(int id)
        {
            return View(RepoTools.repoUser.Read(id));
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            RepoTools.repoUser.Create(user);
            return RedirectToAction("Index");
        }

        public IActionResult EditUser(int id)
        {
            return View(RepoTools.repoUser.Read(id));
        }

        [HttpPost]
        public IActionResult EditUser(User updatedUser)
        {
            User row = RepoTools.repoUser.Read(updatedUser.ID);
            row.Name = updatedUser.Name;
            row.Email = updatedUser.Email;

            // // foreach(var tmp in updatedUser.GetType().GetProperties())
            // // {
                
            // // }
            // foreach(var item in row.GetType().GetProperties())
            // {

            //     System.Console.WriteLine(item.GetValue(row).GetType());
            // }

            RepoTools.repoUser.Update();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(int id)
        {
            RepoTools.repoUser.Delete(id);
            return RedirectToAction("Index");
        }
    }
}