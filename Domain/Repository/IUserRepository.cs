namespace XianlitiCN.PraesentiaBackend.Domain.Repository;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(long id);
}