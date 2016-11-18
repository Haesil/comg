using UnityEngine;
using System.Collections;

// 화면이 뒤집어지는 발판

public class upsidedown : MonoBehaviour {

    void OnTriggerStay()
    {
        GameObject.Find("Main Camera").SendMessage("UpsideDown");
    }

    void OnTriggerExit()
    {
        GameObject.Find("Main Camera").SendMessage("Reset");

    }

}
