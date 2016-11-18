using UnityEngine;
using System.Collections;

// 속도가 빨라지는 발판

public class fast : MonoBehaviour {

    void OnCollisionStay ()                   // 발판 밟고있는동안 계속 빨라짐 (100f로 설정해놓음)
    {
        GameObject.Find("Player").SendMessage("FastMove");
        
    }

    void OnCollisionExit ()                    // 발판 빠져나가면 속도 원상태 (60f로 설정해놓음)
    {
        GameObject.Find("Player").SendMessage("ResetSpeed");
    }

}
