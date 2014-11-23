using BullsAndCows.Data;
using BullsAndCows.Models;
using BullsAndCows.WebApi.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace BullsAndCows.WebApi.Controllers
{
    public class NotificationsController : BaseApiController
    {
        public NotificationsController(IBullsAndCowsData data)
            : base(data)
        {
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetNotifications()
        {
            return this.GetNotifications(0);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult GetNotifications(int page)
        {
            var currentUserId = this.User.Identity.GetUserId();

            var notifications = this.data.Notifications.All()
                .Where(n => n.UserId == currentUserId)
                .OrderBy(n => n.DateCreated)
                .Skip(page * 10)
                .Take(10)
                .Select(NotificationDataModel.FromNotification).ToList();

            return Ok(notifications);
        }

        [HttpGet]
        [Authorize]
        public IHttpActionResult NextNotification()
        {
            var currentUserId = this.User.Identity.GetUserId();

            var oldestUndread = this.data.Notifications.All()
               .Where(n => n.UserId == currentUserId && n.State == NotificationState.Unread)
               .OrderBy(n => n.DateCreated)
               .Select(NotificationDataModel.FromNotification).First();

            return Ok(oldestUndread);
        }
    }
}
