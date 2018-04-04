// 功能:
// 挂载对象:
//注意:
using UnityEngine;
using System.Collections;

public class LaserController : MonoBehaviour
{
	private LastPlayerSighting lasterPlayerSinghting;

	void Start ()
	{
		lasterPlayerSinghting = GameObject.FindWithTag ("GameController").GetComponent<LastPlayerSighting> ();
        
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			lasterPlayerSinghting.alarmPosition = other.transform.position;
		}
	}
}
