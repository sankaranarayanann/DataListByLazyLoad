using System.Threading.Tasks;
using LazyLoadDataList.Data.Model;

namespace LazyLoadDataList.Data.ViewModel.Contract
{
    /// <summary>
    /// Interface for MainViewModel
    /// </summary>
    public interface IMainViewModel
    {
        /// <summary>
        /// Contract for Method to get json data
        /// </summary>
        /// <returns></returns>
        Task<Facts> GetJsonData();
    }
}