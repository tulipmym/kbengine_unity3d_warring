using UnityEngine;
using System;
using System.Collections;
using KBEngine;

public class clientapp : MonoBehaviour {
	public static KBEngineApp gameapp = null;
	
	void Awake() 
	 {
		DontDestroyOnLoad(transform.gameObject);
	 }
 
	// Use this for initialization
	void Start () {
		MonoBehaviour.print("clientapp::start()");
			
		gameapp = new KBEngineApp();
		gameapp.clientType = 3;
		//gameapp.createAccount_loginapp(true);
		// gameapp.login_loginapp(true);
		
		gameapp.autoImportMessagesFromServer(true);
	}
	
	void OnDestroy()
	{
		MonoBehaviour.print("clientapp::OnDestroy()");
		gameapp.destroy();
	}
	
	void FixedUpdate () {
		KBEUpdate();
	}
		
	void KBEUpdate()
	{
		KBEngine.Event.processEventsMainThread();
	}
}
