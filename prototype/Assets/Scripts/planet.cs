using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour {

    float distance;                                         // 행성 ~ player 거리
    Vector3 direction;                                   // 행성으로 끌려가는 방향
    GameObject player;

    void OnTriggerStay(Collider other)
    {
        distance = Vector3.Distance(gameObject.transform.position, player.transform.position);              // 거리범위 : 10 ~ 45
        direction = gameObject.transform.position - other.gameObject.transform.position;
        direction = Vector3.Normalize(direction);                                                                                            // 끌려가는 방향 구하고 정규화
        
        if (distance > 33)
        {
            direction *= 0.08f;
            player.SendMessage("DragToPlanet", direction);
        }
        else if (distance > 21)
        {
            direction *= 0.13f;
            player.SendMessage("DragToPlanet", direction);
        }
        else
        {
            direction *= 0.18f;
            player.SendMessage("DragToPlanet", direction);
        }
    }
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
