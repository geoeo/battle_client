using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

	public LayerMask groundMask;
	public AnimationController animationController;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision c){
		if((groundMask.value & 1<<c.gameObject.layer) != 0)
			animationController.HasLanded();	
	}
}
