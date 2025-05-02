using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor; // ������Ѻ��ش Play Mode � Unity Editor
#endif

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1"); // Scene �����һ�
    }

    public void OpenOptions()
    {
        Debug.Log("Options Menu Opened");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");

        #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // ��ش Play Mode �������� Editor
        #else
        Application.Quit(); // ������� Build ���������ԧ
        #endif
    }
}
