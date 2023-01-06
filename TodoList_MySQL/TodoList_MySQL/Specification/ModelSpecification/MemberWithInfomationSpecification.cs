using System.Linq.Expressions;
using TodoList_MySQL.Model;

namespace TodoList_MySQL.Specification.ModelSpecification
{
    public class MemberWithInfomationSpecification : Specification<Member>
    {
        public MemberWithInfomationSpecification(string name, string password) : 
            base(o => o.Name == name && o.Password == password)
        {
            AddInclude(o => o.Todos);
            AddInclude(o => o.Groups);
            AddInclude(o => o.Photos);
        }

        public MemberWithInfomationSpecification(int id) :
                    base(o => o.Id == id)
        {
            AddInclude(o => o.Todos);
            AddInclude(o => o.Groups);
            AddInclude(o => o.Photos);
        }
    }
}
