using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    const string URI = "https://www.jma.go.jp/bosai/forecast/data/forecast/130000.json";  //東京の天気を調べるAPI(気象庁)
    [SerializeField] Light lt;
    [SerializeField] Material sunnySkybox;
    [SerializeField] Material cloudySkybox;
    [SerializeField] GameObject rainParticle;

    void Start()
    {
        StartCoroutine("ChangeSkybox");
    }

    // 　東京とゲームの天気を同期
    IEnumerator ChangeSkybox()
    {
        UnityWebRequest www = UnityWebRequest.Get(URI);

        yield return www.SendWebRequest();

        if (www.isHttpError || www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // unityUtilityでパース出来るように文字列追加
            string itemJson = "{\"Items\":" + www.downloadHandler.text + "}";

            JsonClass item = JsonUtility.FromJson<JsonClass>(itemJson);
            string itemString = item.Items[0].timeSeries[0].areas[0].weatherCodes[1]; //weatherCodes配列は、朝昼夜のうち昼を選択

            // 太陽の光の色を準備
            string sunnyColorCode = "#FFFAD7";
            string cloudyColorCode = "#1D1D1D";
            ColorUtility.TryParseHtmlString(sunnyColorCode, out Color sunnyColor);
            ColorUtility.TryParseHtmlString(cloudyColorCode, out Color cloudyColor);

            if(itemString.StartsWith("1"))
            {
                //晴れの場合
                RenderSettings.skybox = sunnySkybox;
                lt.color = sunnyColor;
                rainParticle.SetActive(false);
            }
            else if(itemString.StartsWith("2"))
            {
                // 曇りの場合
                RenderSettings.skybox = cloudySkybox;
                lt.color = cloudyColor;
                rainParticle.SetActive(false);

            }
            else if(itemString.StartsWith("3"))
            {
                // 雨の場合
                RenderSettings.skybox = cloudySkybox;
                lt.color = cloudyColor;
                rainParticle.SetActive(true);
            }
        }
    }
}
