
namespace TradingStock.Storage.EventStore.Projections
{
    public interface IProjectionContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        void EnableProjection(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="source"></param>
        void EnsureProjection(string name, string source);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="projectionName"></param>
        /// <returns></returns>
        T GetState<T>(string projectionName);
    }
}
