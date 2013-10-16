using System;
using System.Collections.Generic;
using System.ServiceModel.Description;

namespace WcfPeer
{
	public class BehaviorFactory
	{
		public virtual IEnumerable<IEndpointBehavior> Behaviors {get{
				yield break;
			}
		}

		public static BehaviorFactory Default = new BehaviorFactory();
	}
}

