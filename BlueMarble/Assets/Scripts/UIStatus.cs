using UnityEngine;
using TMPro;

public class UIStatus : MonoBehaviour
{
    public TextMeshPro Text;

    public void UpdateUI(string text)
    {
        Text.text = text;
    }
}