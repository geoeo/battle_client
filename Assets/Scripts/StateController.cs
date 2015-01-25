using UnityEngine;
using System.Collections;
using Animation;

public class StateController : MonoBehaviour {

	public AnimationManager mAnimationManager;
	public StateMessageDispatcher mStateMessagDispatcher;
	


	// Use this for initialization
	void Start () {
		mStateMessagDispatcher.SendIdle();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.D) && !mAnimationManager.isJumpActive){
			if(!mAnimationManager.IsAnimationBeingPlayedOnTrack("walk",0))
				mAnimationManager.SetAnimationOnTrack("walk",0,false);	
			mAnimationManager.MoveRight();
			mStateMessagDispatcher.SendWalk();
		} else if(Input.GetKeyUp(KeyCode.D) && !mAnimationManager.isJumpActive){
			if(mAnimationManager.IsTrackEmptyOn(0))
				mAnimationManager.SetAnimationOnTrack("walk_end",0,false);
			else{
				mAnimationManager.skeletonAnimation.state.AddAnimation(0,"walk_end",false,0);
			}
		} else if(Input.GetKey(KeyCode.A) && !mAnimationManager.isJumpActive){
			if(mAnimationManager.dodgeOneShot.IsMoveReadyWith(Time.time)){
				mAnimationManager.isDodgeActive = true;
				mAnimationManager.SetAnimationOnTrack("dodge",0,false);
				mAnimationManager.MoveDodge();
				mAnimationManager.dodgeOneShot.SetNewCallTime(Time.time);
				mStateMessagDispatcher.SendDodge();
			}
		} else if(Input.GetKey(KeyCode.W) && mAnimationManager.IsNotMoving()) {
			mAnimationManager.SetAnimationOnTrack("jump",0,true);
			mAnimationManager.isJumpActive = true;
			mAnimationManager.MoveJump();
			mStateMessagDispatcher.SendJump();
			
		} else if(mAnimationManager.isJumpActive && !mAnimationManager.isLanding && mAnimationManager.rigidBody.velocity.y < 0 && mAnimationManager.skeletonAnimation.transform.position.y < 1.2){
			mAnimationManager.SetAnimationOnTrack("jump_end",0,false);
			mAnimationManager.isLanding = true;
			if(!mAnimationManager.IsDodging())
				mStateMessagDispatcher.SendLanding();
		} else if(mAnimationManager.IsTrackEmptyOn(0) && mAnimationManager.IsNotMoving())  {
			mAnimationManager.SetAnimationOnTrack("idle",0,true);
			mStateMessagDispatcher.SendIdle();
		}
	
		//todo fix landing

	
	}
	
}
