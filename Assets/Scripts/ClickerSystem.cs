using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickerSystem : MonoBehaviour
{
    private int CountScore;
    private AudioSource MainAudioSource;
    private int CountLevelUp; // цена за улучшение
    private int ScorePlus;

    [SerializeField] private Text ScoreText;
    [SerializeField] private AudioClip ClickFlowerSound;

    [SerializeField] private Text CountLevelUpText;

    [SerializeField] private GameObject[] PanelShop;
    [SerializeField] private GameObject[] GamePanel;

    [SerializeField] private Image MainFlower;
    [SerializeField] private Sprite[] Flowers;

    private void Start()
    {
        CountScore = 0;
        MainAudioSource = GetComponent<AudioSource>();
        MainAudioSource.clip = ClickFlowerSound;

        ScorePlus = 1;
        CountLevelUp = 100;
    }

    private void Update()
    {
        ScoreText.text = CountScore.ToString();
        CountLevelUpText.text = CountLevelUp.ToString();
    }

    public void ClickFlower(int indexScene)
    {
        CountScore += ScorePlus;
        MainAudioSource.Play();
    }

    public void ClickGoMenu(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }

    public void ClickShop()
    {
        for(int i = 0; i <  PanelShop.Length; i++)
        {
            PanelShop[i].SetActive(true);
        }

        for(int i = 0;i < GamePanel.Length; i++)
        {
            GamePanel[i].SetActive(false);
        }
    }

    public void ClickBackShop()
    {
        for (int i = 0; i < PanelShop.Length; i++)
        {
            PanelShop[i].SetActive(false);
        }

        for (int i = 0; i < GamePanel.Length; i++)
        {
            GamePanel[i].SetActive(true);
        }
    }

    public void ClickByLevelUp()
    {
        if(CountScore >= CountLevelUp)
        {
            ScorePlus = ScorePlus * 2;
            CountScore -= CountLevelUp;
            CountLevelUp = CountLevelUp + 100;
            MainFlower.GetComponent<Image>().sprite = Flowers[Random.Range(0, Flowers.Length)];
            for (int i = 0; i < PanelShop.Length; i++)
            {
                PanelShop[i].SetActive(false);
            }

            for (int i = 0; i < GamePanel.Length; i++)
            {
                GamePanel[i].SetActive(true);
            }
        }
        else
        {
            print("not");
        }
    }
}
