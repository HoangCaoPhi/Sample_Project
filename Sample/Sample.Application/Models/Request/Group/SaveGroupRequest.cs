using Sample.Domain.Enums;

namespace Sample.Application.Models.Request.Group
{
    public class SaveGroupRequest
    {
        public string GroupName { get; set; }

        public string Description { get; set; }

        public GroupTypeEnum GroupTypeEnum { get; set; }
    }
}
