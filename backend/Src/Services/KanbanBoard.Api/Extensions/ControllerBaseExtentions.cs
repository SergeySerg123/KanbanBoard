using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KanbanBoard.Services.Goals.Api.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static string GetUserIdFromToken(this ControllerBase controller)
        {
            var claimsUserId = controller.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;


            //TODO: 
            if (string.IsNullOrEmpty(claimsUserId))
            {
                //throw new InvalidTokenException("access");
            }

            return claimsUserId;
        }
    }
}
