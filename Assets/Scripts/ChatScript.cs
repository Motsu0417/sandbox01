using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.PackageManager;
using System;

public class ChatScript : MonoBehaviour
{
    private string chatHistory;
    private PlayerController playerController;
    public GameObject chatInputFieldObject;
    public TMP_InputField chatInputField;
    public GameObject chatPannel;
    public Text chatHistoryText;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        chatInputField = chatInputFieldObject.GetComponent<TMP_InputField>();
        ClearChat();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(playerController.GetPlayerState() == PlayerController.PLAYERSTATE.PLAY)
            {
                playerController.SetPlayerState(PlayerController.PLAYERSTATE.CHAT);
                chatPannel.SetActive(true);
                chatInputField.Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(playerController.GetPlayerState() == PlayerController.PLAYERSTATE.CHAT)
            {
                playerController.SetPlayerState(PlayerController.PLAYERSTATE.PLAY);
                chatPannel.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            if(chatInputField.text.Length > 0)
            {
                AddChat(chatInputField.text);
                chatInputField.text = "";
                chatInputField.Select();
            }
        }
    }

    public bool AddChat(string text)
    {
        Debug.Log("Chat:" + text);
        if('/' == text[0])
        {
            string commandText = text.TrimStart('/').Trim();
            try
            {
                string[] args = commandText.Split(' ');
                Debug.Log(args[0]);
                if (args.Length == 0) throw new Exception("コマンドが設定されていません");
                string command = args[0];

                switch (command)
                {
                    case "clear":
                        ClearChat();
                        break;
                    default:
                        throw new Exception("コマンドが存在しません");
                }
            }
            catch (Exception e)
            {
                AddChat("Error!:" + e.Message);
                Debug.Log(e);
                return false;
            }
            return true;
        }
        chatHistory = (chatHistory + "\n" + text).Trim();
        chatHistoryText.text = chatHistory;
        return true;
    }

    public bool ClearChat()
    {
        chatHistory = "";
        chatHistoryText.text = "";
        return true;
    }
}
