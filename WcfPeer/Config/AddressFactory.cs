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
			return Client<T>("localhost");//Dns.GetHostName());
		}

		public virtual string Client<T>(string host){
			var name = typeof(T).Name;
			if(typeof(T).IsInterface)
				name = name.Substring(1);
			var addr = string.Format("net.tcp://{0}:{1}/{2}",
			                     host,
			                     port,
			                     name);
			Console.WriteLine("Address " + addr);
			return addr;
		}

		public static AddressFactory Default = 
			new AddressFactory(new Random(1).Next() % 64000 + 1024);
	}
}

