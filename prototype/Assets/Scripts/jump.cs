using UnityEngine;
using System.Collections;

public class jump : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision col)
    {
        col.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
    }
}
