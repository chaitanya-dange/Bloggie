using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public class TagRepository : ITagInterface
    {
        Task<Tag> ITagInterface.AddAsync(Tag tag)
        {
            throw new NotImplementedException();
        }

        Task<Tag?> ITagInterface.DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Tag>> ITagInterface.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Tag> ITagInterface.GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<Tag?> ITagInterface.UpdateAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
