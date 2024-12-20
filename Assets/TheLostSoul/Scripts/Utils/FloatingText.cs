using TMPro;
using UnityEngine;

namespace tls.utils
{
    public class FloatingText : MonoBehaviour
    {
        public float moveSpeed = 1.0f;
        public float fadeDuration = 1.0f;
        public string Text;

        private TMP_Text textMesh;
        private Color originalColor;
        private float timer;

        private Vector3 originalPos;

        void Start()
        {
            textMesh = GetComponent<TMP_Text>();
            originalColor = textMesh.color;
            timer = 0.0f;

            originalPos = transform.localPosition;
        }

        void OnEnable()
        {
            timer = 0.0f;
            if (textMesh != null)
            {
                textMesh.color = originalColor;
            }

            if (textMesh == null)
                textMesh = GetComponent<TMP_Text>();

            textMesh.text = Text;
            transform.position = Input.mousePosition;
        }

        void Update()
        {
            // Move the text upwards
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            // Fade out the text
            timer += Time.deltaTime;
            if (timer >= fadeDuration)
            {
                gameObject.SetActive(false);
                transform.localPosition = originalPos;
            }
            else
            {
                float alpha = Mathf.Lerp(1.0f, 0.0f, timer / fadeDuration);
                if (textMesh != null)
                {
                    textMesh.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
                }
            }
        }
    }
}