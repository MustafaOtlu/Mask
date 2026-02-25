using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  public void sahneYukle(int index)
    {
        SceneManager.LoadScene(index);
    }
}
