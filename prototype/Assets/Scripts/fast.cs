using UnityEngine;
using System.Collections;

public class fast : MonoBehaviour {
    void OnCollisionStay (Collision col)
    {
        GameObject.Find("Player").SendMessage("FastMove");
        
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
