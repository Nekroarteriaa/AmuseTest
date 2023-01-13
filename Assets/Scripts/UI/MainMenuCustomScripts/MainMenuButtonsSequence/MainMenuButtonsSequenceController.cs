using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.MainMenuCustomScripts.MainMenuButtonsSequence
{
    public class MainMenuButtonsSequenceController : MonoBehaviour
    {
        [SerializeField] 
        private Button centerButton;

        [SerializeField] 
        private List<Button> leftButtons;

        [SerializeField] 
        private List<Button> rightButtons;

        [SerializeField] 
        private float offset;

        [SerializeField] 
        private float sequenceDuration;

        [SerializeField] 
        private List<Ease> eases;
        

        [SerializeField] 
        private UnityEvent onButtonsPrepared;
        
        [SerializeField] 
        private UnityEvent onButtonsInPosition;

        [SerializeField] private AudioSource buttonSFX;
        
        private List<Vector3> originalPositions;
        
        
        
        void SetListElementsInPosition(List<Button> list, Vector3 direction)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].transform.position += direction;
            }
        }

        public void PrepareButtons()
        {
            originalPositions = new List<Vector3>();
            originalPositions.Add(centerButton.transform.position);

            for (int i = 0; i < leftButtons.Count; i++)
            {
                originalPositions.Add(leftButtons[i].transform.position);
            }
          
            for (int i = 0; i < rightButtons.Count; i++)
            {
                originalPositions.Add(rightButtons[i].transform.position);
            }

            centerButton.transform.position += Vector3.down * offset; 
            SetListElementsInPosition(leftButtons, Vector3.left * offset);
            SetListElementsInPosition(rightButtons, Vector3.right * offset);
            
            onButtonsPrepared.Invoke();
        }

        public void BeginSequence()
        {
            int currentListIndex = 0;
            Sequence buttonSequence = DOTween.Sequence();
            
            buttonSequence.Append(centerButton.transform.DOMove(originalPositions[0], sequenceDuration)
                .SetEase(eases[0]).OnComplete(() =>
                {
                
                        DoPitchMagic();
                        centerButton.onClick.AddListener(DoPitchMagic);
                    
                }));
            
                
            buttonSequence.Join(leftButtons[0].transform
                .DOMove(originalPositions[1], sequenceDuration).SetEase(eases[1]).SetDelay(.3f).OnComplete(() =>
                {
                    DoPitchMagic();
                    leftButtons[0].onClick.AddListener(DoPitchMagic);
                }));
            
            buttonSequence.Join(leftButtons[1].transform
                .DOMove(originalPositions[2], sequenceDuration).SetEase(eases[2]).SetDelay(.4f)).OnComplete(() =>
            {
                DoPitchMagic();
                    leftButtons[1].onClick.AddListener(DoPitchMagic);
            });
            
            buttonSequence.Join(rightButtons[0].transform
                .DOMove(originalPositions[3], sequenceDuration).SetEase(eases[3]).SetDelay(.5f).OnComplete(() =>
            {
                DoPitchMagic();
                rightButtons[0].onClick.AddListener(DoPitchMagic);
            }));
            
            buttonSequence.Join(rightButtons[1].transform
                .DOMove(originalPositions[4], sequenceDuration).SetEase(eases[4]).SetDelay(.6f)).OnComplete(() =>
            {
                DoPitchMagic();
                rightButtons[1].onClick.AddListener(DoPitchMagic);
            });
            
            
            buttonSequence.OnPlay(() =>
            {
                onButtonsInPosition.Invoke();
            });
        }

        void DoPitchMagic()
        {
            float originalPitch = buttonSFX.pitch;
            buttonSFX.pitch = Random.Range(originalPitch - .20f, originalPitch);
            buttonSFX.Play();
            buttonSFX.pitch = originalPitch;
        }
    }
}