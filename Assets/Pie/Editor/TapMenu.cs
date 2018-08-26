using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

namespace Pie.Editor
{
    public sealed class MenuTap
    {
        [MenuItem("GameObject/Pie Object/3D Kit", priority = 2)]
        public static void GameObject_PieObject_3DKit()
        {
            GameObject kit = HierarchyAdder.Add("3D Kit");
            kit.transform.localPosition = Vector3.zero;
            kit.transform.localScale = Vector3.one;

            GameObject camera = HierarchyAdder.Add("3D Camera", new Camera(), new GUILayer());
            camera.transform.SetParent(kit.transform);
            camera.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            camera.transform.localScale = Vector3.one;
            camera.AddComponent<FlareLayer>();

            Camera cameraComponent = camera.GetComponent<Camera>();
            cameraComponent.clearFlags = CameraClearFlags.Skybox;
            cameraComponent.backgroundColor = new Color32(99, 160, 255, 5);
            cameraComponent.orthographic = false;
            cameraComponent.fieldOfView = 60;
            cameraComponent.farClipPlane = 1000;
            cameraComponent.depth = 0;
            cameraComponent.renderingPath = RenderingPath.UsePlayerSettings;
            cameraComponent.useOcclusionCulling = true;

            GameObject sun = new GameObject("Sun");
            sun.transform.SetParent(kit.transform);
            sun.transform.localPosition = new Vector3(0.0f, 1000.0f, 0.0f);
            sun.transform.rotation = Quaternion.Euler(50.0f, -30.0f, 0.0f);

            Light light = sun.AddComponent<Light>();
            light.type = LightType.Directional;
            light.color = new Color32(255, 244, 214, 255);
            light.intensity = 1;
            light.bounceIntensity = 1;
            light.shadows = LightShadows.Soft;
            light.shadowStrength = 1.0f;
            light.shadowBias = 0.05f;
            light.shadowNormalBias = 0.4f;
            light.shadowNearPlane = 0.2f;
            light.cookieSize = 10;

            GameObject models = HierarchyAdder.Add("Models");
            models.transform.SetParent(kit.transform);
            models.transform.localPosition = Vector3.zero;
            models.transform.localScale = Vector3.one;
        }

        [MenuItem("GameObject/Pie Object/2D Kit", priority = 2)]
        public static void GameObject_Pie_Create_2DKit()
        {
            GameObject kit = HierarchyAdder.Add("2D Kit");
            kit.AddComponent<EventSystem>();
            kit.AddComponent<StandaloneInputModule>();
            kit.transform.localPosition = Vector3.zero;
            kit.transform.localScale = Vector3.one;

            GameObject camera = HierarchyAdder.Add("2D Camera");
            camera.transform.SetParent(kit.transform);
            camera.transform.localPosition = new Vector3(0.0f, 0.0f, -100.0f);
            camera.transform.localScale = Vector3.one;

            Camera cameraComponent = camera.AddComponent<Camera>();
            cameraComponent.clearFlags = CameraClearFlags.SolidColor;
            cameraComponent.backgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            cameraComponent.orthographic = true;
            cameraComponent.orthographicSize = 5;
            cameraComponent.nearClipPlane = 0.3f;
            cameraComponent.farClipPlane = 100;
            cameraComponent.depth = 0;
            cameraComponent.useOcclusionCulling = true;
            cameraComponent.allowHDR = false;
            cameraComponent.allowMSAA = false;
            cameraComponent.allowDynamicResolution = false;

            string[] canvasNames = { "Background", "Game", "UI" };
            for (int i = 0; i < canvasNames.Length; ++i)
            {
                GameObject canvas = HierarchyAdder.Add(canvasNames[i], new RectTransform());
                canvas.transform.SetParent(kit.transform);

                Canvas canvasComponent = canvas.AddComponent<Canvas>();
                canvasComponent.renderMode = RenderMode.ScreenSpaceCamera;
                canvasComponent.pixelPerfect = true;
                canvasComponent.worldCamera = cameraComponent;
                canvasComponent.planeDistance = 100;
                canvasComponent.sortingOrder = i;

                CanvasScaler scaler = canvas.AddComponent<CanvasScaler>();
                scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                scaler.referenceResolution = new Vector2(1280.0f, 720.0f);
                scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
                scaler.referencePixelsPerUnit = 100;

                canvas.AddComponent<GraphicRaycaster>();
            }
        }
        [MenuItem("GameObject/Pie Object/Layer", priority = 2)]
        public static void GameObject_PieObject_Layer()
        {
            if (Selection.activeObject != null)
            {
                GameObject[] selectObjects = Selection.gameObjects;

                for (int i = 0; i < selectObjects.Length; ++i)
                {
                    GameObject Layer = HierarchyAdder.Add("Layer");
                    Layer.transform.SetParent(selectObjects[i].transform);
                    RectTransform rectTransform = Layer.AddComponent<RectTransform>();
                    rectTransform.anchorMax = Vector2.one;
                    rectTransform.anchorMin = Vector2.zero;
                    rectTransform.offsetMax = Vector2.zero;
                    rectTransform.offsetMin = Vector2.zero;
                    Layer.transform.localPosition = Vector3.zero;
                    Layer.transform.localScale = Vector3.one;
                }
            }
            else
            {
                GameObject Layer = HierarchyAdder.Add("Layer");
                RectTransform rectTransform = Layer.AddComponent<RectTransform>();
                rectTransform.anchorMax = Vector2.one;
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.offsetMax = Vector2.zero;
                rectTransform.offsetMin = Vector2.zero;
                Layer.transform.localPosition = Vector3.zero;
                Layer.transform.localScale = Vector3.one;
            }
        }

        [MenuItem("Pie/Basic Folder %&e")]
        public static void Pie_BasicFolder()
        {
            string[] folders =
            {
                "Resources/Scripts",
                "Resources/Scripts/CryptoScripts",
                "Resources/Sprites",
                "Resources/Models",
                "Resources/Models/Materials",
                "Resources/Shaders",
                "Resources/Actions",
                "Resources/Actions/Animations",
                "Resources/Actions/Mecanims",
                "Resources/Actions/KachiActions",
                "Resources/Sounds",
                "Resources/Fonts",
                "Resources/Prefabs",

                "ThirdParty/Scripts",
                "ThirdParty/Scripts/CryptoScripts",
                "ThirdParty/Sprites",
                "ThirdParty/Models",
                "ThirdParty/Models/Materials",
                "ThirdParty/Shaders",
                "ThirdParty/Actions",
                "ThirdParty/Actions/Animations",
                "ThirdParty/Actions/Mecanims",
                "ThirdParty/Actions/KachiActions",
                "ThirdParty/Sounds",
                "ThirdParty/Fonts",
                "ThirdParty/Prefabs",
            };

            for (int i = 0; i < folders.Length; ++i)
            {
                DirectoryInfo info = new DirectoryInfo(Application.dataPath + "/" + folders[i]);
                if (!info.Exists)
                {
                    info.Create();
                }
            }

            EditorApplication.update();
            AssetDatabase.Refresh();
        }

        [MenuItem("Pie/Tools/AssetBundler")]
        public static void Pie_Tools_AssetBundler()
        {
            //BundleBuilder.ShowWindow();
        }

        [MenuItem("Pie/Tools/Script Cryptor")]
        public static void Pie_Tools_ScriptCrytor()
        {
        }

        [MenuItem("Pie/Help")]
        public static void Pie_Help()
        {
            MessageBox.Show("Pie", "Pie v0.1 (http://blog.naver.com/mkachi)", new Vector2(320, 70));
        }
    }
}