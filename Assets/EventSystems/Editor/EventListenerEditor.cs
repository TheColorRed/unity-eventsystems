using UnityEditor;
using UnityEngine;
using UnityEditorInternal;
using EventSystems;
using System;
using System.Reflection;
using System.Collections.Generic;

[CustomEditor(typeof(EventListener))]
public class EventListenerEditor : Editor {

  EventListener t;
  List<MonoBehaviour> monoBehaviours = new List<MonoBehaviour>();

  private ReorderableList events;

  void OnEnable() {
    t = target as EventListener;
    events = new ReorderableList(serializedObject, serializedObject.FindProperty("events"), true, true, true, true);
    events.drawHeaderCallback = (Rect rect) => EditorGUI.LabelField(rect, "Events");
    events.elementHeight = 40;
    Dictionary<int, int> selectedMethod = new Dictionary<int, int>();
    events.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
      // Get a list of all the MonoBehaviours on the object
      MonoBehaviour[] behaviors = t.gameObject.GetComponents<MonoBehaviour>();
      monoBehaviours = new List<MonoBehaviour>();
      foreach (var b in behaviors) {
        if (b.GetType() != typeof(EventListener)) {
          monoBehaviours.Add(b);
        }
      }

      // Get the current element
      var element = events.serializedProperty.GetArrayElementAtIndex(index);
      var name = element.FindPropertyRelative("name");
      var comp = element.FindPropertyRelative("comp");
      var method = element.FindPropertyRelative("method");

      rect.y += 2;

      // Draw the event name field
      EditorGUI.PropertyField(
        new Rect(rect.x, rect.y, rect.width / 4, EditorGUIUtility.singleLineHeight),
        name, GUIContent.none
      );
      if (comp.objectReferenceValue == null) {
        EditorGUI.LabelField(
          new Rect((rect.width / 4) + rect.x + 2, rect.y, rect.width / 1.35f, EditorGUIUtility.singleLineHeight),
          "Action"
        );
      } else if (comp.objectReferenceValue != null) {
        // Draw the MonoBehaviour field
        EditorGUI.PropertyField(
          new Rect((rect.width / 4) + rect.x + 2, rect.y, rect.width / 1.35f, EditorGUIUtility.singleLineHeight),
          comp, GUIContent.none
        );
      }
      if (comp.objectReferenceValue != null) {
        // Get a list of the methods for the particular component
        MethodInfo[] methods = comp.objectReferenceValue.GetType().GetMethods(
          BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly
        );
        var methodNames = new string[methods.Length];
        var currentValue = method.stringValue;
        for (var i = 0; i < methods.Length; i++) {
          methodNames[i] = methods[i].Name;
          if (currentValue == methods[i].Name) {
            selectedMethod[index] = i;
          }
        }

        // Draw the list of attached properties
        int value = 0;
        selectedMethod.TryGetValue(index, out value);
        selectedMethod[index] = EditorGUI.Popup(
          new Rect(rect.x, rect.y + EditorGUIUtility.singleLineHeight + 4, rect.width, EditorGUIUtility.singleLineHeight),
          value, methodNames
        );
        method.stringValue = methodNames[selectedMethod[index]];
      }
    };
  }

  public override void OnInspectorGUI() {
    serializedObject.Update();
    EditorGUILayout.Space();
    events.DoLayoutList();
    serializedObject.ApplyModifiedProperties();
  }
}
