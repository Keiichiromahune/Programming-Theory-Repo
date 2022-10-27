using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DemoBack : MonoBehaviour
{

    private int Hp;
    private float xposi;
    private float yposi;
    private float zposi;
    public TMP_Text hpText;
    public TMP_Text xText;
    public TMP_Text yText;
    public TMP_Text zText;

 

    private void Start()
    {
        Hp = GameManager.Instance.currentHp;
        xposi = GameManager.Instance.playerCurrentPosi.x;
        yposi = GameManager.Instance.playerCurrentPosi.y;
        zposi = GameManager.Instance.playerCurrentPosi.z;

        hpText.text = Hp.ToString();
        xText.text = xposi.ToString();
        yText.text = yposi.ToString();
        zText.text = zposi.ToString();
    }
    // Start is called before the first frame update
    public void OnClick()
    {
        GameManager.Instance.currentHp -= 30;
        SceneManager.LoadScene(1);
    }
}
