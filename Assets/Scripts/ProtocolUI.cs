using UnityEngine;
using UnityEngine.UI;

public class ProtocolUI : MonoBehaviour
{

    public int id;

    public GameObject greyBoxBig;
    public Image greyBoxSmall;
    public Image bar;

    private Color gray = new Color32(239, 238, 238, 255);
    private Color blue = new Color32(29, 156, 155, 255);

    public void ResetUI()
    {
        greyBoxBig.SetActive(false);
        greyBoxSmall.color = gray;
        bar.color = blue;
    }


    public void Deselected()
    {
        greyBoxBig.SetActive(false);
        greyBoxSmall.color = Color.white;
        bar.color = gray;
    }

    public void Selected()
    {
        greyBoxBig.SetActive(true);
    }

}