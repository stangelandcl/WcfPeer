using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;
using System.ServiceModel.Description;

namespace WcfPeer
{
	public class MultiServiceHost
	{
		List<ServiceHost> services = new List<ServiceHost>();
		ConnectionFactory connection;
		public MultiServiceHost(ConnectionFactory f){
			this.connection = f;
		}

		public virtual void Add<T>(){
			var host = new ServiceHost(typeof(T));
			host.Description.Behaviors.Add(new ServiceThrottlingBehavior () {
				MaxConcurrentCalls=int.MaxValue, 
				MaxConcurrentInstances=int.MaxValue,
				MaxConcurrentSessions = int.MaxValue
			});
			var interfaceType = typeof(T).GetInterfaces().First();
			var ep = host.AddServiceEndpoint(interfaceType, connection.BindingFactory.New(), connection.AddressFactory.Server<T>()); 
			foreach(var behavior in connection.BehaviorFactory.Behaviors)
				ep.Behaviors.Add(behavior);
			services.Add(host);
		}

		public virtual void Open(){
			foreach(var host in services)
				host.Open();
		}

		public virtual void Close(){
			foreach(var host in services)
				host.Close();
		}

		public static MultiServiceHost Default = new MultiServiceHost(ConnectionFactory.Default);			
	}
}

