using UnityEngine;
using System.Collections;

// 위성에 부딪히면 Player Destroy

public class destroyByCollision : MonoBehaviour {

    void OnCollisionEnter (Collision other)                                             
    {
        if (other.gameObject.CompareTag("Player"))                                      // 위성에 닿는것이 Player이면 Destroy
            other.gameObject.SendMessage("Destroy");
    }

}
