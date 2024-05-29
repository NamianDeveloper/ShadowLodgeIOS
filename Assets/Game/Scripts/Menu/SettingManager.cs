using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.iOS;

public class SettingManager : MonoBehaviour
{
    [SerializeField] private string policyRef;
    private UniWebView webView;
    public void OpenPolicy()
    {
        var webViewGameObject = new GameObject("UniWebView");
        webView = webViewGameObject.AddComponent<UniWebView>();

        webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        webView.Load(policyRef);

        webView.EmbeddedToolbar.Show();
        webView.Show();

        UniWebView.SetJavaScriptEnabled(true);

        webView.EmbeddedToolbar.SetDoneButtonText("X");
        webView.EmbeddedToolbar.SetGoBackButtonText("");
        webView.EmbeddedToolbar.SetGoForwardButtonText("");
        webView.OnShouldClose += (view) =>
        {
            return true;
        };
    }
    public void OpenShareApp()
    {

    }
    public void OpenRateUs()
    {
        Device.RequestStoreReview();
    }
}
