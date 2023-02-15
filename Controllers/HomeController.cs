using Microsoft.AspNetCore.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly GroupContext groupContext;
        private readonly TypeContext typeContext;

        public HomeController(GroupContext groupContext, TypeContext typeContext)
        {
            this.groupContext = groupContext;
            this.typeContext = typeContext;
        }

        [HttpPost(Name = "createGroup")]
        public IActionResult CreateGroupItem(GroupDto request)
        {
            Models.Type type = typeContext.TypeItems.Where(x => x.type == request.GroupType).FirstOrDefault();
            if (type != null)
            {
                Group group = new Group(
                    request.GroupCode,
                    request.GroupDescription,
                    type
                );

                groupContext.GroupItems.Add(group);
                groupContext.SaveChanges();

                return StatusCode(201);
            }
            return BadRequest();
        }

        [HttpGet(Name = "getGroup")]
        public async Task<ActionResult<Group>> GetGroupItem(String groupCode)
        {   
            var group = await groupContext.GroupItems.FindAsync(groupCode);
            if (group == null)
            {
                return NotFound();
            }

            return group;
        }

        [HttpPut(Name = "editGroup")]
        public IActionResult EditGroupItem(Group group)
        {
            var data = groupContext.GroupItems.Where(x => x.GroupCode == group.GroupCode).FirstOrDefault();
            if (data != null)
            {
                data.GroupDescription = group.GroupDescription;
                data.GroupType = group.GroupType;
                groupContext.SaveChanges();
            }

            return StatusCode(200);
        }

        [HttpDelete(Name = "deleteGroup")]
        public IActionResult DeleteGroupItem(String groupCode)
        {
            var data = groupContext.GroupItems.Where(x => x.GroupCode == groupCode).FirstOrDefault();
            if (data != null)
            {
                groupContext.GroupItems.Remove(data);
            }

            return StatusCode(200);
        }

    }
}
