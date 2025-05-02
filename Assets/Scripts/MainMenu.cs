using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor; // ใช้สำหรับหยุด Play Mode ใน Unity Editor
#endif

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Scene ที่จะวาปไป
    }

    public void OpenOptions()
    {
        Debug.Log("Options Menu Opened");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // หยุด Play Mode ถ้าอยู่ใน Editor
        #else
        Application.Quit(); // ใช้เมื่อ Build เป็นไฟล์เกมจริง
        #endif
    }
}
