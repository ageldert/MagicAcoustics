using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.MagicLeap;

[ExecuteInEditMode]
public class ModePlot : MonoBehaviour
{
    private HeadposeCanvas canvas;

    [SerializeField] private RectTransform plotContent;
    [SerializeField] private Image freqAxis;
    [SerializeField] private Text freqName;
    [SerializeField] private List<Text> freqLabels;
    [SerializeField] private Image magAxis;
    [SerializeField] private Text magName;

    const float plotWidth = 500;
    const float plotHeight = 300;
    const float lineThick = 5;

    void Start()
    {
        canvas = gameObject.GetComponent<HeadposeCanvas>();

        plotContent.sizeDelta = new Vector2(plotWidth, plotHeight);

        freqAxis.rectTransform.anchoredPosition = new Vector2(0,0);
        freqAxis.rectTransform.sizeDelta = new Vector2(plotWidth, lineThick);

        magAxis.rectTransform.anchoredPosition = new Vector2(0, 0);
        magAxis.rectTransform.sizeDelta = new Vector2(lineThick, plotHeight);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private float GetOffsetFromFreq()
    {
        // convert frequency to logarithmically scaled position in range
        return 0f;

    }
}
