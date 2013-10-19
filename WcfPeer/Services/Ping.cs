using System;
using System.ServiceModel;

namespace WcfPeer
{
	[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple,
	                 InstanceContextMode = InstanceContextMode.Single)]
	public class PingService : IPingService
	{
		public byte[] Ping(byte[] packet){
			Console.WriteLine("pinged");
			return packet;
		}
	}

	[ServiceContract]
	public interface IPingService{
		[OperationContract]
		byte[] Ping(byte[] packet);
	}
}

