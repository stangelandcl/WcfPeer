using System;
using System.Net;

namespace WcfPeer
{
	public class AddressFactory
	{
		public AddressFactory (int port)
		{
			this.port = port;
		}
		int port;

		public virtual string Server<T>(){
			return Client<T>(Dns.GetHostName());
		}

		public virtual string Client<T>(string host){
			return string.Format("net.tcp://{0}:{1}/{2}",
			                     host,
			                     port,
			                     typeof(T).Name);
		}

		public static AddressFactory Default = new AddressFactory(new Random().Next() % 64000 + 1024);
	}
}

