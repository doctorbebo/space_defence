using UnityEngine;
using UnityEngine.Events;

namespace UserControls
{
    public class ClickEventManager : MonoBehaviour, IClickable
    {
        public bool leftClickEnabled  = true;
        public bool rightClickEnabled  = true;
        public UnityEvent onLeftClick;
        public UnityEvent onRightClick;
        
        private void Start()
        {
            onLeftClick.AddListener(() => { Debug.Log( $"{transform.parent.name} left click"); });
            onRightClick.AddListener(() => { Debug.Log($"{transform.parent.name} right click"); });
        }

        public void OnLeftClick()
        {
            if (leftClickEnabled)
            {
                onLeftClick.Invoke();
            }
        }
    
        public void OnRightClick()
        {
            if (rightClickEnabled)
            {
                onRightClick.Invoke();
            }
        }

        public void SetLeftClickEnable(bool isEnabled) => leftClickEnabled = isEnabled;
        public void SetRightClickEnable(bool isEnabled) => rightClickEnabled = isEnabled;
    }
}
