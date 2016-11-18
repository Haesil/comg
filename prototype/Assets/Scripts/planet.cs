using UnityEngine;
using System.Collections;

// 중력이 있는 행성

public class planet : MonoBehaviour {

    float distance;                                         // 행성 ~ player 거리   (거리가 가까워질수록 중력 크게하기 위해)
    Vector3 direction;                                   // 행성으로 끌려가는 방향
    GameObject player;

    void OnTriggerStay(Collider other)                  // 행성의 Trigger안에 들어와있는 동안
    {
        if (other.CompareTag("Player"))                  // trigger 작동은 Player에만 한정
        {
            distance = Vector3.Distance(gameObject.transform.position, player.transform.position);              // 거리 업데이트
            direction = gameObject.transform.position - other.gameObject.transform.position;                       // 방향 업데이트
            direction = Vector3.Normalize(direction);                                                                                           // 정규화
        
            if (distance > 33)                                                                           // 거리가 가까워짐에 따라 중력을 3단계에 걸쳐 커지게 함
            {
                direction *= 0.2f;
                player.SendMessage("DragToPlanet", direction);
            }
            else if (distance > 21)
            {
                direction *= 0.28f;
                player.SendMessage("DragToPlanet", direction);
            }
            else
            {
                direction *= 0.36f;
                player.SendMessage("DragToPlanet", direction);
            }
        }
    }
    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, -1.0f, 0) * 3.5f;                                // 위성들 계속 돌게함
    }

}
