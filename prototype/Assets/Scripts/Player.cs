using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
    float speed = 6.0f;                             // 앞뒤 이동값 초기화
    const float curve = 5.5f;                    // 좌우 이동값(고정)
    bool isJumped;                                  // 점프했는지 알려주는 변수

    // Use this for initialization
    void Start ()
    {
        isJumped = false;                           // 점프상태 초기화
    }   
    
	// Update is called once per frame
	void FixedUpdate ()
    {

        //Debug.Log(speed);
        //gameObject.transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);                   // 회전하지 않도록

        if (Input.GetKeyDown(KeyCode.Space) && isJumped == false)                                    // 점프
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 800);
        }

        float amtMove = speed * Time.deltaTime;
        float amtCurve = curve * Time.deltaTime;

        transform.Translate(Vector3.forward * amtMove);

        if (Input.GetKey(KeyCode.UpArrow) && speed < 60.0f)         //가속
        {
            speed += 0.6f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && speed > 6.0f)         //감속
        {
            speed -= 0.6f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))         //좌이동
        {
            transform.Translate(Vector3.left * amtCurve);
        }

        if (Input.GetKey(KeyCode.RightArrow))         //우이동
        {
            transform.Translate(Vector3.right * amtCurve);
        }
    }
    
    void OnCollisionExit (Collision other)                                         // 나 점프했다
    {
        if (other.gameObject.CompareTag("ground"))                     // 바닥에서 점프할때만
            isJumped = true;
        Debug.Log(isJumped);

    }

    void OnCollisionEnter (Collision other)                                       // 나 착지했다
    {
        if (other.gameObject.CompareTag("ground"))
            isJumped = false;
        Debug.Log(isJumped);

    }

    void FastMove ()
    {
        speed = 60.0f;
    }

    void DragToPlanet(Vector3 direction)
    {
        transform.Translate(direction);
    }
}
