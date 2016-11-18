using UnityEngine;
using System.Collections;

// Player를 따라가는 카메라

public class CameraWork : MonoBehaviour {
    GameObject Player;
    Vector3 cameraPosition;                             // 카메라 현재위치
    Vector3 direction;                                       // Player의 움직임에 따른 방향벡터

    // Use this for initialization
    void Start () {
        Player=GameObject.Find("Player");
        cameraPosition = new Vector3(Player.transform.position.x, Player.transform.position.y + 6, Player.transform.position.z - 8);    // 카메라 위치 초기화
    }
	
	void FixedUpdate ()
    {
        direction = Player.transform.position + new Vector3(0f, 6.0f, -8.0f) - cameraPosition;          // 방향벡터 업데이트
        transform.position += direction * 0.15f;                                // 자연스러움, 속도감을 위해 Player의 움직인 거리의 0.15배 만큼씩만 매프레임마다 이동
        cameraPosition = transform.position;                                     // 카메라 위치 업데이트
	}

    void UpsideDown()
    {
        transform.rotation = Quaternion.Euler(15.0f, 0.0f, 180.0f);        // 카메라 뒤집기
    }

    void Reset()
    {
        transform.rotation = Quaternion.Euler(15.0f, 0.0f, 0.0f);                  // 카메라 원위치

    }
}
