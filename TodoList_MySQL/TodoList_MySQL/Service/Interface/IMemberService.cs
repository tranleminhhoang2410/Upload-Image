using TodoList_MySQL.Model;

namespace TodoList_MySQL.Service.Interface
{
    public interface IMemberService
    {
        Task<Member> CreateMember(string name, string password);
        Task<Member> GetMember(string name, string password);
        Task<Member> GetMember(int id);
        Task<Member> UpdateMember(Member member);

    }
}
