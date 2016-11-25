using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
    float speed = 6.0f;                             // 앞뒤 이동량 초기화
    const float curve = 9.0f;                    // 좌우 이동량(고정)
    bool isJumped;                                  // 점프중인지?
    public GameObject explosion;
    bool isDestroyed;

    void Start ()
    {
        isJumped = false;                           // 점프상태 초기화
        isDestroyed = false;
    }   
    
	void FixedUpdate ()
    {
        //Debug.Log(speed);
        Debug.Log("destroy : " + isDestroyed);


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
            if (transform.rotation.z * 100 < 20)    //좌 기울임
            {
                transform.Rotate(0, 0, 40 * Time.deltaTime);
            }
        }
        else if (transform.rotation.z * 100 > 0)    //기울임 원상복귀
        {
            transform.Rotate(0, 0, -60 * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.RightArrow))         //우이동
        {
            transform.Translate(Vector3.right * amtCurve);
            if (transform.rotation.z * 100 > -20)   //우 기울임
            {
                transform.Rotate(0, 0, -40 * Time.deltaTime);
            }
        }
        else if (transform.rotation.z * 100 < 0)    //기울임 원상복귀
        {
            transform.Rotate(0, 0, 60 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space) && isJumped == false)                 // 점프
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 800);
        }
        
       
    }

    void OnCollisionExit (Collision other)                                         // 나 점프했다
    {
        if (other.gameObject.CompareTag("ground"))                     // 바닥(tag가 ground인것)에서 점프할때만
            isJumped = true;
        Debug.Log(isJumped);

    }

    void OnCollisionStay (Collision other)                                       // 나 착지했다
    {   
        if (other.gameObject.CompareTag("ground"))
            isJumped = false;
        Debug.Log(isJumped);

    }

    void FastMove ()                                  // fast 발판 밟을때
    {
        speed = 100.0f;
    }

    void ResetSpeed()                                // fast 발판 빠져나올때                         
    {
        speed = 60.0f;
    }

    void DragToPlanet(Vector3 direction)            // planet의 trigger안에 들어갔을때
    {
        transform.Translate(direction);
    }

    void DestroyByCollision()
    {
        if (speed >= 40.0f)
        {
            isDestroyed = true;
            GameObject.Find("Main Camera").SendMessage("IsDestroyed");
            GameObject.Find("GameManager").SendMessage("Destroy");
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
            Debug.Log(isDestroyed);
        }
    }

}