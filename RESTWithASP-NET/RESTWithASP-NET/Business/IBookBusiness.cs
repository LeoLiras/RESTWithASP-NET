using RESTWithASP_NET.Data.VO;
using RESTWithASP_NET.Model;

namespace RESTWithASP_NET.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
