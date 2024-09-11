using GymManager.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Newtonsoft.Json;

namespace GymManager.MVC.Extensions
{
    public static class ControllerExtensions
    {
        public static  void SetNotification(this Controller controller, string type, string message )
        {
            var notification = new Notification(type, message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
