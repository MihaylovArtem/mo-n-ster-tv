using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public struct Interest
    {
        public static float Science = 80;
        public static float Social = 100;
        public static float Entertainment = 100;
        public static float Sport = 40;
        public static float Cryminal = 100;
        public static float Polytics = 20;
    }

    void ChangeInterestPercent() {
        
    }

    public static int MaxNewsInDay = 3;
    public static int Audience = 0;
    public static int Money = 1000;
    public static int DayCount = 1;
    public static int NewsInDayCount = 0;

    private Text audienceStats;
    private Text moneyStats;
    private Text moralStats;
    private Text topicsLeftText;

    private RectTransform backViewPanel;

    private RectTransform cryminalPercentPanel;
    private RectTransform entertainmentPercentPanel;
    private RectTransform polyticsPercentPanel;
    private RectTransform sciencePercentPanel;
    private RectTransform socialPercentPanel;
    private RectTransform sportsPercentPanel;

    public GameObject[] sportButtons;
    public GameObject[] scienceButtons;
    public GameObject[] cryminalButtons;
    public GameObject[] polyticsButtons;
    public GameObject[] socialButtons;
    public GameObject[] entertainmentButtons;

    public static int numberOfPressedButtons = 0;

    // Use this for initialization
    void Start() {
        News.InitializeNews();
        InitializeUI();
        StartDay();
    }

    private void InitializeUI() {
        moneyStats = GameObject.Find("Money").gameObject.GetComponent<Text>();
        audienceStats = GameObject.Find("Audience").gameObject.GetComponent<Text>();
        moralStats = GameObject.Find("Moral").gameObject.GetComponent<Text>();
        topicsLeftText = GameObject.Find("TopicsLeftStats").gameObject.GetComponent<Text>();

        backViewPanel = GameObject.Find("Back View Sample").gameObject.GetComponent<RectTransform>();
        sportsPercentPanel = GameObject.Find("Sport Percent View").gameObject.GetComponent<RectTransform>();
        sciencePercentPanel = GameObject.Find("Science Percent View").gameObject.GetComponent<RectTransform>();
        polyticsPercentPanel = GameObject.Find("Polytics Percent View").gameObject.GetComponent<RectTransform>();
        entertainmentPercentPanel = GameObject.Find("Entertainment Percent View").gameObject.GetComponent<RectTransform>();
        socialPercentPanel = GameObject.Find("Social Percent View").gameObject.GetComponent<RectTransform>();
        cryminalPercentPanel = GameObject.Find("Cryminal Percent View").gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void CheckCategory(ArrayList allNews, ArrayList curNews) {
        if (curNews.Count < 3) {
            News.AddNewsToCur(allNews, curNews);
        }
    }

    private void StartDay() {
        for (int i = 0; i < 3; i++) {
            CheckCategory(News.AllNewsCopy.Sport, News.CurNews.Sport);
            CheckCategory(News.AllNewsCopy.Science, News.CurNews.Science);
            CheckCategory(News.AllNewsCopy.Fun, News.CurNews.Fun);
            CheckCategory(News.AllNewsCopy.Social, News.CurNews.Social);
            CheckCategory(News.AllNewsCopy.Politics, News.CurNews.Politics);
            CheckCategory(News.AllNewsCopy.Criminal, News.CurNews.Criminal);
        }

        for (int i=0;i<3;i++) {
            sportButtons[i].GetComponent<ChooseButtonAction>().attachedNews = (News.AddingNews) News.CurNews.Sport[i];
            scienceButtons[i].GetComponent<ChooseButtonAction>().attachedNews = (News.AddingNews) News.CurNews.Science[i];
            socialButtons[i].GetComponent<ChooseButtonAction>().attachedNews = (News.AddingNews) News.CurNews.Social[i];
            entertainmentButtons[i].GetComponent<ChooseButtonAction>().attachedNews = (News.AddingNews) News.CurNews.Fun[i];
            cryminalButtons[i].GetComponent<ChooseButtonAction>().attachedNews = (News.AddingNews) News.CurNews.Criminal[i];
            polyticsButtons[i].GetComponent<ChooseButtonAction>().attachedNews = (News.AddingNews) News.CurNews.Politics[i];
        }
    }

    public void StartBroadcasting() {
        foreach (var button in GameObject.FindGameObjectsWithTag("chooseButton"))
        {
//            if (button.GetComponent<ChooseButtonAction>().isPressed)
        }
    }

    private void EndDay() {
        DayCount++;
        NewsInDayCount = 0;
        CheckCategory(News.AllNewsCopy.Sport, News.CurNews.Sport);
        CheckCategory(News.AllNewsCopy.Science, News.CurNews.Science);
        CheckCategory(News.AllNewsCopy.Fun, News.CurNews.Fun);
        CheckCategory(News.AllNewsCopy.Social, News.CurNews.Social);
        CheckCategory(News.AllNewsCopy.Politics, News.CurNews.Politics);
        CheckCategory(News.AllNewsCopy.Criminal, News.CurNews.Criminal);
    }

    private void OnGUI() {
        sportsPercentPanel.sizeDelta = new Vector2(Interest.Sport / 100 * backViewPanel.rect.width, sportsPercentPanel.rect.height);
        sciencePercentPanel.sizeDelta = new Vector2(Interest.Science/ 100 * backViewPanel.rect.width, sciencePercentPanel.rect.height);
        entertainmentPercentPanel.sizeDelta = new Vector2(Interest.Entertainment / 100 * backViewPanel.rect.width, entertainmentPercentPanel.rect.height);
        socialPercentPanel.sizeDelta = new Vector2(Interest.Social/ 100 * backViewPanel.rect.width, socialPercentPanel.rect.height);
        polyticsPercentPanel.sizeDelta = new Vector2(Interest.Polytics/ 100 * backViewPanel.rect.width, polyticsPercentPanel.rect.height);
        cryminalPercentPanel.sizeDelta = new Vector2(Interest.Cryminal/100*backViewPanel.rect.width, cryminalPercentPanel.rect.height);

        audienceStats.text = Audience + " PEOPLE ARE WATCHING YOU";
        moneyStats.text = "YOU HAVE " + Money + "$";

        topicsLeftText.text = "CHOOSE " + (MaxNewsInDay - numberOfPressedButtons) + " TOPICS";
    }
}