using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    float speed = 5.0f;
    float curve = 3.0f;
    Rigidbody myRigidbody;
    //bool notSpeedCtrl = false;


    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.gameObject.name);
        if (collider.gameObject.name == "accel")
        {
            speed += 12.0f;
            //speed = 5.0f;
            //notSpeedCtrl = true;
        }
        else if (collider.gameObject.name == "jump")
        {
            myRigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
        
    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.name == "Cube")
    //    {
    //        notSpeedCtrl = false;
    //    }
    //}
    // Update is called once per frame
    void Update () {
        float amtMove = speed * Time.deltaTime;
        float amtCurve = curve * Time.deltaTime;

        transform.Translate(Vector3.forward * amtMove);
        Debug.Log(speed);
        if (Input.GetKey(KeyCode.UpArrow) && speed < 50.0f/*&& notSpeedCtrl == false*/)         //가속
        {
            Debug.Log(speed);
            speed += 0.1f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && speed > 3.0f/*&& notSpeedCtrl == false*/)         //감속
        {
            Debug.Log(speed);
            speed -= 0.1f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && speed < 50.0f)         //좌이동
        {
            transform.Translate(Vector3.left * amtCurve);
        }

        if (Input.GetKey(KeyCode.RightArrow) && speed < 50.0f)         //우이동
        {
            transform.Translate(Vector3.right * amtCurve);
        }

    }
}
