using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject AdjustPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private Slider volumeSlider;
    
    void Start()
    {
        volumeSlider.value = AudioManager.instance.LoadCurrentMasterVol();
       AudioManager.instance.PlayBGM(0);
    }

    public void StartGame()
    {
        Settings.fromSave = false;
        SceneManager.LoadScene("Loading");
    }

    public void LoadSave()
    {
        Settings.fromSave = true;
        SceneManager.LoadScene("Loading");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowHideAdjustPanel(bool flag)
    {
        AdjustPanel.SetActive(flag);
    }

    public void SetVolume(float volume)
    {
        AudioManager.instance.AdjustMasterVolume(volume);
    }
}
