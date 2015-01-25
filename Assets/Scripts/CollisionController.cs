using UnityEngine;
using System.Collections;
using Animation;

public class CollisionController : MonoBehaviour {

	public LayerMask groundMask;
	public AnimationManager animationManager;
	public StateMessageDispatcher mStateMessageDispatcher;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision c){
		if((groundMask.value & 1<<c.gameObject.layer) != 0){
			animationManager.HasLanded();
			mStateMessageDispatcher.SendLanded();
		}	
	}
}
