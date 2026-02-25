using UnityEngine;
using UnityEngine.UI;

public class TextKontrolu : MonoBehaviour
{
    public Transform player;
    public Transform character;
    public float algilamaMesafesi = 3f;

    public static bool _isTakenToy;
    const string PROGRESS_KEY = "IlerlemeIndex";
    public int IlerlemeIndex { get; private set; }

    private int index = 0;
    private bool tetiklendi = false;
    private bool açýk;

    public string konusma1;
    public string konusma2;
    public string konusma3;

    public AudioClip au1;

    private Text txt;
    private AudioSource audioSource;
    public GameObject Bul;

    void Start()
    {
        txt = GetComponent<Text>();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.clip = au1;

        txt.text = "";
        IlerlemeIndex = PlayerPrefs.GetInt(PROGRESS_KEY, 0);
       

    }

    void Update()
    {
        float mesafe = Vector3.Distance(player.position, character.position);

        if (mesafe <= algilamaMesafesi)
        {
            if(Input.GetMouseButtonDown(0))
            {
                index++;
            }
            GörevTamam();
            tetiklendi = true;
            MetniGuncelle();
        }

        if (mesafe > algilamaMesafesi)
        {
            tetiklendi = false;
            txt.text = "";
        }
        BulGuncelle();
    }

    void GörevTamam()
    {
        if (_isTakenToy && IlerlemeIndex <=1)
        {
            IlerlemeIndex = Mathf.Max(1, 2);
            PlayerPrefs.SetInt(PROGRESS_KEY, IlerlemeIndex);
            PlayerPrefs.Save();
        }
    }

    void BulGuncelle()
    {
        if(index >= 4 && !açýk)
        {
            Bul.SetActive(true);
            açýk = true;
        }
    }

    void MetniGuncelle()
    {
        if (index == 0) 
        {
            txt.text = "...";
        }
        if (index == 1)
            txt.text = konusma1;
        else if (index == 2)
            txt.text = konusma2;
        else if (index == 3)
            txt.text = konusma3;

        SesCal();
    }

    void SesCal()
    {
        if (au1 != null)
            audioSource.PlayOneShot(au1);
    }
}
