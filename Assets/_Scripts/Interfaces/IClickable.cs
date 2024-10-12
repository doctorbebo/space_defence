using UnityEngine;
using UnityEngine.InputSystem;

public interface IClickable
{
    // ReSharper disable once InconsistentNaming
    string name { get; }
        
    void OnLeftClick() { Debug.LogWarning($"{name}: OnLeftClicked not implemented"); }

    void OnRightClick() { Debug.LogWarning($"{name}: OnRightClicked not implemented"); }

    void OnLeftShiftClick() { Debug.LogWarning($"{name}: OnLeftShiftClicked not implemented"); }

    void OnRightShiftClick() { Debug.LogWarning($"{name}: OnRightShiftClicked not implemented"); }

    void OnLeftControlClick() { Debug.LogWarning($"{name}: OnLeftControlClicked not implemented"); }

    void OnRightControlClick() { Debug.LogWarning($"{name}: OnRightControlClicked not implemented"); }

    void OnLeftShiftControlClick() { Debug.LogWarning($"{name}: OnLeftShiftControlClicked not implemented"); }

    void OnRightShiftControlClick() { Debug.LogWarning($"{name}: OnRightShiftControlClicked not implemented"); }
}