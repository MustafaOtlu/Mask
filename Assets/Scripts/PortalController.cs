using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalController : MonoBehaviour
{
    public int index = 1;
    const string PROGRESS_KEY = "IlerlemeIndex";

    public int IlerlemeIndex { get; private set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(index);
            IlerlemeIndex = Mathf.Max(1, 4);
            PlayerPrefs.SetInt(PROGRESS_KEY, IlerlemeIndex);
            PlayerPrefs.Save();
        }
    }
}
