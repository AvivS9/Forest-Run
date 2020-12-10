using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Button PlayBtn, LeftBtn, RightBtn, JumpBtn;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        LeftBtn.interactable = false;
        RightBtn.interactable = false;
        JumpBtn.interactable = false;

    }

    public void setButtonsForGame()
    {
        PlayBtn.gameObject.SetActive(false);
        LeftBtn.interactable = true;
        RightBtn.interactable = true;
        JumpBtn.interactable = true;
    }
}
