using System;
using Managers;
using TMPro;
using UnityEngine;

public class DisplayIntVariable : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private IntVariable variable;

    private void Awake()
    {
        if (variable != null)
        {
            display.text = variable.ToString();
        }
        variable.AddListener(UpdateText);
    }

    private void UpdateText(int newValue)
    {
        display.text = newValue.ToString("N0");
    }
}
