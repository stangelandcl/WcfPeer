using System;

namespace WcfPeer
{
	public class ConnectionFactory
	{
		public AddressFactory  AddressFactory  {get;set;}
		public BehaviorFactory BehaviorFactory {get;set;}
		public BindingFactory  BindingFactory  {get;set;}

		public static ConnectionFactory Default = new ConnectionFactory{
			AddressFactory = AddressFactory.Default,
			BehaviorFactory = BehaviorFactory.Default,
			BindingFactory = BindingFactory.Default,
		};
	}
}

