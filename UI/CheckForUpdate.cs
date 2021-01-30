using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Process = System.Diagnostics.Process;
using Stopwatch = System.Diagnostics.Stopwatch;

public static class CheckForUpdate
{
    static string updateSite = "";

    public static IEnumerator Check(Text text, Button button)
    {
        button.interactable = false;
        if (updateSite.Length > 0)
        {
            if (updateSite != "no_update")
            {
                Process.Start(updateSite);
            }
            text.text = "检查更新";
            updateSite = "";
        }
        else
        {
            UnityWebRequest webRequest = UnityWebRequest.Get("https://gitee.com/fm2333/watermelon-3-d-update-check/raw/master/json/update.json");
            text.text = "检查更新中……";
            webRequest.SendWebRequest();
            Stopwatch timer = new Stopwatch();
            timer.Restart();
            bool timeout = false;
            while (!webRequest.isDone && !timeout)
            {
                float percent = Mathf.Round(timer.ElapsedMilliseconds / 100f) / 10f;
                text.text = "检查更新中：" + percent.ToString() + "s";
                if (timer.ElapsedMilliseconds > 5000)
                {
                    timeout = true;
                }
                yield return null;
            }
            try
            {
                if (webRequest.isHttpError || webRequest.isNetworkError)
                {
                    text.text = "更新检测失败";
                    updateSite = "no_update";
                    yield break;
                }

                UpdateInformation inf = JsonConvert.DeserializeObject<UpdateInformation>(webRequest.downloadHandler.text);
                if (inf.version > Const.VERSION)
                {
                    text.text = "点此下载更新";
                    updateSite = inf.download;
                }
                else
                {
                    text.text = "没有更新";
                    updateSite = "no_update";
                }
            }
            catch (Exception err)
            {
                text.text = "错误：" + err;
            }
        }
        button.interactable = true;
        yield break;
    }
}
