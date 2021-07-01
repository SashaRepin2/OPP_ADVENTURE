
using UnityEngine;
using UnityEngine.UI;
public class Easter_eggs : MonoBehaviour
{
    public Sprite bgImage;
    public Image image;
    private int clicksForUnlock;

    // Start is called before the first frame update
    void Start()
    {
        clicksForUnlock = 0;
    }


    public void OnClickEasterEgg()
    {
        if (clicksForUnlock >= 10)
        {
            image.sprite = bgImage;
        }
        else { clicksForUnlock++; }
    }
}
