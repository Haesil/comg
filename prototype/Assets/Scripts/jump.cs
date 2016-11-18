using UnityEngine;
using System.Collections;

// 높은 점프하는 발판

public class jump : MonoBehaviour {
    
	void OnCollisionEnter(Collision col)
    {
        col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 2300);
    }

}
