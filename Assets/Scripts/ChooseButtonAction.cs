using UnityEngine;
using UnityEngine.UI;

public class ChooseButtonAction : MonoBehaviour {
    public Color DisabledColor;
    public Color EnabledColor;
    public News.AddingNews attachedNews;
    public string categoryName;
    public bool isClickable = false;
    public bool isPressed = false;
    private Button thisButton;
    private Text thisButtonText;
    private Image thisButtonsImage;

    public Sprite enabledSprite;
    public Sprite disabledSprite;


    // Use this for initialization
    private void Start() {
        thisButton = gameObject.GetComponent<Button>();
        thisButtonText = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        thisButtonsImage = gameObject.GetComponent<Image>();
    }

    public void OnClick() {
        if (attachedNews.Header != "") {
            if (!isPressed) {
                if (GameManager.numberOfPressedButtons < GameManager.MaxNewsInDay) {
                    isPressed = true;
                    thisButtonsImage.sprite = enabledSprite;
                    thisButtonsImage.color = EnabledColor;
                    GameManager.numberOfPressedButtons++;
                }
            }
            else {
                isPressed = false;
                thisButtonsImage.sprite = disabledSprite;
                thisButtonsImage.color = DisabledColor;
                GameManager.numberOfPressedButtons--;
            }
        }
    }

    // Update is called once per frame
    private void Update() {
        if (attachedNews.Header == "") {
            thisButton.interactable = false;
        }
        else {
            thisButton.interactable = true;
        }
    }

    private void OnGUI() {
        if (attachedNews.Header != "") {
            thisButtonText.text = attachedNews.Header;
        }
        else {
            thisButtonText.text = "No news for now";
        }
        if (GameManager.currentGameState == GameManager.GameState.broadcasting && thisButton.interactable) {
            thisButton.interactable = false;
        }
    }
}