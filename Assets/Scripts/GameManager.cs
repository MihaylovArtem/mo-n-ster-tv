using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public enum GameState {
        preparing,
        broadcasting,
    }

    public static GameState currentGameState;

    public static int MaxNewsInDay = 3;
    public static int Audience = 0;
    public static int Money = 1000;
    public static int DayCount = 1;
    public static int NewsInDayCount = 0;
    public static int numberOfPressedButtons = 0;

    private Text audienceStats;

    private RectTransform backViewPanel;
    public GameObject[] cryminalButtons;

    private RectTransform cryminalPercentPanel;
    public GameObject[] entertainmentButtons;
    private RectTransform entertainmentPercentPanel;
    private Text moneyStats;
    private Text moralStats;
    public ArrayList newsToBroadcast = new ArrayList();
    public GameObject[] polyticsButtons;
    private RectTransform polyticsPercentPanel;
    public GameObject[] scienceButtons;
    private RectTransform sciencePercentPanel;
    public GameObject[] socialButtons;
    private RectTransform socialPercentPanel;

    public GameObject[] sportButtons;
    private RectTransform sportsPercentPanel;
    private Text topicsLeftText;

    private void ChangeInterestPercent() {
    }

    // Use this for initialization
    private void Start() {
        News.InitializeNews();
        InitializeGame();
        InitializeUI();
        StartDay();
    }

    private void InitializeGame() {
        for (int i = 0; i < 3; i++) {
            CheckCategory(News.AllNewsCopy.Sport, News.CurNews.Sport);
            CheckCategory(News.AllNewsCopy.Science, News.CurNews.Science);
            CheckCategory(News.AllNewsCopy.Fun, News.CurNews.Fun);
            CheckCategory(News.AllNewsCopy.Social, News.CurNews.Social);
            CheckCategory(News.AllNewsCopy.Politics, News.CurNews.Politics);
            CheckCategory(News.AllNewsCopy.Criminal, News.CurNews.Criminal);
        }
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
        entertainmentPercentPanel =
            GameObject.Find("Entertainment Percent View").gameObject.GetComponent<RectTransform>();
        socialPercentPanel = GameObject.Find("Social Percent View").gameObject.GetComponent<RectTransform>();
        cryminalPercentPanel = GameObject.Find("Cryminal Percent View").gameObject.GetComponent<RectTransform>();
    }


    private void CheckCategory(ArrayList allNews, ArrayList curNews) {
        if (curNews.Count < 3) {
            if (allNews.Count > 0) News.AddNewsToCur(allNews, curNews);
        }
    }

    private void StartDay() {
        currentGameState = GameState.preparing;
        for (int i = 0; i < 3; i++) {
            Debug.Log(News.CurNews.Sport.Count + " " + i);
            if (News.CurNews.Sport.Count > i)
                sportButtons[i].GetComponent<ChooseButtonAction>().attachedNews =
                    (News.AddingNews) News.CurNews.Sport[i];
            else sportButtons[i].GetComponent<ChooseButtonAction>().attachedNews = News.clearNews;
            if (News.CurNews.Science.Count > i)
                scienceButtons[i].GetComponent<ChooseButtonAction>().attachedNews =
                    (News.AddingNews) News.CurNews.Science[i];
            else scienceButtons[i].GetComponent<ChooseButtonAction>().attachedNews = News.clearNews;
            if (News.CurNews.Social.Count > i)
                socialButtons[i].GetComponent<ChooseButtonAction>().attachedNews =
                    (News.AddingNews) News.CurNews.Social[i];
            else socialButtons[i].GetComponent<ChooseButtonAction>().attachedNews = News.clearNews;
            if (News.CurNews.Fun.Count > i)
                entertainmentButtons[i].GetComponent<ChooseButtonAction>().attachedNews =
                    (News.AddingNews) News.CurNews.Fun[i];
            else entertainmentButtons[i].GetComponent<ChooseButtonAction>().attachedNews = News.clearNews;
            if (News.CurNews.Criminal.Count > i)
                cryminalButtons[i].GetComponent<ChooseButtonAction>().attachedNews =
                    (News.AddingNews) News.CurNews.Criminal[i];
            else cryminalButtons[i].GetComponent<ChooseButtonAction>().attachedNews = News.clearNews;
            if (News.CurNews.Politics.Count > i)
                polyticsButtons[i].GetComponent<ChooseButtonAction>().attachedNews =
                    (News.AddingNews) News.CurNews.Politics[i];
            else polyticsButtons[i].GetComponent<ChooseButtonAction>().attachedNews = News.clearNews;
        }
    }

    public void StartBroadcasting() {
        currentGameState = GameState.broadcasting;
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("ChooseButton")) {
            var buttonScript = button.GetComponent<ChooseButtonAction>();
            if (buttonScript.isPressed) {
                newsToBroadcast.Add(buttonScript.attachedNews);
            }
        }
    }

    public void EndDay() {
        DayCount++;
        foreach (GameObject button in GameObject.FindGameObjectsWithTag("ChooseButton")) {
            var buttonScript = button.GetComponent<ChooseButtonAction>();
            if (buttonScript.isPressed) {
                buttonScript.OnClick();
                buttonScript.attachedNews = News.clearNews;
            }
        }

        News.RemoveSelectedNewsFromCur(newsToBroadcast);
        newsToBroadcast.Clear();

        CheckCategory(News.AllNewsCopy.Sport, News.CurNews.Sport);
        CheckCategory(News.AllNewsCopy.Science, News.CurNews.Science);
        CheckCategory(News.AllNewsCopy.Fun, News.CurNews.Fun);
        CheckCategory(News.AllNewsCopy.Social, News.CurNews.Social);
        CheckCategory(News.AllNewsCopy.Politics, News.CurNews.Politics);
        CheckCategory(News.AllNewsCopy.Criminal, News.CurNews.Criminal);

        StartDay();
    }

    private void OnGUI() {
        sportsPercentPanel.sizeDelta = new Vector2(Interest.Sport/100*backViewPanel.rect.width,
            sportsPercentPanel.rect.height);
        sciencePercentPanel.sizeDelta = new Vector2(Interest.Science/100*backViewPanel.rect.width,
            sciencePercentPanel.rect.height);
        entertainmentPercentPanel.sizeDelta = new Vector2(Interest.Entertainment/100*backViewPanel.rect.width,
            entertainmentPercentPanel.rect.height);
        socialPercentPanel.sizeDelta = new Vector2(Interest.Social/100*backViewPanel.rect.width,
            socialPercentPanel.rect.height);
        polyticsPercentPanel.sizeDelta = new Vector2(Interest.Polytics/100*backViewPanel.rect.width,
            polyticsPercentPanel.rect.height);
        cryminalPercentPanel.sizeDelta = new Vector2(Interest.Cryminal/100*backViewPanel.rect.width,
            cryminalPercentPanel.rect.height);

        audienceStats.text = Audience + " PEOPLE ARE WATCHING YOU";
        moneyStats.text = "YOU HAVE " + Money + "$";

        topicsLeftText.text = "CHOOSE " + (MaxNewsInDay - numberOfPressedButtons) + " TOPICS";
    }

    public struct Interest {
        public static float Science = 80;
        public static float Social = 100;
        public static float Entertainment = 100;
        public static float Sport = 40;
        public static float Cryminal = 100;
        public static float Polytics = 20;
    }
}