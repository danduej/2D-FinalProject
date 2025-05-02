using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCreditsContro : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void EndCredits()
    {
        SceneManager.LoadScene(0);
    }//เป็นคำลั่งที่ให้ปุ่มBackหน้าEndCredits กลับไปยังSceneMenuที่เลือก
}

