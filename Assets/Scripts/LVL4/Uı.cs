using UnityEngine;

public class Uı : MonoBehaviour
{
    public RectTransform GoruntuPanel;
    public GameObject bulunacaklar;
    public float scale = 1f;
    public Vector2 offset = new Vector2(-20f, 20f);
    public Vector2 size = new Vector2(800f, 1200f);

    [System.Obsolete]
    private void Update()
    {
        if (bulunacaklar.transform.GetChildCount() == 0)
        {
            GoruntuBoyutlandir();
        }
    }

    public void GoruntuBoyutlandir()
    {
        if (GoruntuPanel == null) return;

        GoruntuPanel.localScale = Vector3.one * scale;

        // Middle Center
        GoruntuPanel.anchorMin = new Vector2(0.5f, 0.5f);
        GoruntuPanel.anchorMax = new Vector2(0.5f, 0.5f);
        GoruntuPanel.pivot = new Vector2(0.5f, 0.5f);

        // Ortadaysa offset genelde (0,0) olur
        GoruntuPanel.anchoredPosition = Vector2.zero;

        GoruntuPanel.sizeDelta = size;
    }

}
