using System;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace WcfPeer
{
	public class BindingFactory
	{
		public virtual Binding New(){
			var b = new NetTcpBinding();
			b.MaxConnections = 256;
			b.MaxReceivedMessageSize = int.MaxValue;
			b.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
			b.ReaderQuotas.MaxDepth = int.MaxValue;
			b.ReaderQuotas.MaxStringContentLength = int.MaxValue;
			b.ReaderQuotas.MaxArrayLength = int.MaxValue;
			return b;
		}

		public static BindingFactory Default = new BindingFactory();
	}
}

