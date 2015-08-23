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

    // Use this for initialization
    private void Start() {
        thisButton = gameObject.GetComponent<Button>();
        thisButtonText = gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        thisButtonsImage = gameObject.GetComponent<Image>();
    }

    public void OnClick() {
        if (isClickable) {
            if (!isPressed) {
                if (GameManager.numberOfPressedButtons < GameManager.MaxNewsInDay) {
                    isPressed = true;
                    thisButtonsImage.color = EnabledColor;
                    GameManager.numberOfPressedButtons++;
                }
            }
            else {
                isPressed = false;
                thisButtonsImage.color = DisabledColor;
                GameManager.numberOfPressedButtons--;
            }
        }
    }

    // Update is called once per frame
    private void Update() {
        if (!attachedNews.Equals(null)) {
            isClickable = true;
        }
        else {
            isClickable = false;
        }
    }

    private void OnGUI() {
        if (attachedNews.Text != "") {
            thisButtonText.text = attachedNews.Header;
        }
        else {
            thisButtonText.text = "New topic will appear next day";
        }
    }
}