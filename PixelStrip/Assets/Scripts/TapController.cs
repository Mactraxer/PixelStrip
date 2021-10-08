using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections.Generic;

public class TapController : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private Texture2D texture;
    [SerializeField] private int textureWidht;
    [SerializeField] private int textureHeight;
    private int censorPixels;

    private void Awake()
    {
        playerController = new PlayerController();
    }

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        playerController.MainMap.Tap.started += TapActionHandler;

        texture = MakeTexture(textureWidht, textureHeight);
        FillTexture(texture, Color.black);

        this.gameObject.GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(Vector2.zero, new Vector2(textureWidht, textureHeight)), Vector2.zero);

        texture.Apply();
        censorPixels = textureWidht * textureHeight;
    }

    private Texture2D MakeTexture(int widht, int height)
    {
        Texture2D newTexture = new Texture2D(widht, height, TextureFormat.RGBA32, false);
        newTexture.filterMode = FilterMode.Point;

        return newTexture;
    }
    private void TapActionHandler(InputAction.CallbackContext obj)
    {
        ClearPixels(texture, 10);
    }

    private void ClearPixels(Texture2D texture, int count)
    {
        if (censorPixels <= 0)
        {
            LevelManager.Instance.EndStage();
            Debug.Log("Уровень пройден!!!");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            ClearPixel(texture);
            censorPixels--;
        }

        texture.Apply();
    }

    private void ClearPixel(Texture2D texture)
    {
        int repeatCount = 0;
        int xPosition = UnityEngine.Random.Range(0, texture.width);
        int yPosition = UnityEngine.Random.Range(0, texture.height);
        while (texture.GetPixel(xPosition, yPosition) == Color.clear)
        {
            xPosition = UnityEngine.Random.Range(0, texture.width);
            yPosition = UnityEngine.Random.Range(0, texture.height);
            repeatCount++;

            if (repeatCount > 10_000)
            {
                Debug.Log("Loop over 10_000");
                return;
            }
        }

        texture.SetPixel(xPosition, yPosition, Color.clear);
        texture.Apply();
    }

   
    // Update is called once per frame
    void Update()
    {

    }

    private void FillRectTexture(Texture2D texture, int width, int height, Color color)
    {
        int originX = UnityEngine.Random.Range(0, texture.width);
        int originY = UnityEngine.Random.Range(0, texture.height);

        int numberColors = (originX + 1) * width + (originX + 1) * height;
        Color[] colors = new Color[numberColors];
        for(int i = 0; i < colors.Length; i++)
        {
            colors[i] = color;
        }

        texture.SetPixels(originX, originY, width, height, colors);
        texture.Apply();
    }

    private void FillTexture(Texture2D texture, Color color)
    {
        for(int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                texture.SetPixel(x, y, color);
            }
        }

        texture.Apply();
    }
}
