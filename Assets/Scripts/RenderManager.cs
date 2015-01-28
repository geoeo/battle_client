using UnityEngine;
using System.Collections;
using Utils;

public class RenderManager : MonoBehaviour {

	OneShot selfHide;
	public float displayTime;
	// Use this for initialization
	void Start () {
	
		var spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
		spriteRenderer.color = new Color(1f,1f,1f,0.4f);
		selfHide = new OneShot(displayTime-1f,Time.time);
	}
	
	void FixedUpdate() {
		if(this.gameObject.activeSelf && selfHide.IsMoveReadyWith(Time.time)){
			selfHide = new OneShot(displayTime,Time.time);
			this.gameObject.SetActive(false);
		}
			
	}
	

}
