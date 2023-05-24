using UnityEngine;
using Mirror;

[DisallowMultipleComponent]
[AddComponentMenu("Network/Network Manager HUD")]
[RequireComponent(typeof(NetworkManager))]
[HelpURL("https://mirror-networking.gitbook.io/docs/components/network-manager-hud")]
public class NetworkManagerHUD : MonoBehaviour
{
    NetworkManager manager;
    private bool showStartButtons = true;
    private bool gameHasStarted = false;

    string gameName = "COLLOSSEUM";


    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    void OnGUI()
    {
        if (!gameHasStarted)
        {
            GUI.backgroundColor = Color.black;
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), GUIContent.none);

            GUIStyle labelStyle = new GUIStyle(GUI.skin.label);
            labelStyle.fontSize = 90;
            labelStyle.fontStyle = FontStyle.Bold;
            labelStyle.alignment = TextAnchor.MiddleCenter;
            labelStyle.normal.textColor = Color.red;

            GUI.contentColor = Color.white;
            GUI.Label(new Rect(0, 50, Screen.width, 100), gameName, labelStyle);

            GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
            buttonStyle.fontSize = 30;
            buttonStyle.alignment = TextAnchor.MiddleCenter;
            buttonStyle.normal.textColor = Color.white;
            buttonStyle.normal.background = MakeTex(2, 2, Color.white);

            GUIStyle buttonStyleHover = new GUIStyle(buttonStyle);
            buttonStyleHover.normal.textColor = Color.red;

            int buttonWidth = 300;
            int buttonHeight = 70;
            int buttonSpacing = 20;

            GUILayout.BeginArea(new Rect(Screen.width / 2 - buttonWidth / 2, 200, buttonWidth, buttonHeight * 3 + buttonSpacing * 2));

            if (showStartButtons)
            {
                if (!NetworkClient.active && Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    if (GUILayout.Button("Host Game", buttonStyle))
                    {
                        Debug.Log("Started Server");
                        manager.StartHost();
                        showStartButtons = false;
                        gameHasStarted = true;

                    }
                }

                GUILayout.Space(buttonSpacing);

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Join Game", buttonStyle))
                {
                    manager.StartClient();
                    showStartButtons = false;
                    gameHasStarted = true;

                }
                manager.networkAddress = GUILayout.TextField(manager.networkAddress);
                GUILayout.EndHorizontal();

                GUILayout.Space(buttonSpacing);

                if (Application.platform == RuntimePlatform.WebGLPlayer)
                {
                    GUILayout.Box("(  WebGL cannot be server  )");
                }
                else
                {
                    if (GUILayout.Button("Server Only", buttonStyle))
                    {
                        manager.StartServer();
                        showStartButtons = false;
                        gameHasStarted = true;

                    }
                }
            }

            GUILayout.EndArea();
        }
    }


    private Texture2D MakeTex(int width, int height, Color col)
    {
        Color[] pix = new Color[width * height];
        for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.SetPixels(pix);
        result.Apply();

        return result;
    }
}