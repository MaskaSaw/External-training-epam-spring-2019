using Books;

namespace BookService
{
    /// <summary>
    /// Interface for finding Book object with special parameter given
    /// </summary>
    public interface IFind
    {
        Book FindBookByTag();
    }
}
