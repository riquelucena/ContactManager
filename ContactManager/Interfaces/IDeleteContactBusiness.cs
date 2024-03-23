namespace ContactManager.Interfaces
{
    public interface IDeleteContactBusiness
    {
        Task DeleteAsync(int id);
    }
}