using System.Collections;
using TMPro;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField]
    private ProgressBar[] ProgressBars = new ProgressBar[0];
    private string Speed = "1";

    private void OnGUI()
    {
        for (int i = 0; i < ProgressBars.Length; i++)
        {
            Speed = GUI.TextField(new Rect(10, 10, 150, 25), Speed);
            if (GUI.Button(new Rect(10, 45 + (40 * i), 150, 30), $"Play Progress Bar {i + 1}"))
            {
                StartCoroutine(SetProgress(ProgressBars[i], float.Parse(Speed)));
            }
        }
    }

    private IEnumerator SetProgress(ProgressBar ProgressBar, float Speed)
    {
        ProgressBar.SetProgress(0, float.MaxValue);
        ProgressBar.GetComponentInChildren<TextMeshProUGUI>().SetText("Loading...");
        yield return null;
        ProgressBar.SetProgress(1, Speed);
    }
}
