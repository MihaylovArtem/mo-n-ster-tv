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
    public GameObject Women;
    public Animation WomenAnimation;
    public Animator WomenAnimator;
    public AnimationClip womenIdle;
    public AnimationClip womenTalking;

    public Text RedText;
    public Text YellowText;
    public Text GreenText;


    public enum MiniGameResult {
        perfect,
        medium,
        bad
    }

    // Use this for initialization
    private void Awake() {
        WomenAnimation = Women.GetComponent<Animation>();
        WomenAnimator = Women.GetComponent<Animator>();
        WomenAnimator.Play("WomenAnimation");
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
            if (currentNews.ScienceChange > 0) {
                GameManager.Interest.Science += currentNews.ScienceChange;
                GameManager.Audience += currentNews.ScienceChange * Random.Range(20, 40);
            }
            if (currentNews.SocialChange > 0) {
                GameManager.Interest.Social += currentNews.SocialChange;
                GameManager.Audience += currentNews.SocialChange * Random.Range(20, 40);
            }
            if (currentNews.SportChange > 0) {
                GameManager.Interest.Sport += currentNews.SportChange;
                GameManager.Audience += currentNews.SportChange * Random.Range(20, 40);
            }
            if (currentNews.PoliticsChange > 0) {
                GameManager.Interest.Polytics += currentNews.PoliticsChange;
                GameManager.Audience += currentNews.PoliticsChange * Random.Range(20, 40);
            }
            if (currentNews.FunChange > 0) {
                GameManager.Interest.Entertainment += currentNews.FunChange;
                GameManager.Audience += currentNews.FunChange * Random.Range(20, 40);
            }
            if (currentNews.CriminalChange > 0) {
                GameManager.Interest.Cryminal += currentNews.CriminalChange;
                GameManager.Audience += currentNews.CriminalChange * Random.Range(20, 40);
            }
        }
        else if (currentResult == MiniGameResult.medium) {
            GameManager.Interest.Science += currentNews.ScienceChange/2;
            GameManager.Interest.Social += currentNews.SocialChange/2;
            GameManager.Interest.Sport += currentNews.SportChange/2;
            GameManager.Interest.Polytics += currentNews.PoliticsChange/2;
            GameManager.Interest.Entertainment += currentNews.FunChange/2;
            GameManager.Interest.Cryminal += currentNews.CriminalChange/2;

            GameManager.Audience += currentNews.ScienceChange/2 * Random.Range(10, 40) + currentNews.SocialChange/2 * Random.Range(10, 40)+currentNews.SportChange/2 * Random.Range(10, 40)
                + currentNews.PoliticsChange / 2 * Random.Range(10, 40) + currentNews.FunChange/2 * Random.Range(10, 40) + currentNews.CriminalChange/2 * Random.Range(10, 40);
        }
        else if (currentResult == MiniGameResult.bad)
        {
            if (currentNews.ScienceChange < 0) {
                GameManager.Interest.Science += currentNews.ScienceChange;
                GameManager.Audience += currentNews.ScienceChange*Random.Range(10,30);
            }
            if (currentNews.SocialChange < 0) {
                GameManager.Interest.Social += currentNews.SocialChange;
                GameManager.Audience += currentNews.SocialChange * Random.Range(10, 30);
            }
            if (currentNews.SportChange < 0) {
                GameManager.Interest.Sport += currentNews.SportChange;
                GameManager.Audience += currentNews.SportChange * Random.Range(10, 30);
            }
            if (currentNews.PoliticsChange < 0) {
                GameManager.Interest.Polytics += currentNews.PoliticsChange;
                GameManager.Audience += currentNews.PoliticsChange * Random.Range(10, 30);
            }
            if (currentNews.FunChange < 0) {
                GameManager.Interest.Entertainment += currentNews.FunChange;
                GameManager.Audience += currentNews.FunChange * Random.Range(10, 30);
            }
            if (currentNews.CriminalChange < 0) {
                GameManager.Interest.Cryminal += currentNews.CriminalChange;
                GameManager.Audience += currentNews.CriminalChange * Random.Range(10, 30);
            }
        }
        int income = GameManager.CountIncomeFromNew(currentNews);
    }

    public void OnClick() {
        if (okButtonText.text == "OK") {
            WomenAnimation.clip = womenIdle;
            WomenAnimator.Play("WomenAnimationIdle");
            StartMiniGame();
            okButtonText.text = "STOP";

            RedText = GameObject.Find("Red Text").GetComponent<Text>();
            YellowText = GameObject.Find("Yellow Text").GetComponent<Text>();
            GreenText = GameObject.Find("Green Text").GetComponent<Text>();


            RedText.text = "";
            YellowText.text = "";
            GreenText.text = "";
            var currentNews = (News.AddingNews)news[0];
            if (currentNews.SportChange < 0) {
                RedText.text += currentNews.SportChange + " SPO\n";
                if (currentNews.SportChange / 2 != 0) YellowText.text += currentNews.SportChange / 2 + " SPO\n";
            }
            if (currentNews.ScienceChange < 0) {
                RedText.text += currentNews.ScienceChange + " SCI\n";
                if (currentNews.ScienceChange / 2 != 0) YellowText.text += currentNews.ScienceChange / 2 + " SCI\n";
            }
            if (currentNews.PoliticsChange < 0) {
                RedText.text += currentNews.PoliticsChange + " POL\n";
                if (currentNews.PoliticsChange / 2 != 0) YellowText.text += currentNews.PoliticsChange / 2 + " POL\n";
            }
            if (currentNews.FunChange < 0) {
                RedText.text += currentNews.FunChange + " ENT\n";
                if (currentNews.FunChange / 2 != 0) YellowText.text += currentNews.FunChange / 2 + " ENT\n";
            }
            if (currentNews.SocialChange < 0) {
                RedText.text += currentNews.SocialChange + " SOC\n";
                if (currentNews.SocialChange / 2 != 0) YellowText.text += currentNews.SocialChange / 2 + " SOC\n";
            }
            if (currentNews.CriminalChange < 0) {
                RedText.text += currentNews.CriminalChange + " CRI";
                if (currentNews.CriminalChange / 2 != 0) YellowText.text += currentNews.CriminalChange / 2 + " CRI";
            }


            if (currentNews.SportChange > 0) {
                GreenText.text += "+" + currentNews.SportChange + " SPO\n";
                YellowText.text += "+" +  currentNews.SportChange / 2 + " SPO\n";
            }
            if (currentNews.ScienceChange > 0) {
                GreenText.text += "+" + currentNews.ScienceChange + " SCI\n";
                YellowText.text += currentNews.ScienceChange / 2 + " SCI\n";
            }
            if (currentNews.PoliticsChange > 0) {
                GreenText.text += "+" + currentNews.PoliticsChange + " POL\n";
                YellowText.text += currentNews.PoliticsChange / 2 + " POL\n";
            }
            if (currentNews.FunChange > 0) {
                GreenText.text += "+" + currentNews.FunChange + " ENT\n";
                YellowText.text += currentNews.FunChange / 2 + " ENT\n";
            }
            if (currentNews.SocialChange > 0) {
                GreenText.text += "+" + currentNews.SocialChange + " SOC\n";
                YellowText.text += currentNews.FunChange / 2 + " ENT\n";
            }
            if (currentNews.CriminalChange > 0) {
                GreenText.text += "+" + currentNews.CriminalChange + " CRI";
                YellowText.text += currentNews.CriminalChange / 2 + " CRI";
            }
        }

        else if (okButtonText.text == "STOP") {
            okButtonText.text = "GOT IT";
            cloneMiniGameObject.GetComponent<MiniGame>().userPressedButton = true;
            okButtonComponent.interactable = false;
        }

        else if (okButtonText.text == "GOT IT")
        {
            WomenAnimation.clip = womenTalking;
            WomenAnimator.Play("WomenAnimation");
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