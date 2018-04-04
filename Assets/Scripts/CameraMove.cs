// 功能:
// 挂载对象: 摄像机
//注意:
using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
	// 摄像机移动速度
	public float moveSpeed = 3f;
	// 摄像机旋转速度
	public float turnSpeed = 10f;
	//玩家
	private Transform player;
	//玩家与摄像机之间的偏移量
	private Vector3 Direction;
	// 射线碰撞信息
	private  RaycastHit hit;
	// 摄像机与玩家距离
	private float distance;
	// 摄像机观察点
	private Vector3[] currentPoints;
    
	void Awake ()
	{
		player = GameObject.FindWithTag ("Player").transform;
		currentPoints = new Vector3[5];
		print("1234");//网站中更改
	}

	void Start ()
	{
		//游戏开始时摄像机与玩家的距离
		distance = Vector3.Distance (transform.position, player.position);
		//玩家与摄像机之间的偏移量
		Direction = player.position - transform.position;
	}

	void LateUpdate ()
	{
		//摄像机的第一个点
		Vector3 startPosition = player.position - Direction;
		//摄像机的最后一个点
		Vector3 endPositon = player.position + Vector3.up * distance;
		////摄像机的第二个点
		currentPoints [1] = Vector3.Slerp (startPosition, endPositon, 0.25f);
		/// 摄像机的第三个点
		currentPoints [2] = Vector3.Slerp (startPosition, endPositon, 0.5f);
		/// 摄像机的第四个点
		currentPoints [3] = Vector3.Slerp (startPosition, endPositon, 0.75f);
		//摄像机的第一个点
		currentPoints [0] = startPosition;
		//摄像机的第五个点
		currentPoints [4] = endPositon;
		// 定义一个变量来存储固定帧可以看到玩家的观察点
		Vector3 viewPosition = currentPoints [0];
		for (int i = 0; i < currentPoints.Length; i++) {
			if (CheckView (currentPoints [i])) {
				viewPosition = currentPoints [i];
				break;
			}
		}
		// 把摄像机移动到观察点
		transform.position = Vector3.Lerp (transform.position, viewPosition, Time.deltaTime * moveSpeed);
		SmootRotate ();
	}

	/// <summary>
	/// 检测某个点是否可以看到玩家
	/// </summary>
	/// <returns><c>true</c>, if ciew was checked, <c>false</c> otherwise.</returns>
	/// <param name="pos">Position.</param>
	bool CheckView (Vector3 pos)
	{
		/// 玩家与观察点之间的方向向量
		Vector3 dir = player.position - pos;
		/// 如果射线达到玩家 
		if (Physics.Raycast (pos, dir, out hit)) {
			if (hit.collider.tag =="Player") {
				return true;
			}
		} 
		return false;
	}

	/// <summary>
	/// 摄像机选择的方法
	/// </summary>

	void  SmootRotate ()
	{
		/// 摄像机到玩家的向量
		Vector3 dir = player.position - transform.position;
		/// 要旋转的角度
		Quaternion qua = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.Lerp (transform.rotation, qua, Time.deltaTime * turnSpeed);
		transform.eulerAngles = new Vector3 (transform.eulerAngles.x, 0, 0);
	}
}
