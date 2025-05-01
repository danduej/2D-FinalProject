using UnityEngine;

public class NextScence : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GO next Scence
            SceneController.instance.NextLevel();

        }
    }
}
