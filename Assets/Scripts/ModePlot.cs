using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

[ExecuteInEditMode]
public class ModePlot : MonoBehaviour
{
    [SerializeField] private RectTransform plotContent;
    [SerializeField] private Image freqAxis;
    [SerializeField] private Text freqName;
    [SerializeField] private List<Text> freqLabels;
    [SerializeField] private List<Image> freqTicks;
    [SerializeField] private Image magAxis;
    [SerializeField] private Text magName;

    [SerializeField] private Text axialLegend;
    [SerializeField] private Text tangentialLegend;
    [SerializeField] private Text obliqueLegend;

    [SerializeField] private GameObject modeParent;
    [SerializeField] private Image modePrefab;

    private Color textColor = Color.white;
    const float plotWidth = 650;
    const float plotHeight = 300;
    const float lineThick = 5;

    public void Initialize()
    {
        plotContent.sizeDelta = new Vector2(plotWidth, plotHeight);
        PlaceAxes();
        PlaceTicks();
        PlaceLegend();
    }

    private void PlaceAxes()
    {
        freqAxis.rectTransform.anchoredPosition = new Vector2(0, 0);
        freqAxis.rectTransform.sizeDelta = new Vector2(plotWidth, lineThick);
        freqAxis.color = textColor;

        magAxis.rectTransform.anchoredPosition = new Vector2(0, 0);
        magAxis.rectTransform.sizeDelta = new Vector2(lineThick, plotHeight);
        magAxis.color = textColor;

        freqName.text = "Frequency (Hz)";
        freqName.color = textColor;
        freqName.rectTransform.anchoredPosition = new Vector2(plotWidth / 3, -60);

        magName.text = "Magnitude";
        magName.color = textColor;
        magName.rectTransform.anchoredPosition = new Vector2(-20, plotHeight / 3);
    }

    private void PlaceTicks()
    {
        float f = 20;
        foreach (Image tick in freqTicks)
        {
            tick.rectTransform.anchoredPosition = new Vector2(GetOffsetFromFreq(f), -lineThick);
            tick.rectTransform.sizeDelta = new Vector2(lineThick, lineThick*2);
            tick.color = textColor;
            f *= 2;
        }

        f = 20;
        foreach(Text text in freqLabels)
        {
            text.text = f.ToString("F0");
            text.color = textColor;
            text.rectTransform.anchoredPosition = new Vector2(GetOffsetFromFreq(f)-10, -30);
            f *= 2;
        }
    }

    private void PlaceLegend()
    {
        axialLegend.color = GetModeColor(ModeType.Axial);
        tangentialLegend.color = GetModeColor(ModeType.Tangential);
        obliqueLegend.color = GetModeColor(ModeType.Oblique);
    }

    private float GetOffsetFromFreq(float freq)
    {
        // frequency ranges between 16 and 320
        // position ranges between 0 and plotWidth

        float linear = Mathf.Log10(freq/12) / 1.5f;
        float loc = linear * plotWidth;
        return loc;
    }

    public void PlotMode(Mode mode)
    {
        //Image newModeImage = Instantiate(modePrefab, modeParent.transform);
        Image newModeImage = Instantiate(modePrefab);
        newModeImage.transform.SetParent(modeParent.transform, false);
        newModeImage.rectTransform.anchoredPosition = new Vector2(GetOffsetFromFreq(mode.freq), lineThick);
        newModeImage.rectTransform.sizeDelta = new Vector2(lineThick-2.5f, mode.mag * 10);
        newModeImage.color = GetModeColor(mode.modeType);
    }

    private Color GetModeColor(ModeType modeType)
    {
        switch(modeType)
        {
            case ModeType.Axial:
                return Color.magenta;
            case ModeType.Tangential:
                return Color.cyan;
            case ModeType.Oblique:
                return Color.yellow;
            default:
                return Color.black;
        }
    }
}
