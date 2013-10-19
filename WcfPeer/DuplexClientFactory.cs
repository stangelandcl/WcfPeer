using System;
using System.ServiceModel;

namespace WcfPeer
{
	public class DuplexClientFactory
	{
		public DuplexClientFactory (ConnectionFactory f)
		{
			this.connection = f;
		}
		ConnectionFactory connection;

		public T New<T>(string host, object callback){
			var ep = new EndpointAddress(connection.AddressFactory.Client<T>(host));
			var channel = new DuplexChannelFactory<T>(new InstanceContext(callback),
			                                         connection.BindingFactory.New(),
			                                         ep);
			foreach(var behavior in connection.BehaviorFactory.Behaviors)
				channel.Endpoint.Behaviors.Add(behavior);
			channel.Open();
			return channel.CreateChannel();
		}

		public static DuplexClientFactory Default = new DuplexClientFactory(ConnectionFactory.Default);
	}
}

