/* GameBehaviour.cs */

using UnityEngine;
using System.Collections;

public class GameBehaviour : MonoBehaviour {
  public worldManager world {
    get {
      return worldManager.instance;
    }
  }
}