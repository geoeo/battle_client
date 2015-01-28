// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;
using Utils;

namespace MH_Animation {

	public class AnimationManager : MonoBehaviour
	{
		public SkeletonAnimation skeletonAnimation;
		public float speed;
		public Rigidbody rigidBody;
		
		public string lastPlayedAnimation;
		public bool isDodgeActive;
		public bool isJumpActive;
		public bool isLanding;
		public OneShot dodgeOneShot;
	
		void Start()
		{
			
			lastPlayedAnimation = string.Empty;
			dodgeOneShot = new OneShot(2,-5);
			isDodgeActive = false;
			isJumpActive = false;
			rigidBody.freezeRotation = true;
			isLanding = false;
		}
			
		public void SetAnimationOnTrack(string animationName,int track, bool looping)
		{
			if(animationName.Equals(lastPlayedAnimation))
				return;
			skeletonAnimation.state.SetAnimation(track,animationName,looping);
			lastPlayedAnimation = animationName;
			
		}
			
		public bool IsAnimationBeingPlayedOnTrack(string animationName, int track){
			
			if(skeletonAnimation.state.GetCurrent(track) == null)
				return false;
			
			return skeletonAnimation.state.GetCurrent(track).Animation.Name.Equals(animationName);	
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
	
		public bool IsTrackEmptyOn (int track)
		{
			return skeletonAnimation.state.GetCurrent(track) == null;
		}
		
		public void MoveRight ()
		{
			Vector3 position = rigidBody.position;
			position.x += speed;
			rigidBody.position = position;
		}
		
		public void MoveDodge ()
		{
			rigidBody.AddForce(Vector3.up * 100);
			rigidBody.AddForce(Vector3.left * 200);	
		}
		
		public void MoveJump(){
			rigidBody.AddForce(Vector3.up *350);
		}
		
		public bool IsNotMoving(){
			return !(isDodgeActive || isJumpActive || isLanding); 
		}
		
		public bool IsDodging() {
			return isDodgeActive;
		}
	
	}
}


