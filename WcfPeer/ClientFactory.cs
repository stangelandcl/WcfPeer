using System;
using System.ServiceModel;

namespace WcfPeer
{
	public class ClientFactory
	{
		public ClientFactory (ConnectionFactory f)
		{
			this.connection = f;
		}
		protected ConnectionFactory connection;

		public virtual T New<T>(string host){
			var ep = new EndpointAddress(connection.AddressFactory.Client<T>(host));
			var channel = new ChannelFactory<T>(connection.BindingFactory.New(),ep);
			foreach(var behavior in connection.BehaviorFactory.Behaviors)
				channel.Endpoint.Behaviors.Add(behavior);
			channel.Open();
			return channel.CreateChannel();
		}

		public static ClientFactory Default = new ClientFactory(ConnectionFactory.Default);
	}
}

