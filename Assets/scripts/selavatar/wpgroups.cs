using UnityEngine;
using System.Collections;

public class wpgroups : MonoBehaviour {

	public static wpgroups obj = null;
	public Transform[] weapons;
	
	void Awake ()   
	{
		obj = this;
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
