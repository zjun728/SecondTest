// 功能:
// 挂载对象:GameController
//注意:
using UnityEngine;
using System.Collections;

public class LastPlayerSighting : MonoBehaviour
{

	//	public float CurrentPos = 2f;
	//	public float LastPos = 0f;
	//	AudioSource m_BackGroundMusic;
	//	GameObject[] m_AlarmGam;
	//	AudioSource[] m_AlarmMusic;
	//
	//	void Awake ()
	//	{
	//		m_BackGroundMusic = GetComponent<AudioSource> ();
	//		m_BackGroundMusic.Stop ();
	//	}
	//
	//	void Start ()
	//	{
	//
	//		m_AlarmGam = new GameObject[6];
	//		m_AlarmMusic = new AudioSource[6];
	//		m_AlarmGam = GameObject.FindGameObjectsWithTag (Tags.Siren);
	//
	//		for (int i = 0; i < m_AlarmGam.Length; i++) {
	//			m_AlarmMusic [i] = m_AlarmGam [i].transform.GetComponent<AudioSource> ();
	//		}
	//
	//		if (CurrentPos == LastPos) {
	//
	//		}
	//
	//	}
	//
	//	void Update ()
	//	{
	//
	//	}

	public Vector3 alarmPosition = new Vector3 (0, 0, 0);
	public Vector3 normalPosition = new Vector3 (0, 0, 0);

	// 警报灯脚本组件
//	private AlarmLight alarmLight;
	//正常背景音乐
	private AudioSource mainAudio;
	// 触发警报后音乐
	private  AudioSource panicAudio;
	//喇叭音乐
	private AudioSource[] alarmAudio;
	// 声音切换速度
	public float turnSpeed = 3f;


	void Awake ()
	{
	//	mainAudio = GetComponent<AudioSource> ();
		//panicAudio = transform.GetChild (0).GetComponent<AudioSource> ();
	}

	void Start ()
	{
		//GameObject[] sirens = GameObject.FindGameObjectsWithTag (Tags.Siren);
		////给数组赋值
		//alarmAudio = new AudioSource[sirens.Length];
		//for (int i = 0; i < sirens.Length; i++) {
		//	alarmAudio [i] = sirens [i].GetComponent<AudioSource> ();
		//}
		//alarmLight = GameObject.FindWithTag (Tags.AlarmLight).GetComponent<AlarmLight> ();
	}

	void Update ()
	{
		//如果没有触发新的警报
		//if (alarmPosition == normalPosition) {
		//	// 关闭警报灯
		//	alarmLight.alarmOn = false;

		//	//关闭警报喇叭 
		//	for (int i = 0; i < alarmAudio.Length; i++) {
		//		alarmAudio [i].volume = Mathf.Lerp (
		//			alarmAudio [i].volume, 0, Time.deltaTime * turnSpeed
		//		);

		//		if (alarmAudio [i].volume <= 0.05f) {
		//			alarmAudio [i].volume = 0;
		//		}
		//	}
		//	//正常的背景音乐加大
		//	mainAudio.volume = Mathf.Lerp (mainAudio.volume, 1, Time.deltaTime * turnSpeed);
		//	if (mainAudio.volume >= 0.98f) {
		//		mainAudio.volume = 0.5f;
		//	}

		//	//触发后警报后的音乐音量变小
		//	panicAudio.volume = Mathf.Lerp (panicAudio.volume, 0, Time.deltaTime * turnSpeed);
		//	if (panicAudio.volume <= 0.05f) {
		//		panicAudio.volume = 0f;
		//	}
		//} else {
		//	// 开启警报灯
		//	alarmLight.alarmOn = true;

		//	//开启警报喇叭 
		//	for (int i = 0; i < alarmAudio.Length; i++) {
		//		alarmAudio [i].volume = Mathf.Lerp (
		//			alarmAudio [i].volume, 1, Time.deltaTime * turnSpeed
		//		);

		//		if (alarmAudio [i].volume <= 0.95f) {
		//			alarmAudio [i].volume = 0.5f;
		//		}
		//	}
		//	//正常的背景音乐变小
		//	mainAudio.volume = Mathf.Lerp (mainAudio.volume, 0, Time.deltaTime * turnSpeed);
		//	if (mainAudio.volume <= 0.05f) {
		//		mainAudio.volume = 0f;
		//	}
		//	//触发后警报后的音乐音量变大
		//	panicAudio.volume = Mathf.Lerp (panicAudio.volume, 1, Time.deltaTime * turnSpeed);
		//	if (panicAudio.volume <= 0.95f) {
		//		panicAudio.volume = 0.5f;
		//	}
		//}
	}

}
