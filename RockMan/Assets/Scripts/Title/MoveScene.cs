using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class MoveScene : MonoBehaviour
{
    public string playerName;

    public static MoveScene Instance;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    [SerializeField] TMP_InputField inputField;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMP_InputField>();
    }


    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }


    public void SetName()
    {
        playerName = inputField.text;
        Debug.Log(playerName);
    }

}
