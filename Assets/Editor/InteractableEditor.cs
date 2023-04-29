using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Interactable), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var interactable = (Interactable)target;
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteractable can only use UnityEvents", MessageType.Info);
            if (interactable.GetComponent<InteractionEvent>() != null) return;
            interactable.useEvents = true;
            interactable.gameObject.AddComponent<InteractionEvent>();
        }
        else
        {
            base.OnInspectorGUI();
            if (interactable.useEvents)
            {
                if (interactable.GetComponent<InteractionEvent>() == null)
                {
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                if (interactable.GetComponent<InteractionEvent>() != null)
                {
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
                }
            }

        }
        
    }
    
    
    
}
