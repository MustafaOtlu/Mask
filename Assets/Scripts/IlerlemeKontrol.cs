
using UnityEngine;

public class IlerlemeKontrol : MonoBehaviour
{
    const string PROGRESS_KEY = "IlerlemeIndex";

    public int IlerlemeIndex { get; private set; }
    public int index;

    void Start()
    {
        IlerlemeIndex = PlayerPrefs.GetInt(PROGRESS_KEY, 0);
    }


    public void IndexAyarla(int girilenDeger)
    {
        IlerlemeIndex = Mathf.Max(1, girilenDeger);
        PlayerPrefs.SetInt(PROGRESS_KEY, IlerlemeIndex);
        PlayerPrefs.Save();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IndexAyarla(index);
        }
    }
}
