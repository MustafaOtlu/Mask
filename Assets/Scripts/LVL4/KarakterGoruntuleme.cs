using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KarakterGoruntuleme : MonoBehaviour
{
    #region Genel

    public static bool baslat;
    public float sure = 120f;

    #endregion

    #region Fiziksel Dünya Objeleri (Sýralý)

    [Header("Fiziksel Dünya Objeleri (Sýralý)")]
    public GameObject[] dunyaObjeleri;

    #endregion

    #region Karakter UI Parentlarý (Sýralý)

    [Header("Karakter UI Parentlarý (Sýralý)")]
    public Transform[] karakterParentlari;

    #endregion

    int index = 0;
    bool calisiyor;

    void Start()
    {
        TumDunyaObjeleriniKapat();
    }

    void Update()
    {
        if (baslat && !calisiyor)
        {
            baslat = false;
            StartCoroutine(AnaSurec());
        }
    }

    IEnumerator AnaSurec()
    {
        calisiyor = true;

        while (index < dunyaObjeleri.Length && index < karakterParentlari.Length)
        {
            yield return StartCoroutine(TekAsama(index));
            index++;
        }

        calisiyor = false;
    }

    IEnumerator TekAsama(int i)
    {
        GameObject dunyaObjesi = dunyaObjeleri[i];
        Transform parent = karakterParentlari[i];

        TumDunyaObjeleriniKapat();
        dunyaObjesi.SetActive(true);

        Image img = ParentIcindenImageBul(parent);
        float kalanSure = sure;

        float baslangicAlpha = img != null ? img.color.a : 1f;
        bool bulundu = false;

        while (kalanSure > 0f && !bulundu)
        {
            kalanSure -= Time.deltaTime;

            if (img != null)
            {
                float oran = kalanSure / sure;
                float alpha = baslangicAlpha * oran;
                Color c = img.color;
                img.color = new Color(c.r, c.g, c.b, alpha);
            }

            // Fiziksel obje yok olduysa (çarpýldýysa)
            if (dunyaObjesi == null)
                bulundu = true;

            yield return null;
        }

        if (dunyaObjesi != null)
            Destroy(dunyaObjesi);
    }

    #region Yardýmcýlar

    void TumDunyaObjeleriniKapat()
    {
        foreach (var obj in dunyaObjeleri)
            if (obj != null)
                obj.SetActive(false);
    }

    Image ParentIcindenImageBul(Transform parent)
    {
        if (parent == null)
            return null;

        for (int i = 0; i < parent.childCount; i++)
        {
            Image img = parent.GetChild(i).GetComponent<Image>();
            if (img != null && img.gameObject.activeInHierarchy)
                return img;
        }

        return null;
    }

    #endregion
}
