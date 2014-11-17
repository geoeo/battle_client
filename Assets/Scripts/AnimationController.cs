using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	public SkeletonAnimation skeletonAnimation;
	public float speed;
	
	private string lastPlayedAnimation;
	private float dodgeTimerInSeconds;
	private float timeOfMostRecentDodge;
	private float durationOfDodge;
	private bool isDodgeActive;


	// Use this for initialization
	void Start () {
	
		lastPlayedAnimation = string.Empty;
		dodgeTimerInSeconds = 2;
		timeOfMostRecentDodge = -5;
		durationOfDodge = 0.3f;
		isDodgeActive = false;
		rigidbody.freezeRotation = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.D)){
			if(!IsAnimationBeingPlayedOnTrack("walk",0))
				SetAnimationOnTrack("walk",0,false);	
			MoveRight ();
		} else if(Input.GetKeyUp(KeyCode.D)){
			if(IsTrackEmptyOn(0))
				SetAnimationOnTrack("walk_end",0,false);
			else{
				skeletonAnimation.state.AddAnimation(0,"walk_end",false,0);
			}
		} else if(Input.GetKey(KeyCode.A)){
			if(isMoveReady(dodgeTimerInSeconds,timeOfMostRecentDodge)){
				SetAnimationOnTrack("dodge",0,false);
				MoveDodge();
				timeOfMostRecentDodge = Time.time;
				isDodgeActive = true;
			}
		} else if(IsTrackEmptyOn(0)) {
			SetAnimationOnTrack("idle",0,true);
		}
		
		if(isDodgeActive && Time.time > timeOfMostRecentDodge + durationOfDodge){
			SetAnimationOnTrack("dodge_end",0,false);
			isDodgeActive = false;
//			rigidbody.freezeRotation =false;
		}
		          
	}

	void SetAnimationOnTrack(string animationName,int track, bool looping)
	{
		if(animationName.Equals(lastPlayedAnimation))
			return;
		skeletonAnimation.state.SetAnimation(track,animationName,looping);
		lastPlayedAnimation = animationName;
	}
	
	bool IsAnimationBeingPlayedOnTrack(string animationName, int track){
		
		if(skeletonAnimation.state.GetCurrent(track) == null)
			return false;
			
		return skeletonAnimation.state.GetCurrent(track).Animation.Name.Equals(animationName);	
	}

	bool IsTrackEmptyOn (int track)
	{
		return skeletonAnimation.state.GetCurrent(track) == null;
	}

	void MoveRight ()
	{
		Vector3 position = rigidbody.position;
		position.x += speed;
		rigidbody.position = position;
	}
	
	void MoveDodge ()
	{
//		rigidbody.freezeRotation = true;
		rigidbody.AddForce(Vector3.up * 100);
		rigidbody.AddForce(Vector3.left * 200);
	
	}
	
	bool isMoveReady(float timer,float timeOfLastExecution){
		return Time.time > timeOfLastExecution + timer;

	}
}
