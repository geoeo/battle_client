// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
namespace Utils
{
		public class OneShot
		{
			private float timerInSeconds;
			private float timeOfMostRecentCall;
			
			public OneShot(float timerInSeconds,float initialTime){
				this.timerInSeconds = timerInSeconds;
				timeOfMostRecentCall = initialTime;
			}
			
			public float GetTimeOfMostRecentCall(){
				return timeOfMostRecentCall;
			}
			
			public float GetTimerInSeconds(){
				return timerInSeconds;
			}
			
			public void SetNewCallTime(float time){
				timeOfMostRecentCall = time;
			}
			
			public bool IsMoveReadyWith(float currentTime){
				return currentTime > timeOfMostRecentCall + timerInSeconds;
			}
		}
}

