using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Linq;

namespace WcfPeer
{
	public class MultiServiceHost
	{
		List<ServiceHost> services = new List<ServiceHost>();
		BindingFactory binding;
		AddressFactory address;
		BehaviorFactory behaviors;
		public MultiServiceHost(BindingFactory binding, AddressFactory address, BehaviorFactory behaviors){
			this.binding = binding;
			this.address = address;
			this.behaviors = behaviors;
		}

		public virtual void Add<T>(){
			var host = new ServiceHost(typeof(T));
			var interfaceType = typeof(T).GetInterfaces().First();
			var ep = host.AddServiceEndpoint(interfaceType, binding.New(), address.Server<T>()); 
			foreach(var behavior in behaviors.Behaviors)
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

		public static MultiServiceHost Default = new MultiServiceHost(
			BindingFactory.Default,
			AddressFactory.Default,
			BehaviorFactory.Default);
	}
}

