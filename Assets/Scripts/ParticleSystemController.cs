using UnityEngine;
using System.Collections;
using Utils;

public class ParticleSystemController : MonoBehaviour {

	public ParticleSystem particleSystem;
	private OneShot particleOneShot;

	// Use this for initialization
	void Start () {
		particleOneShot = new OneShot(1,0);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey(KeyCode.F)&& particleOneShot.IsMoveReadyWith(Time.time))
			particleSystem.Emit(1);
	
	}
}
