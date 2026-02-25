using UnityEngine;

public class Toy : MonoBehaviour
{
    public GameObject bul;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            TextKontrolu._isTakenToy = true;
            bul.SetActive(false);
        }
    }
}
