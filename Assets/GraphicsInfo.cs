using System;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsInfo : MonoBehaviour
{
    private GameObject    textObject;
    private Canvas        canvas;
    private RectTransform textTransform;
    private RectTransform canvasRect;

    void Start()
    {
        var camera = GetComponent<Camera>();
        camera.backgroundColor = new Color(0.22f, 0.22f, 0.22f);
        // set background type to solid color
        camera.clearFlags = CameraClearFlags.SolidColor;
        
        // Create a Canvas
        GameObject canvasObject = new GameObject("Canvas");
        canvas       = canvasObject.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Add a CanvasScaler for proper scaling
        CanvasScaler canvasScaler = canvasObject.AddComponent<CanvasScaler>();
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        // Add a GraphicRaycaster (required for UI interaction, though not used here)
        canvasObject.AddComponent<GraphicRaycaster>();

        // Create a Text GameObject
        textObject = new GameObject("BufferSizeText");
        textObject.transform.SetParent(canvasObject.transform);
        
        

        // Add Text Component
        Text text = textObject.AddComponent<Text>();
        text.font = Resources.Load<Font>("arial");  

        text.alignment = TextAnchor.UpperLeft;
        text.fontSize  = 24;
        text.color     = new Color(0.71f, 0.71f, 0.71f);

        // Set the text to show the max graphics buffer size
        text.text = $"Max Graphics Buffer Size: {SystemInfo.maxGraphicsBufferSize / (1024 * 1024)} MB";
        // line break
        text.text += "\n";
        // Add the total system memory
        text.text += $"Total System Memory: {SystemInfo.systemMemorySize} MB";
        text.text += "\n";
        text.text += $"Processor Count: {SystemInfo.processorCount} ";
        text.text += "\n";
        text.text += $"Processor Type: {SystemInfo.processorType} ";
        text.text += "\n";
        text.text += $"Processor Frequency: {SystemInfo.processorFrequency} ";
        text.text += "\n";
        text.text += $"Processor Manufacturer: {SystemInfo.processorManufacturer } ";
        text.text += "\n";
        text.text += $"Graphics Device Name: {SystemInfo.graphicsDeviceName} ";
        text.text += "\n";
        text.text += $"Graphics Device Type: {SystemInfo.graphicsDeviceType} ";
        text.text += "\n";
        text.text += $"Graphics Device Vendor: {SystemInfo.graphicsDeviceVendor} ";
        text.text += "\n";
        text.text += $"Graphics Device Version: {SystemInfo.graphicsDeviceVersion} ";
        
        // Set pixel width and height to same as canvas
        textTransform = textObject.GetComponent<RectTransform>();
        canvasRect    = canvas.GetComponent<RectTransform>();

    }

    private void Update()
    {
        var width  = canvasRect.rect.width;
        var height = canvasRect.rect.height;
        width                          *= 0.98f;
        height                         *= 0.95f;
        textTransform.sizeDelta        =  new Vector2(width, height); // Match the canvas dimensions
        textTransform.anchorMin        =  new Vector2(0.5f, 0.5f);    // Anchor to the center
        textTransform.anchorMax        =  new Vector2(0.5f, 0.5f);    // Anchor to the center
        textTransform.pivot            =  new Vector2(0.5f, 0.5f);    // Set pivot to the center
        textTransform.anchoredPosition =  Vector2.zero;     
    }
}