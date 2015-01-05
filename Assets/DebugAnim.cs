using UnityEngine;
using System.Collections;

public class DebugAnim : MonoBehaviour {

public SkeletonAnimation skeletonAnimation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Debug.Log ("" + skeletonAnimation.state.Data.skeletonData.bones[0].X);
		
	
	}
}
