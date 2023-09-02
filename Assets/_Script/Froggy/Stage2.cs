using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public static class Froggy
{
    // Start is called before the first frame update：
    public static void GoToLevel2()
    {
        ES3.SaveImage(ScreenShot(), "Screenshot.png");
        SceneManager.LoadScene(1);
    }

    public static Texture2D ScreenShot()
    {
        int width = 1920;
        int height = 1080;
        RenderTexture screenTexture = new RenderTexture(width, height, 16);
        Camera.main.targetTexture = screenTexture;
        RenderTexture.active = screenTexture;
        Camera.main.Render();
        Texture2D renderedTexture = new Texture2D(width, height);
        renderedTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        RenderTexture.active = null;
        Camera.main.targetTexture = null;
        screenTexture.Release();
        return renderedTexture;
    }
}

public class Stage2 : UnitySingleton_DR<Stage2>
{
    public SpriteRenderer Renderer;
    public VolumeProfile PostFX;
    private Bloom bloom;
    public float BloomIntensity1 = 10;
    public float BloomIntensity2 = 100;
    public UnityEvent EnergyFull;

    // Start is called before the first frame update：
    private void Start()
    {
        Renderer.sprite = TextureToSprite(ES3.LoadImage("Screenshot.png"));
    }

    private Sprite TextureToSprite(Texture2D t)
    {
        return Sprite.Create(t, new Rect(0, 0, t.width, t.height), Vector2.zero);
    }

    public void OnEnergyFull()
    {
        print("OnEnergyFull");
        EnergyFull.Invoke();
    }

    public void Ending()
    {
        PostFX.TryGet(out bloom);
        DOTween.To(() => bloom.intensity.value, x => bloom.intensity.value = x, BloomIntensity1, 3)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                DOTween.To(() => bloom.intensity.value, x => bloom.intensity.value = x, BloomIntensity2, 2)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        DOTween.To(() => bloom.intensity.value, x => bloom.intensity.value = x, 0, 1)
                        .SetDelay(1);
                        Ending();
                    });
            });
    }
}