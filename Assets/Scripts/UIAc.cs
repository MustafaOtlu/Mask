using UnityEngine;

public class UIAc : MonoBehaviour
{
    public GameObject panel;


    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }
}
