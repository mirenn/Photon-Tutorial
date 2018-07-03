using UnityEngine;
using System.Collections;

namespace Com.MyCompany.MyGame
{
    public class PlayerAnimatorManager : Photon.MonoBehaviour
    {
        //#region PUBLIC PROPERTIES
        public float DirectionDampTime = 5f;
        //#endregion

        #region MONOBEHAVIOUR MESSAGES

        private Animator animator;
        // Use this for initialization
        void Start()
        {
            animator = GetComponent<Animator>();
            if (!animator)
            {
                Debug.LogError("PlayerAnimatorManager is Missing Animator Component", this);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.isMine == false && PhotonNetwork.connected == true)
            {
                return;
            }

            if (!animator)
            {
                return;
            }

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (v < 0)
            {
                v = 0;
            }

            animator.SetFloat("Speed", h * h + v * v);

            animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
        }
        #endregion
    }
}