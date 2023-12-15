using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FWC
{
    public class HoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
    {

        [SerializeField] float scaleChange = 1.1f;

        [SerializeField] AudioSource source;

        Button button;

        private void Start()
        {
            button = GetComponent<Button>();
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (button.interactable == true)
            {
            transform.localScale *= scaleChange;

            if (source.clip == null) return;
            
            source.PlayOneShot(source.clip);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (button.interactable == true)
            {
            transform.localScale = new Vector3(1, 1, 1);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (button.interactable == true)
            {
            transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

}
