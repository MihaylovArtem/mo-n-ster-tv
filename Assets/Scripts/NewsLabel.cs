using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewsLabel : MonoBehaviour {
    public static ArrayList news = new ArrayList();
    public GameObject header;
    private Text headerText;
    public GameObject newsLabel;
    private Text newsText;
    public GameObject okButton;
    public Button okButtonComponent;
    private Text okButtonText;
    public static MiniGameResult currentResult = MiniGameResult.medium;
    public GameObject MiniGameObject;
    public GameObject cloneMiniGameObject;

    public enum MiniGameResult {
        perfect,
        medium,
        bad
    }

    // Use this for initialization
    private void Awake() {
        okButtonComponent = okButton.GetComponent<Button>();
        headerText = header.GetComponent<Text>();
        okButtonText = okButton.transform.GetChild(0).GetComponent<Text>();
        newsText = newsLabel.transform.GetChild(0).gameObject.GetComponent<Text>();
    }

    private void StartMiniGame() {
        var actionSide = GameObject.Find("Action side");
        cloneMiniGameObject = Instantiate(MiniGameObject);
        cloneMiniGameObject.transform.SetParent(actionSide.transform, false);
    }

    public static void EndMiniGame() {
        var currentNews = (News.AddingNews) news[0];
        if (currentResult == MiniGameResult.perfect) {
            if (currentNews.ScienceChange>0) GameManager.Interest.Science += currentNews.ScienceChange;
            if (currentNews.SocialChange > 0) GameManager.Interest.Social += currentNews.SocialChange;
            if (currentNews.SportChange > 0) GameManager.Interest.Sport += currentNews.SportChange;
            if (currentNews.PoliticsChange > 0) GameManager.Interest.Polytics += currentNews.PoliticsChange;
            if (currentNews.FunChange > 0) GameManager.Interest.Entertainment += currentNews.FunChange;
            if (currentNews.CriminalChange > 0) GameManager.Interest.Cryminal += currentNews.CriminalChange;
        }
        else if (currentResult == MiniGameResult.medium) {
            GameManager.Interest.Science += currentNews.ScienceChange/2;
            GameManager.Interest.Social += currentNews.SocialChange/2;
            GameManager.Interest.Sport += currentNews.SportChange/2;
            GameManager.Interest.Polytics += currentNews.PoliticsChange/2;
            GameManager.Interest.Entertainment += currentNews.FunChange/2;
            GameManager.Interest.Cryminal += currentNews.CriminalChange/2;
        }
        else if (currentResult == MiniGameResult.bad)
        {
            if (currentNews.ScienceChange < 0) GameManager.Interest.Science += currentNews.ScienceChange;
            if (currentNews.SocialChange < 0) GameManager.Interest.Social += currentNews.SocialChange;
            if (currentNews.SportChange < 0) GameManager.Interest.Sport += currentNews.SportChange;
            if (currentNews.PoliticsChange < 0) GameManager.Interest.Polytics += currentNews.PoliticsChange;
            if (currentNews.FunChange < 0) GameManager.Interest.Entertainment += currentNews.FunChange;
            if (currentNews.CriminalChange < 0) GameManager.Interest.Cryminal += currentNews.CriminalChange;
            
        }
    }

    // Update is called once per frame
    private void Update() {
    }

    public void OnClick() {
        if (okButtonText.text == "OK") {
            StartMiniGame();
            okButtonText.text = "STOP";
        }
        else if (okButtonText.text == "STOP") {
            okButtonText.text = "GOT IT";
            cloneMiniGameObject.GetComponent<MiniGame>().userPressedButton = true;
            okButtonComponent.interactable = false;
        }
        else if (okButtonText.text == "GOT IT") {
            EndMiniGame();
            news.RemoveAt(0);
            Destroy(cloneMiniGameObject);
            okButtonText.text = "OK";
        }
    }

    private void OnGUI() {
        if (news.Count > 0) {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            newsText.text = ((News.AddingNews) news[0]).Text;
            headerText.text = ((News.AddingNews) news[0]).Header;
        }
        else if (GameManager.currentGameState == GameManager.GameState.broadcasting) {
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("GameManager").GetComponent<GameManager>().EndDay();
        }
    }
}