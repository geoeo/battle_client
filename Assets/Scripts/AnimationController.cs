using UnityEngine;
using System.Collections;
using Utils;

public class AnimationController : MonoBehaviour {

	public SkeletonAnimation skeletonAnimation;
	public float speed;
	public Rigidbody rigidBody;
	
	private string lastPlayedAnimation;
	private bool isDodgeActive;
	private bool isJumpActive;
	private bool isLanding;
	private OneShot dodgeOneShot;


	// Use this for initialization
	void Start () {
	
		lastPlayedAnimation = string.Empty;
		dodgeOneShot = new OneShot(2,-5);
		isDodgeActive = false;
		isJumpActive = false;
		rigidBody.freezeRotation = true;
		isLanding = false;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.D) && !isJumpActive){
			if(!IsAnimationBeingPlayedOnTrack("walk",0))
				SetAnimationOnTrack("walk",0,false);	
			MoveRight ();
		} else if(Input.GetKeyUp(KeyCode.D) && !isJumpActive){
			if(IsTrackEmptyOn(0))
				SetAnimationOnTrack("walk_end",0,false);
			else{
				skeletonAnimation.state.AddAnimation(0,"walk_end",false,0);
			}
		} else if(Input.GetKey(KeyCode.A) && !isJumpActive){
			if(dodgeOneShot.IsMoveReadyWith(Time.time)){
				SetAnimationOnTrack("dodge",0,false);
				MoveDodge();
				dodgeOneShot.SetNewCallTime(Time.time);
				isDodgeActive = true;
			}
		} else if(Input.GetKey(KeyCode.W) && IsNotMoving()) {
			SetAnimationOnTrack("jump",0,true);
			isJumpActive = true;
			MoveJump();
			
		} else if(IsTrackEmptyOn(0) && IsNotMoving())  {
			SetAnimationOnTrack("idle",0,true);
		}
	
		//todo fix landing
		if(isJumpActive && !isLanding && rigidBody.velocity.y < 0 && skeletonAnimation.transform.position.y < 1.2){
			SetAnimationOnTrack("jump_end",0,false);
			isLanding = true;
		}
	
	}
	
	// Called form CollisionController
	public void HasLanded(){
		if(isJumpActive){
			SetAnimationOnTrack("idle",0,true);
			isJumpActive = false;
			isLanding = false;
		} else if (isDodgeActive){
			SetAnimationOnTrack("dodge_end",0,false);
			isDodgeActive = false;
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
		Vector3 position = rigidBody.position;
		position.x += speed;
		rigidBody.position = position;
	}
	
	void MoveDodge ()
	{
		rigidBody.AddForce(Vector3.up * 100);
		rigidBody.AddForce(Vector3.left * 200);
	
	}
	
	void MoveJump(){
		rigidBody.AddForce(Vector3.up *350);
	}
	
	bool IsNotMoving(){
		return !(isDodgeActive || isJumpActive); 
	}
	
	bool IsDodging() {
		return isDodgeActive;
	}
}
