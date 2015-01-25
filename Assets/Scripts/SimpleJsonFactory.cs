using Newtonsoft.Json.Linq;

namespace Network
{
	public class SimpleJsonFactory
	{
	
		public static JObject CreateNetworkJson(){
		
			var networkObject = new JObject();
			var playerAction = new JObject();
			var action = new JObject();
			
			networkObject.Add(new JProperty("name","marc"));
			networkObject.Add(new JProperty("data","mydata"));	
			networkObject.Add(new JProperty("playerData",playerAction));
			
			playerAction.Add(new JProperty("stateCtrl","some Ctrl"));
			playerAction.Add(new JProperty("playerAction",action));
			
			action.Add(new JProperty("action","someAction"));
			
			return networkObject;
			
		}
	}
}

