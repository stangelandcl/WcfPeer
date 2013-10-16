using System;
using System.ServiceModel;

namespace WcfPeer
{
	public class ClientFactory
	{
		public ClientFactory (BindingFactory binding, AddressFactory address, BehaviorFactory behaviors)
		{
			this.address = address;
			this.binding = binding;
			this.behaviors = behaviors;
		}

		BindingFactory binding;
		AddressFactory address;
		BehaviorFactory behaviors;

		public virtual T New<T>(string host){
			var ep = new EndpointAddress(address.Client<T>(host));
			var channel = new ChannelFactory<T>(binding.New(),ep);
			foreach(var behavior in behaviors.Behaviors)
				channel.Endpoint.Behaviors.Add(behavior);
			channel.Open();
			return channel.CreateChannel();
		}

		public static ClientFactory Default = new ClientFactory(
			BindingFactory.Default,
			AddressFactory.Default,
			BehaviorFactory.Default);
	}
}

