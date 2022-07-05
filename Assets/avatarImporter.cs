using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Wolf3D.ReadyPlayerMe.AvatarSDK;

public class avatarImporter : MonoBehaviour
{

    [SerializeField]
    private WebView webView;

    private GameObject importedAvatar;

    // Start is called before the first frame update
    void Start()
    {
        webView.CreateWebView();

        webView.OnAvatarCreated = LoadAvatar;
    }

    private void LoadAvatar(string url)
    {
        AvatarLoader avatar = new AvatarLoader();
        avatar.LoadAvatar(url, StoreAvatar);
    }

    void StoreAvatar(GameObject avatar)
    {
        importedAvatar = avatar;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
