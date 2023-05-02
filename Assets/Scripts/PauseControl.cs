using UnityEngine;

public class PauseControl : MonoBehaviour
{
    /// <summary>
    /// Static in this case means theres only ever 1 boolean that determines if the game is paused or not.
    /// And it saves its data whenever a scene is changed.
    /// </summary>
    public static bool GameIsPaused { get; private set; }
    [field: SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    [field: SerializeField] private GameObject[] toHideOnPause;
    [field: SerializeField] private GameObject[] toShowOnPause;

    /// <summary>
    /// If you are not pressing the pause key then return to top of this function
    /// Otherwise if they pause key is pressed then
    /// </summary>
    private void Update()
    {
        if (!Input.GetKeyDown(pauseKey)) return;
        
        GameIsPaused = !GameIsPaused;
        SwitchTimeState();
    }
    
    private void SwitchTimeState()
    {
        if (GameIsPaused) // Pause time
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            foreach (var t in toHideOnPause)
                t.SetActive(false); //Hide everything in this list when pause is active
            foreach (var t in toShowOnPause)
                t.SetActive(true); //Show everything in this list
        }
        else // Resume time
        {
            Time.timeScale = 1;  
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            foreach (var t in toHideOnPause)
                t.SetActive(true); //Show everything in this list when pause is active
            foreach (var t in toShowOnPause)
                t.SetActive(false); //Hide everything in this list
        }
    }
}