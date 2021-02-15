namespace Kutuphane.Core.Kutuphane.Utilities.Results
{
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}