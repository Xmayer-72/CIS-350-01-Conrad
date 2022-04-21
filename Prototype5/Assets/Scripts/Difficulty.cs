using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    private Button self;

    public int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        self = gameObject.GetComponent<Button>();
        //self.onClick.AddListener(SetDifficulty);
    }

    public void SetDifficulty()
    {
        Debug.Log(gameObject.name + "was clicked");

        GameManager.Instance.StartGame(difficulty);
    }
}
