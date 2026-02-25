using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [Header("Saçlar")]
    public GameObject[] Saclar;

    [Header("Burunlar")]
    public GameObject[] Burunlar;

    [Header("Tenler")]
    public GameObject[] Tenler;

    [Header("Ağızlar")]
    public GameObject[] Agizlar;

    [Header("Gözler")]
    public GameObject SagGoz;
    public GameObject SolGoz;

    [Header("Görsel Panel")]
    public RectTransform GoruntuPanel;

    // ===== SAÇ =====

    private void Start()
    {
        KarakterOzellikleri.SagGoz = SagGoz;
        KarakterOzellikleri.SolGoz = SolGoz;
    }
    public void SacDegistir(int index)
    {
        KarakterOzellikleri.SacPrefab = Saclar[index];
        Changed();
    }

    public void SacRenkDegistir()
    {
        KarakterOzellikleri.SacRenk = SecilenButonRengi();
        Changed();
    }

    // ===== BURUN =====
    public void BurunDegistir(int index)
    {
        KarakterOzellikleri.BurunPrefab = Burunlar[index];
        Changed();
    }

    // ===== TEN =====
    public void TenDegistir(int index)
    {
        KarakterOzellikleri.TenPrefab = Tenler[index];
        Changed();
    }

    public void TenRenkDegistir()
    {
        KarakterOzellikleri.TenRenk = SecilenButonRengi();
        Changed();
    }

    // ===== AĞIZ =====
    public void AgizDegistir(int index)
    {
        KarakterOzellikleri.AgizPrefab = Agizlar[index];
        Changed();
    }

    public void AgizRenkDegistir()
    {
        KarakterOzellikleri.AgizRenk = SecilenButonRengi();
        Changed();
    }

    // ===== GÖZ =====
    //public void GozleriBagla()
    //{
    //    KarakterOzellikleri.SagGoz = SagGoz;
    //    KarakterOzellikleri.SolGoz = SolGoz;
    //}

    public void GozRenkDegistir()
    {
        KarakterOzellikleri.GozRenk = SecilenButonRengi();
        Changed();
    }

    // ===== GÖRSEL BOYUTLANDIRMA =====
    public float scale = 0.3f;
    public Vector2 offset = new Vector2(-20f, 20f);
    public Vector2 size = new Vector2(800f, 1200f);

    public void GoruntuBoyutlandir()
    {
        if (GoruntuPanel == null) return;

        GoruntuPanel.localScale = Vector3.one * scale;
        GoruntuPanel.anchorMin = new Vector2(1f, 0f);
        GoruntuPanel.anchorMax = new Vector2(1f, 0f);
        GoruntuPanel.pivot = new Vector2(1f, 0f);
        GoruntuPanel.anchoredPosition = offset;
        GoruntuPanel.sizeDelta = size;
    }


    // ===== YARDIMCI =====
    void Changed()
    {
        KarakterOzellikleri.IsChanged = true;
    }

    Color SecilenButonRengi()
    {
        GameObject btn = EventSystem.current.currentSelectedGameObject;
        if (btn == null) return Color.white;

        Image img = btn.GetComponent<Image>();
        return img != null ? img.color : Color.white;
    }

    public void LVL_4_OyunBaşlat() 
    {
        KarakterGoruntuleme.baslat = true;
    }
}
