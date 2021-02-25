using Kutuphane.Core.Kutuphane.Utilities.Results;

namespace Kutuphane.Core.Kutuphane.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return logic;
            }

            return null;
        }

        public static IDataResult<object> Run2(params IDataResult<object>[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return logic;
            }
            return null;

        }
    }
}