namespace Zoe.IdentityAccess.Api.Describers
{
    public partial class ApplicationMessageDescriber
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ApplicationMessageDescriber() { }

        public ApplicationMessageDescriber(
            string code,
            string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}
