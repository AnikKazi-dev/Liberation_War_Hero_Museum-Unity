using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SymbolController : MonoBehaviour
{
    // Background
    Sprite[] bkgrounds;
    public Image bkground;
    Color m_NewColor_bkground;
    Texture m_MainTexture_bkground;

    // Symbol
    public Sprite[] sprites;    
    public Button b_R;
    public Button b_L;
    public Image Symbol;
    Texture m_MainTexture;
    Color m_NewColor;

    // Background Detail
    public Sprite[] bkg_Details;
    public Button b_R_bkg;
    public Button b_L_bkg;
    public Image bkg_Bar;
    Texture m_MainTexture_bkg;
    Color m_NewColor_bkg;

    // Border
    public Sprite[] frame;
    public Button b_R_frame;
    public Button b_L_frame;
    public Image frame_Bar;
    Texture m_MainTexture_frame;
    Color m_NewColor_frame;

    // Counters
    int count;
    int bkgCount;
    int frameCount;

    // Converters & Renderer
    Material[] m_Material;
    public GameObject[] GameObj;
    SpriteRenderer m_SpriteRenderer;

    // Color Sliders
    public Slider borderRed, borderGreen, borderBlue;
    float frameRed = 0;
    float frameBlue = 0;
    float frameGreen = 0;

    public Slider bkgRed, bkgGreen, bkgBlue;
    float bkground_Red = 1;
    float bkground_Blue = 1;
    float bkground_Green = 1;

    public Slider symRed, symGreen, symBlue;
    float m_Red = 1;
    float m_Blue = 0;
    float m_Green = 0;

    public Slider bkgDetRed, bkgDetGreen, bkgDetBlue;
    float bkg_Red = 0;
    float bkg_Blue = 0;
    float bkg_Green = 1;

    public void OnGUI()
    {

        // Border Color Slider
        //
        
        frameRed = borderRed.value;        
        frameGreen = borderGreen.value;        
        frameBlue = borderBlue.value;

        m_NewColor_frame = new Color(frameRed, frameGreen, frameBlue);
        frame_Bar.color = m_NewColor_frame;

        // Background Details Color Slider
        //        
        bkground_Red = bkgRed.value;
        bkground_Green = bkgGreen.value;
        bkground_Blue = bkgBlue.value;

        m_NewColor_bkground = new Color(bkground_Red, bkground_Green, bkground_Blue);
        bkground.color = m_NewColor_bkground;

        //Symbol Color Slider
        //
        m_Red = symRed.value;
        m_Green = symGreen.value;
        m_Blue = symBlue.value;

        m_NewColor = new Color(m_Red, m_Green, m_Blue);
        Symbol.color = m_NewColor;

        // Background Details Color Slider
        //
        bkg_Red = bkgDetRed.value;
        bkg_Green = bkgDetGreen.value;
        bkg_Blue = bkgDetBlue.value;

        m_NewColor_bkg = new Color(bkg_Red, bkg_Green, bkg_Blue);
        bkg_Bar.color = m_NewColor_bkg;        

    }

    void Start()
    {
        
        //Symbol = GetComponent<Image>();
        //count = 0;
        //bkgCount = 0;
                
        //m_SpriteRenderer = GetComponent<SpriteRenderer>();
        //m_SpriteRenderer.color = Color.blue;
    }

    void Update()
    {                      
            
    }  

    void Symbols()
    {
        //Load all sprites in the []s    
        sprites = Resources.LoadAll<Sprite>("Sprites");
        bkg_Details = Resources.LoadAll<Sprite>("Sprites");
        frame = Resources.LoadAll<Sprite>("Sprites");
    }

    //Select Bottons
    //
    public void On_Click_Button_R_Frame()
    {
        frameCount++;
        if (frameCount == frame.Length)
        {
            frameCount = 0;
        }
        frame_Bar.sprite = frame[frameCount];

    }
    public void On_Click_Button_L_Frame()
    {

        if (frameCount == 0)
        {
            frameCount = frame.Length;
        }
        frameCount--;
        frame_Bar.sprite = frame[frameCount];

    }

    public void On_Click_Button_R_BKG()
    {
        bkgCount++;
        if (bkgCount == bkg_Details.Length)
        {
            bkgCount = 0;
        }
        bkg_Bar.sprite = bkg_Details[bkgCount];
    }
    public void On_Click_Button_L_BKG()
    {
        
        if (bkgCount == 0)
        {
            bkgCount = bkg_Details.Length;
        }
        bkgCount--;
        bkg_Bar.sprite = bkg_Details[bkgCount];
    }

    public void On_Click_Button_R()
    {
        count++;
        if (count == sprites.Length)
        {
            count = 0;
        }
        Symbol.sprite = sprites[count];
    }
    public void On_Click_Button_L()
    {
        if (count == 0)
        {
            count = sprites.Length;
        }
        count--;
        Symbol.sprite = sprites[count];
    }

    //Convert and set sprites to Models in the scene.
    //
    public void On_Click_Gravar()
    {
        //Border sprite converter
        Texture2D croppedTexture_Frame = new Texture2D((int)frame_Bar.sprite.rect.width, (int)frame_Bar.sprite.rect.height);
        Color[] colorsFrame = croppedTexture_Frame.GetPixels();
        Color[] newColorsFrame = frame_Bar.sprite.texture.GetPixels((int)System.Math.Ceiling(frame_Bar.sprite.textureRect.x),
                                                     (int)System.Math.Ceiling(frame_Bar.sprite.textureRect.y),
                                                     (int)System.Math.Ceiling(frame_Bar.sprite.textureRect.width),
                                                     (int)System.Math.Ceiling(frame_Bar.sprite.textureRect.height));
        Debug.Log(colorsFrame.Length + "_" + newColorsFrame.Length);
        croppedTexture_Frame.SetPixels(newColorsFrame);
        croppedTexture_Frame.Apply();
        m_MainTexture_frame = croppedTexture_Frame;

        //Symbol sprite converter
        Texture2D croppedTexture = new Texture2D((int)Symbol.sprite.rect.width, (int)Symbol.sprite.rect.height);
        Color[] colors = croppedTexture.GetPixels();
        Color[] newColors = Symbol.sprite.texture.GetPixels((int)System.Math.Ceiling(Symbol.sprite.textureRect.x),
                                                     (int)System.Math.Ceiling(Symbol.sprite.textureRect.y),
                                                     (int)System.Math.Ceiling(Symbol.sprite.textureRect.width),
                                                     (int)System.Math.Ceiling(Symbol.sprite.textureRect.height));
        Debug.Log(colors.Length + "_" + newColors.Length);
        croppedTexture.SetPixels(newColors);
        croppedTexture.Apply();
        m_MainTexture = croppedTexture;

        //Background Detail sprite converter
        Texture2D croppedTexture_BKG = new Texture2D((int)bkg_Bar.sprite.rect.width, (int)bkg_Bar.sprite.rect.height);
        Color[] colors_BKG = croppedTexture.GetPixels();
        Color[] newColors_BKG = bkg_Bar.sprite.texture.GetPixels((int)System.Math.Ceiling(bkg_Bar.sprite.textureRect.x),
                                                     (int)System.Math.Ceiling(bkg_Bar.sprite.textureRect.y),
                                                     (int)System.Math.Ceiling(bkg_Bar.sprite.textureRect.width),
                                                     (int)System.Math.Ceiling(bkg_Bar.sprite.textureRect.height));
        Debug.Log(colors_BKG.Length + "_" + newColors_BKG.Length);
        croppedTexture_BKG.SetPixels(newColors_BKG);
        croppedTexture_BKG.Apply();
        m_MainTexture_bkg = croppedTexture_BKG;
        
        //Background sprite converter
        Texture2D croppedTexture_bkground = new Texture2D((int)bkground.sprite.rect.width, (int)bkground.sprite.rect.height);
        Color[] colors_bkground = croppedTexture.GetPixels();
        Color[] newColors_bkground = bkground.sprite.texture.GetPixels((int)System.Math.Ceiling(bkground.sprite.textureRect.x),
                                                     (int)System.Math.Ceiling(bkground.sprite.textureRect.y),
                                                     (int)System.Math.Ceiling(bkground.sprite.textureRect.width),
                                                     (int)System.Math.Ceiling(bkground.sprite.textureRect.height));
        Debug.Log(colors_bkground.Length + "_" + newColors_BKG.Length);
        croppedTexture_bkground.SetPixels(newColors_bkground);
        croppedTexture_bkground.Apply();
        m_MainTexture_bkground = croppedTexture_bkground;


        //Send alberdo to the flag materials        
        for (int i = 0; GameObj.Length > i; i++)
        {
            m_Material = GameObj[i].GetComponent<SkinnedMeshRenderer>().materials;

            m_Material[0].SetTexture("_MainTex", m_MainTexture_bkg);
            m_Material[0].SetColor("_Color", bkg_Bar.color);

            m_Material[1].SetTexture("_MainTex", m_MainTexture);
            m_Material[1].SetColor("_Color", Symbol.color);

            m_Material[2].SetTexture("_MainTex", m_MainTexture_bkground);
            m_Material[2].SetColor("_Color", bkground.color);

            m_Material[3].SetTexture("_MainTex", m_MainTexture_frame);
            m_Material[3].SetColor("_Color", frame_Bar.color);


        }

    }

}
