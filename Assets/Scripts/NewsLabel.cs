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
    private Button okButtonComponent;
    private Text okButtonText;
    public static MiniGameResult currentResult = MiniGameResult.medium;

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

    }

    public void EndMiniGame() {
        var currentNews = (News.AddingNews) news[0];
        if (currentResult == MiniGameResult.perfect || currentResult == MiniGameResult.bad) {
            GameManager.Interest.Science += currentNews.ScienceChange;
            GameManager.Interest.Social += currentNews.SocialChange;
            GameManager.Interest.Sport += currentNews.SportChange;
            GameManager.Interest.Polytics += currentNews.PoliticsChange;
            GameManager.Interest.Entertainment += currentNews.FunChange;
            GameManager.Interest.Cryminal += currentNews.CriminalChange;
        }
        else if (currentResult == MiniGameResult.medium) {
            GameManager.Interest.Science += currentNews.ScienceChange/2;
            GameManager.Interest.Social += currentNews.SocialChange/2;
            GameManager.Interest.Sport += currentNews.SportChange/2;
            GameManager.Interest.Polytics += currentNews.PoliticsChange/2;
            GameManager.Interest.Entertainment += currentNews.FunChange/2;
            GameManager.Interest.Cryminal += currentNews.CriminalChange/2;
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
        }
        else if (okButtonText.text == "GOT IT") {
            okButtonText.text = "OK";
            EndMiniGame();
            news.RemoveAt(0);
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