using UnityEngine;
using System.Collections;

public class upsidedown : MonoBehaviour {

    void OnTriggerStay()
    {
        GameObject.Find("Main Camera").SendMessage("UpsideDown");

    }

    void OnTriggerExit()
    {
        GameObject.Find("Main Camera").SendMessage("Reset");

    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
