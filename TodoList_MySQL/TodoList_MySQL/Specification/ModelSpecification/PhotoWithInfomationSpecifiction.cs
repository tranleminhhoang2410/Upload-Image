using TodoList_MySQL.Model;

namespace TodoList_MySQL.Specification.ModelSpecification
{
    public class PhotoWithInfomationSpecifiction : Specification<Photo>
    {
        public PhotoWithInfomationSpecifiction(int userid) :
                    base(o => o.MemberId == userid)
        {
           AddOrderBy(o => o.Id);
        }
    }
}
