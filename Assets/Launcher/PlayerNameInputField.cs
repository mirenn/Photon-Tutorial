using UnityEngine;
using UnityEngine.UI;

using System.Collections;

namespace Com.MyCompany.MyGame
{
    /// <summary>
    /// Player name input field. Let the user input his name, will appear above the player in the game.
    /// </summary>
    [RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour
    {
        #region Private Variables

        // Store the PlayerPref Key to avoid typos
        static string playerNamePrefKey = "PlayerName_new";

        #endregion

        #region MonoBehaviour CallBacks

        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start()
        {

            string defaultName = "";
            InputField _inputField = this.GetComponent<InputField>();
            if (_inputField != null)
            {
                if (PlayerPrefs.HasKey(playerNamePrefKey))
                {
                    defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                    _inputField.text = defaultName;
                }
            }

            PhotonNetwork.playerName = defaultName;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        /// </summary>
        /// <param name="value">The name of the Player</param>
        public void SetPlayerName(string value)//デフォルトで用意されていた関数だがこの方法では無理だった。バージョンによる使い方のち外かもしれない
        {
            // #Important
            PhotonNetwork.playerName = value + " "; // force a trailing space string in case value is an empty string, else playerName would not be updated.

            Debug.Log(value);
            PlayerPrefs.SetString(playerNamePrefKey, value);
            string a = PlayerPrefs.GetString(playerNamePrefKey);
            Debug.Log(a);
            //PlayerPrefs.Save();
        }

        public void SetPlayerName2(string value)
        {
            // #Important
            PhotonNetwork.playerName = value + " "; // force a trailing space string in case value is an empty string, else playerName would not be updated.
            InputField _inputField = this.GetComponent<InputField>();
            Debug.Log(_inputField.text);
            PlayerPrefs.SetString(playerNamePrefKey, _inputField.text);
            string a = PlayerPrefs.GetString(playerNamePrefKey);
            Debug.Log(a);
            //PlayerPrefs.Save();
        }
        #endregion
    }
}