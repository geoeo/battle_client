using UnityEngine;
using System.Collections;
using System.Text;

public class SimplePostRequest : MonoBehaviour {

	readonly string url = "http://localhost:8080";
	readonly string data = "{\"name\":\"marc\",\"data\":\"hello hello\"}";
	readonly UTF8Encoding encoding = new UTF8Encoding();
	bool sending;
	
	void Start(){
		sending = false;
	}


	// Use this for initialization
	void Update() {
	
		if(Input.GetKey(KeyCode.R)&& !sending){
			sending = true;
			WWW req = new WWW(url,encoding.GetBytes(data));
			StartCoroutine(WaitForRequest(req));
		}

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
