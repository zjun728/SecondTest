// 功能:
// 挂载对象:敌人 Enemy
//注意:
using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
	// 敌人是否可以看到玩家
	public bool playerInSinght = false;
	// 机器人视野夹角
	public float filedOfView = 110f;
	//机器人视野距离
	private float distanceOfView;
	// 机器人身上的球形触发器
	private SphereCollider sph;
	// 机器人私有警报位置
	public Vector3 personalAlarmPosition;
	// 机器人前一个警报位置
	public Vector3 previousAlarmPosition;

	private RaycastHit hit;
	private UnityEngine.AI.NavMeshAgent nav;
	private float playerHeath;
	private Animator ani;
	LastPlayerSighting lastPlayerSinhting;

	void Awake ()
	{
		sph = GetComponent<SphereCollider> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		ani = GetComponent<Animator> ();
	}

	void  Start ()
	{
		lastPlayerSinhting = GameObject.FindWithTag ("GameController").
			GetComponent<LastPlayerSighting> ();
		playerHeath = 100f;
		personalAlarmPosition = lastPlayerSinhting.normalPosition;
		previousAlarmPosition = lastPlayerSinhting.normalPosition;
		distanceOfView = sph.radius;
	}

	void Update ()
	{
		//公共的警报位置发生改变 表示玩家触发了新的公共警报 
		// 此时把该警报传递给机器人的私有警报位置
		if (previousAlarmPosition != lastPlayerSinhting.alarmPosition) {
			personalAlarmPosition = lastPlayerSinhting.alarmPosition;
		}
		previousAlarmPosition = lastPlayerSinhting.alarmPosition;
		//玩家血量大于0
		if (playerHeath> 0) {
		//	ani.SetBool (HashID.playerInSight, playerInSinght);
		} else {
		//	ani.SetBool (HashID.playerInSight, false);
		}
	}

	void OnTriggerStay (Collider other)
	{
		// 如果玩家在触发范围内
		if (other.tag == "Player") {

            print("触发开始");
			playerInSinght = false;
			float distance = Vector3.Distance (other.transform.position, transform.position);
			//玩家与机器人的方向向量
			Vector3 dir = other.transform.position - transform.position;
			// 小机器人正前方与dir之间的角度
			float angular = Vector3.Angle (transform.forward, dir);
            if (angular < filedOfView / 2 && distance < distanceOfView)
            {
                if (Physics.Raycast(transform.position, dir, out hit))
                {
                    if (hit.collider.tag == "Player")
                    {
                        playerInSinght = true;
                        personalAlarmPosition = other.transform.position;
                    }
                }
            }
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player") {
            print("触发离开");
            playerInSinght = false;
            personalAlarmPosition = lastPlayerSinhting.normalPosition;
        }
	}
}
