using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
    float speed = 3.0f;
    float curve = 4.5f;

    Quaternion initRotation;

    // Use this for initialization
    void Start () {

    }   
	// Update is called once per frame
	void Update ()
    {

        gameObject.transform.rotation = Quaternion.Euler(0.0f,0.0f,0.0f);                   // 회전하지 않도록

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y >= 0.64 && transform.position.y <= 0.66)                                    // 점프
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 250);
        }

        float amtMove = speed * Time.deltaTime;
        float amtCurve = curve * Time.deltaTime;

        transform.Translate(Vector3.forward * amtMove);

        if (Input.GetKey(KeyCode.UpArrow) && speed < 35.0f)         //가속
        {
            speed += 0.3f;
            Debug.Log(speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) && speed > 3.0f)         //감속
        {
            speed -= 0.3f;
            Debug.Log(speed);
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

    void FastMove ()
    {
        speed = 35.0f;
    }
}
