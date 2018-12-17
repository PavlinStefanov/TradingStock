using EventStore.ClientAPI.Common.Log;
using EventStore.ClientAPI.Projections;
using System;
using System.Collections.Generic;
using System.Text;
using TradingStock.Storage.EventStore.EsContext;

namespace TradingStock.Storage.EventStore.Projections
{
    public class ProjectionContext : IProjectionContext
    {
        private readonly ProjectionsManager _projections;
        public List<Projection> _currentProjections { get; set; }

        public ProjectionContext()
        {
            var logger = new ConsoleLogger();
            _projections = new ProjectionsManager(logger, IPEndPointFactory.DefaultHttp(), TimeSpan.FromMilliseconds(6000));
            //_currentProjections = GetCurrentProjectionsAsync();
        }

        public async void GetCurrentProjectionsAsync()
        {
            var all = await _projections.ListAllAsync(EventStoreCredentials.Default);
            //var json = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(all);

            foreach (var projection in all)
            {
                var newProjection = new Projection(projection.Name, projection.Status);
                _currentProjections.Add(newProjection);
            }
        }

        public void EnableProjection(string name)
        {
            throw new NotImplementedException();
        }

        public void EnsureProjection(string name, string source)
        {
            throw new NotImplementedException();
        }

        public T GetState<T>(string projectionName)
        {
            throw new NotImplementedException();
        }
    }
}
