using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public enum GameState {
        preparing,
        broadcasting,
    }

    public static int SALARY = 200;
    public static int RENT = 500;
    public static int GOVERNMENT_PERCENT = 15;


    public static GameState currentGameState;

    public static int MaxNewsInDay = 2;
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
    private int incomeFromNews;
    private int moneyForRent;
    private int moneyForSalary;
    private Text moneyStats;
    private int moneyToGovernment;
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
    public GameObject startBroadcastingButton;
    public GameObject tab1Button;
    public GameObject tab2Button;
    private Text topicsLeftText;
    public GameObject upgradesButton;
    public GameObject upgradesView;


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
        startBroadcastingButton.transform.localScale = new Vector3(1, 1, 1);
        upgradesButton.transform.localScale = new Vector3(1, 1, 1);

        tab2Button.GetComponent<TabControl>().OnClick();
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

    public void StartMiniGame() {
    }

    public void StartBroadcasting() {

        upgradesView.GetComponent<Upgrades>().ClickUpgrades();
        
        tab1Button.GetComponent<TabControl>().OnClick();

        startBroadcastingButton.transform.localScale = new Vector3(0, 0, 0);
        upgradesButton.transform.localScale = new Vector3(0, 0, 0);

        currentGameState = GameState.broadcasting;


        foreach (GameObject button in GameObject.FindGameObjectsWithTag("ChooseButton")) {
            var buttonScript = button.GetComponent<ChooseButtonAction>();
            if (buttonScript.isPressed) {
                newsToBroadcast.Add(buttonScript.attachedNews);
            }
        }

        incomeFromNews = 0;
        NewsLabel.news.AddRange(newsToBroadcast);
        foreach (object newToBroadcast in newsToBroadcast) {
            StartMiniGame();
            int income = CountIncomeFromNew((News.AddingNews) newToBroadcast);
            incomeFromNews += income;
            Money += income;
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

        moneyForSalary = (MaxNewsInDay - 1)*SALARY;
        moneyForRent = RENT;
        moneyToGovernment = incomeFromNews*GOVERNMENT_PERCENT/100;

        Money = Money - moneyForSalary - moneyForRent - moneyToGovernment;

        StartDay();
    }

    public int CountIncomeFromNew(News.AddingNews news) {
        if (News.CurNews.Science.Contains(news)) {
            return Interest.Science/100*Audience;
        }
        if (News.CurNews.Sport.Contains(news)) {
            return Interest.Sport/100*Audience;
        }
        if (News.CurNews.Social.Contains(news)) {
            return Interest.Social/100*Audience;
        }
        if (News.CurNews.Criminal.Contains(news)) {
            return Interest.Cryminal/100*Audience;
        }
        if (News.CurNews.Fun.Contains(news)) {
            return Interest.Entertainment/100*Audience;
        }
        if (News.CurNews.Politics.Contains(news)) {
            return Interest.Polytics/100*Audience;
        }
        return 0;
    }


    private void OnGUI() {
        sportsPercentPanel.sizeDelta = new Vector2((float) Interest.Sport/100*backViewPanel.rect.width,
            sportsPercentPanel.rect.height);
        sciencePercentPanel.sizeDelta = new Vector2((float) Interest.Science/100*backViewPanel.rect.width,
            sciencePercentPanel.rect.height);
        entertainmentPercentPanel.sizeDelta = new Vector2((float) Interest.Entertainment/100*backViewPanel.rect.width,
            entertainmentPercentPanel.rect.height);
        socialPercentPanel.sizeDelta = new Vector2((float) Interest.Social/100*backViewPanel.rect.width,
            socialPercentPanel.rect.height);
        polyticsPercentPanel.sizeDelta = new Vector2((float) Interest.Polytics/100*backViewPanel.rect.width,
            polyticsPercentPanel.rect.height);
        cryminalPercentPanel.sizeDelta = new Vector2((float) Interest.Cryminal/100*backViewPanel.rect.width,
            cryminalPercentPanel.rect.height);

        audienceStats.text = Audience + " PEOPLE ARE WATCHING YOU";
        moneyStats.text = "YOU HAVE " + Money + "$";

        topicsLeftText.text = "CHOOSE " + (MaxNewsInDay - numberOfPressedButtons) + " TOPICS";
    }

    public struct Interest {
        public static int Science = Random.Range(10, 30);
        public static int Social = Random.Range(10, 30);
        public static int Entertainment = Random.Range(10, 30);
        public static int Sport = Random.Range(10, 30);
        public static int Cryminal = Random.Range(10, 30);
        public static int Polytics = Random.Range(10, 30);
    }
}