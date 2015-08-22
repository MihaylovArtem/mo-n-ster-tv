using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public const int MaxNewsInDay = 3;
    public static int Audience = 0;
    public static int Money = 1000;
    public static int DayCount = 1;
    public static int NewsInDayCount = 0;

    public float sportsInterest = 100;
    public float scienceInterest = 100;
    public float polyticsInterest = 100;
    public float entertainmentInterest = 50;
    public float socialInterest = 23;
    public float cryminalInterest = 35;

    private Text audienceStats;
    private Text moneyStats;
    private Text moralStats;

    private RectTransform backViewPanel;

    private RectTransform cryminalPercentPanel;
    private RectTransform entertainmentPercentPanel;
    private RectTransform polyticsPercentPanel;
    private RectTransform sciencePercentPanel;
    private RectTransform socialPercentPanel;
    private RectTransform sportsPercentPanel;

    // Use this for initialization
    private void Start() {
        News.InitializeNews();
        InitializeUI();
    }

    private void InitializeUI() {
        moneyStats = GameObject.Find("Money").gameObject.GetComponent<Text>();
        audienceStats = GameObject.Find("Audience").gameObject.GetComponent<Text>();
        moralStats = GameObject.Find("Moral").gameObject.GetComponent<Text>();

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
        if (allNews.Count < 3) {
            News.AddNewsToCur(allNews, curNews);
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
        sportsPercentPanel.sizeDelta = new Vector2(sportsInterest / 100 * backViewPanel.rect.width, sportsPercentPanel.rect.height);

        sciencePercentPanel.sizeDelta = new Vector2(scienceInterest/100*backViewPanel.rect.width, sciencePercentPanel.rect.height);

        entertainmentPercentPanel.sizeDelta = new Vector2(entertainmentInterest/100*backViewPanel.rect.width, entertainmentPercentPanel.rect.height);

        socialPercentPanel.sizeDelta = new Vector2(socialInterest/100*backViewPanel.rect.width, socialPercentPanel.rect.height);

        polyticsPercentPanel.sizeDelta = new Vector2(polyticsInterest/100*backViewPanel.rect.width, polyticsPercentPanel.rect.height);

        cryminalPercentPanel.sizeDelta = new Vector2(cryminalInterest/100*backViewPanel.rect.width, cryminalPercentPanel.rect.height);

        audienceStats.text = Audience + " PEOPLE ARE WATCHING YOU";
        moneyStats.text = "YOU HAVE " + Money + "$";
    }

    public struct Interest {
        public static int Science = 100;
        public static int Social = 100;
        public static int Fun = 100;
        public static int Sport = 100;
        public static int Criminal = 100;
    }
}