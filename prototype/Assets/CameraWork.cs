using UnityEngine;
using System.Collections;

public class CameraWork : MonoBehaviour {
    public GameObject Player;
	// Use this for initialization
	void Start () {
        Player=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z - 11);
	}
}
