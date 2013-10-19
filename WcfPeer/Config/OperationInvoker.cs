using System;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace WcfPeer
{
	public class OperationInvoker : IOperationInvoker
	{
		IOperationInvoker invoker;
		public OperationInvoker (IOperationInvoker invoker)
		{
			this.invoker = invoker;
		}

		#region IOperationInvoker implementation

		public object[] AllocateInputs ()
		{
			return this.invoker.AllocateInputs();
		}

		public object Invoke (object instance, object[] inputs, out object[] outputs)
		{
			return this.invoker.Invoke(instance, inputs, out outputs);
		}

		public IAsyncResult InvokeBegin (object instance, object[] inputs, AsyncCallback callback, object state)
		{
			return this.invoker.InvokeBegin(instance, inputs, callback, state);
		}

		public object InvokeEnd (object instance, out object[] outputs, IAsyncResult result)
		{
			return this.invoker.InvokeEnd(instance, out outputs, result);
		}

		public bool IsSynchronous {
			get {
				return this.invoker.IsSynchronous;
			}
		}

		#endregion
	}

	

	public class OperationAttribute : Attribute, IOperationBehavior
	{
		public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
		{
		}

		public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
		{
		}

		public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
		{
			dispatchOperation.Invoker = dispatchOperation.Invoker;
		}

		public void Validate(OperationDescription operationDescription)
		{
		}
	}


}

