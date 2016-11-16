using UnityEngine;
using System.Collections;

public class CameraWork : MonoBehaviour {
    GameObject Player;
	// Use this for initialization
	void Start () {
        Player=GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z - 8);
	}

    void UpsideDown()
    {
        transform.rotation = Quaternion.Euler(10.0f, 0.0f, 180.0f);
    }

    void Reset()
    {
        transform.rotation = Quaternion.Euler(10.0f, 0.0f, 0.0f);

    }
}
