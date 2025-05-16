using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    private AudioSource MainAudioSource;
    private static bool isSound;

    [SerializeField] private Animator CurtainAnimator;
    [SerializeField] private Animator PlayAnimator;

    [SerializeField] private AudioClip PlaySound;

    [SerializeField] private Image Sound;
    [SerializeField] private Sprite SoundOn;
    [SerializeField] private Sprite SoundOff;
    [SerializeField] private GameObject Musick;

    private void Start()
    {
        gameObject.AddComponent<AudioSource>();
        MainAudioSource = GetComponent<AudioSource>();
        MainAudioSource.clip = PlaySound;
    }

    public void ClickPlay()
    {
        StartCoroutine(WaitPlayClick(1));
        MainAudioSource.Play();
        CurtainAnimator.SetTrigger("CloseCurtain");
        PlayAnimator.SetTrigger("Play");
    }

    public void ClickExit()
    {
        Application.Quit();
    }

    public void ClickSound()
    {
        if(isSound == true)
        {
            isSound = false;
            Sound.sprite = SoundOff;
            Musick.GetComponent<AudioSource>().Stop();
        }
        else
        {
            isSound = true;
            Sound.sprite = SoundOn;
            Musick.GetComponent<AudioSource>().Play();
        }
    }

    private IEnumerator WaitPlayClick(int indexScene)
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(indexScene);
    }
}
