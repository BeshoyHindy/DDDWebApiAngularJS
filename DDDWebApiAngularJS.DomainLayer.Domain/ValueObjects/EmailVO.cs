using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Resources;
using DDDWebApiAngularJS.InfrastructureLayer.CrossCutting.Common.Validations;

namespace DDDWebApiAngularJS.DomainLayer.Domain.ValueObjects
{
    public class EmailVO
    {
        private const string PATTERN = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public string Email { get; private set; }

        public EmailVO()
        { }

        public EmailVO(string email)
        {
            Email = email;
        }

        public virtual bool IsValid()
        {
            return AssertionConcern.IsSatisfiedBy
            (
                AssertionConcern.AssertNotNull(Email, string.Format(Language.RequiredM, Language.Email)),
                AssertionConcern.AssertLength(Email, 3, 100, string.Format(Language.Length, Language.Email, 3, 100)),
                AssertionConcern.AssertMatches(PATTERN, Email, string.Format(Language.InvalidM, Language.Email))
            );
        }
    }
}
