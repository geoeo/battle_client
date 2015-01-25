using UnityEngine;
using System.Collections;
using System.Text;
using Network;

public class StateMessageDispatcher : MonoBehaviour {

	readonly string url = "http://localhost:8080";
	readonly string data = "{\"name\":\"marc\",\"data\":\"hello hello\"}";
	readonly UTF8Encoding encoding = new UTF8Encoding();
	bool sending;
	
	void Start(){
		sending = false;
	}


	// Use this for initialization
	void Update() {
		var jsonToBeSent = SimpleJsonFactory.CreateNetworkJson();
		
		if(!sending){
		
			if(Input.GetKey(KeyCode.R)){
				sending = true;
				WWW req = new WWW(url,encoding.GetBytes(jsonToBeSent.ToString()));
				StartCoroutine(WaitForRequest(req));
			}	
		}
		
	}
	
	public void SendIdle(){
		var jsonToBeSent = SimpleJsonFactory.CreateNetworkJson();
		
		jsonToBeSent["playerData"]["stateCtrl"] = "moving";
		jsonToBeSent["playerData"]["playerAction"]["action"] = "idle";
		
		WWW req = new WWW(url,encoding.GetBytes(jsonToBeSent.ToString()));
		StartCoroutine(WaitForRequest(req));
		
	
	}
	
	public void SendDodge(){
		var jsonToBeSent = SimpleJsonFactory.CreateNetworkJson();
		
		jsonToBeSent["playerData"]["stateCtrl"] = "moving";
		jsonToBeSent["playerData"]["playerAction"]["action"] = "dodging";
		
		WWW req = new WWW(url,encoding.GetBytes(jsonToBeSent.ToString()));
		StartCoroutine(WaitForRequest(req));
		
		
	}
	
	public void SendJump(){
		var jsonToBeSent = SimpleJsonFactory.CreateNetworkJson();
		
		jsonToBeSent["playerData"]["stateCtrl"] = "jumping";
		jsonToBeSent["playerData"]["playerAction"]["action"] = "jumping";
		
		WWW req = new WWW(url,encoding.GetBytes(jsonToBeSent.ToString()));
		StartCoroutine(WaitForRequest(req));
			
	}
	
	public void SendLanding(){
		var jsonToBeSent = SimpleJsonFactory.CreateNetworkJson();
		
		jsonToBeSent["playerData"]["stateCtrl"] = "jumping";
		jsonToBeSent["playerData"]["playerAction"]["action"] = "landing";
		
		WWW req = new WWW(url,encoding.GetBytes(jsonToBeSent.ToString()));
		StartCoroutine(WaitForRequest(req));
		
	}
	
	public void SendLanded(){
		var jsonToBeSent = SimpleJsonFactory.CreateNetworkJson();
		
		jsonToBeSent["playerData"]["stateCtrl"] = "jumping";
		jsonToBeSent["playerData"]["playerAction"]["action"] = "landed";
		
		WWW req = new WWW(url,encoding.GetBytes(jsonToBeSent.ToString()));
		StartCoroutine(WaitForRequest(req));
		
	}
	
	public void SendWalk(){
		var jsonToBeSent = SimpleJsonFactory.CreateNetworkJson();
		
		jsonToBeSent["playerData"]["stateCtrl"] = "jumping";
		jsonToBeSent["playerData"]["playerAction"]["action"] = "jumping";
		
		WWW req = new WWW(url,encoding.GetBytes(jsonToBeSent.ToString()));
		StartCoroutine(WaitForRequest(req));
		
	}
	
	IEnumerator WaitForRequest(WWW www){
	
		yield return www;	
		
		sending = false;
		if(www.error == null){
			Debug.Log("OK: " + www.text); 
			foreach(var header in www.responseHeaders){
				Debug.Log("header: "+ header);
			}
		} else {
			Debug.Log("Error: " + www.error); 
		}	
	
	}
	

}
