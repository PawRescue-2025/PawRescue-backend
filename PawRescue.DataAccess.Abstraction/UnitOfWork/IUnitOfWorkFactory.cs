namespace PawRescue.DataAccess.Abstraction.UnitOfWork;

public interface IUnitOfWorkFactory
{
    IUnitOfWork CreateUnitOfWork();
}
