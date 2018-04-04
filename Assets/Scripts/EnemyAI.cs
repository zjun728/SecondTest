// 功能:
// 挂载对象: 敌人
//注意:
using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
	// 小机器人的巡逻点
	public Transform[] wayPoints;
	// 巡逻速度
	public float patrallingSpeed = 2.5f;
	//追捕速度
	public float chasingSpeed = 6f;
	// 追捕等待计时器
	public float chasingTimer = 0;
	// 巡逻到一个点后等待多长时间到下一个巡逻点
	public float chasingWaitTime = 3f;
	// 巡逻的计时器
	public float patrallingTimer = 0;

	private EnemySight enemySight;

	private LastPlayerSighting lastPlayerSighting;

	private float playerHealth;

	private UnityEngine.AI.NavMeshAgent nav;
	// 导航目标索引值
	private int index = 0;

	void Awake ()
	{
		enemySight = GetComponent<EnemySight> ();
		nav = GetComponent<UnityEngine.AI.NavMeshAgent> ();
	}

	void Start ()
	{
		lastPlayerSighting = GameObject.FindWithTag ("GameController").
			GetComponent<LastPlayerSighting> ();

		playerHealth = 100f;
	}

	void Update ()
	{
		// 如果小机器人 看到玩家 并且玩家没有死亡 
		if (enemySight.playerInSinght && playerHealth> 0) {
			//开始射击 
			Shoot ();
            print("开始射击");
		}
		// 如果小机器人接收到了报警位置, 并且玩家没有死亡
		else if (enemySight.personalAlarmPosition != lastPlayerSighting.normalPosition
		         && playerHealth> 0) {
            //追捕
            print(enemySight.personalAlarmPosition != lastPlayerSighting.normalPosition);
			Chasing ();
            print("追捕");
        }

		// 以上都不符合 继续巡逻
		else {
			Patralling ();
            print("继续巡逻");
        }
	}

	/// <summary>
	/// 射击
	/// </summary>
	void Shoot ()
	{
		nav.Stop ();
	}

	/// <summary>
	/// 追捕
	/// </summary>
	void Chasing ()
	{
		// 恢复导航功能
		nav.Resume ();
		//把外面赋值的速度给导航速度
		nav.speed = chasingSpeed;
		nav.SetDestination (enemySight.personalAlarmPosition);
		// 距离人0.5米的距离时停止 开始射击
		if (nav.remainingDistance - nav.stoppingDistance < 0.5f) {
			// 追捕时间开始计时
			chasingTimer += Time.deltaTime;
			if (chasingTimer > chasingWaitTime) {
				chasingTimer = 0;
                print("重置位置");
                lastPlayerSighting.alarmPosition = lastPlayerSighting.normalPosition;
			}
		} else {
			chasingTimer = 0;
		}
	}

	/// <summary>
	/// 巡逻
	/// </summary>
	void Patralling ()
	{
		// 巡逻速度赋值给导航速度
		nav.speed = patrallingSpeed;
		//设置目标
		nav.SetDestination (wayPoints [index].position);
		// 快到巡逻目标点
		if (nav.remainingDistance - nav.stoppingDistance < 0.5f) {
			// 计时器开始计时
			patrallingTimer += Time.deltaTime;
			// 如果计时器大于巡逻等待时间 开始往下一个目标点走
			if (patrallingTimer > chasingWaitTime) {
				index++;
				index %= wayPoints.Length;
				patrallingTimer = 0;
			}
		} else {
			patrallingTimer = 0;
		
		}
	}
}
