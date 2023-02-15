namespace TestApplication.Models
{
    public class Group
    {
        public String GroupCode { get; set; }
        public String GroupDescription { get; set; }
        public Type GroupType { get; set; }

        public Group(string groupCode, string groupDescription, Type groupType)
        {
            GroupCode = groupCode;
            GroupDescription = groupDescription;
            GroupType = groupType;
        }

    }
}
