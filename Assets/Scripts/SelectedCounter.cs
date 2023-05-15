using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
  [SerializeField] CleanCounter cleanCounter;
  [SerializeField] private GameObject visualGameObject;

  private void Update() {
    if(Player.Instance.activeSelectedCounter == cleanCounter) {
      Show();
    } else {
      Hide();
    }
  }

  private void Show() {
    visualGameObject.SetActive(true);
  }

  private void Hide() {
    visualGameObject.SetActive(false);
  }

}
