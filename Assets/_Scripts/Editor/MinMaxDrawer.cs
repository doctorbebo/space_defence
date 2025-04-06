using _Core;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomPropertyDrawer(typeof(MinMaxFloat))]
    [CustomPropertyDrawer(typeof(MinMaxInt))]
    public class MinMaxDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty minProp = property.FindPropertyRelative("min");
            SerializedProperty maxProp = property.FindPropertyRelative("max");

            EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            const float labelWidth = 30f;
            float fieldWidth = (position.width - labelWidth * 2 - 4) / 2f;

            Rect minLabelRect = new Rect(position.x, position.y, labelWidth, position.height);
            Rect minFieldRect = new Rect(minLabelRect.xMax + 2, position.y, fieldWidth, position.height);
            Rect maxLabelRect = new Rect(minFieldRect.xMax + 2, position.y, labelWidth, position.height);
            Rect maxFieldRect = new Rect(maxLabelRect.xMax + 2, position.y, fieldWidth, position.height);

            EditorGUI.LabelField(minLabelRect, "Min");
            EditorGUI.LabelField(maxLabelRect, "Max");

            if (minProp.propertyType == SerializedPropertyType.Float)
            {
                minProp.floatValue = EditorGUI.FloatField(minFieldRect, minProp.floatValue);
                maxProp.floatValue = EditorGUI.FloatField(maxFieldRect, maxProp.floatValue);
                if (maxProp.floatValue < minProp.floatValue || minProp.floatValue > maxProp.floatValue)
                    Debug.LogWarning("Min Max values are invalid. Ensure Min is less than Max and Max is greater than Min");
            }
            else
            {
                minProp.intValue = EditorGUI.IntField(minFieldRect, minProp.intValue);
                maxProp.intValue = EditorGUI.IntField(maxFieldRect, maxProp.intValue);
                if (maxProp.intValue < minProp.intValue || minProp.intValue > maxProp.intValue)
                    Debug.LogWarning("Min Max values are invalid. Ensure Min is less than Max and Max is greater than Min");
            }

            EditorGUI.EndProperty();
        }
    }
}