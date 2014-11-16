using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public SkeletonAnimation skeletonAnimation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		skeletonAnimation.AnimationName = "walk";
	
	}
}
