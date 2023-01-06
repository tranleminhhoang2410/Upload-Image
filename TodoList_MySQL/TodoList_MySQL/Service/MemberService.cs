using System.Collections;
using TodoList_MySQL.Model;
using TodoList_MySQL.Service.Interface;
using TodoList_MySQL.Specification.ModelSpecification;

namespace TodoList_MySQL.Service
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork unitOfWork;

        public MemberService()
        {
        }

        public MemberService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Member> CreateMember(string name, string password)
        {
            var newMember = new Member
            {
                Name = name,
                Password = password
            };

            unitOfWork.Repository<Member>().Add(newMember);

            var result = await unitOfWork.Complete();

            if (result <= 0) return null;

            return newMember;
        }

        public async Task<Member> GetMember(string name, string password)
        {
            var specification = new MemberWithInfomationSpecification(name, password);

            return await unitOfWork.Repository<Member>().GetWithSpecification(specification);
        }

        public async Task<Member> GetMember(int id)
        {
            var specification = new MemberWithInfomationSpecification(id);

            return await unitOfWork.Repository<Member>().GetWithSpecification(specification);
        }

        public async Task<Member> UpdateMember(Member member)
        {
            unitOfWork.Repository<Member>().Update(member);

            var result = await unitOfWork.Complete();

            if (result <= 0) return null;

            return member;
        }
    }
}
