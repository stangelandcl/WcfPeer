using System;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace WcfPeer
{
	public class BindingFactory
	{
		public virtual Binding New(double timeoutSeconds = 30){
			var b = new NetTcpBinding();
			b.MaxConnections = 256;
			b.ListenBacklog = 256;
			b.SendTimeout = TimeSpan.FromSeconds(timeoutSeconds);
			b.ReceiveTimeout = TimeSpan.FromSeconds(timeoutSeconds);
			//b.MaxBufferSize = 
			//b.MaxBufferPoolSize =
			b.MaxReceivedMessageSize = int.MaxValue;
			if(b.ReaderQuotas != null){
				b.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
				b.ReaderQuotas.MaxDepth = int.MaxValue;
				b.ReaderQuotas.MaxStringContentLength = int.MaxValue;
				b.ReaderQuotas.MaxArrayLength = int.MaxValue;
			}
			return b;
		}

		public static BindingFactory Default = new BindingFactory();
	}
}

