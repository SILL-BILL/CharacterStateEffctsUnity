using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccordionContainer : MonoBehaviour
{
	[SerializeField] private RectTransform m_Container;
	[SerializeField] private RectTransform m_ParentLayoutGroupTransform;
	[SerializeField] private float m_AnimDuration = .5f;

	private bool m_IsOpen = false;
	
	void Awake()
	{
		if (!m_Container)
		{
			Debug.LogError("No container");
		}

		if (!m_Container.GetComponent<VerticalLayoutGroup>())
		{
			Debug.LogError("Container has no VerticalLayoutGroup");
		}
	}

	void Start()
	{
		closeImmediately();
	}


	#region ANIM_HANDLERS

		public void switchState()
		{
			if (m_IsOpen)
			{
				close();
			}
			else
			{
				open();
			}
		}
	
		public void open()
		{
			gameObject.SetActive(true);
			m_IsOpen = true;
			iTween.Stop(gameObject);
			iTween.ValueTo(gameObject, iTween.Hash(
				"from", m_Container.sizeDelta,
				"to", new Vector2(m_ParentLayoutGroupTransform.sizeDelta.x, GetComponent<VerticalLayoutGroup>().preferredHeight),
				"time", m_AnimDuration, "easetype", iTween.EaseType.easeOutSine,
				"onupdate", "resizeContainer"));
		}
		
		public void openImmediately()
		{
			if (Math.Abs(m_Container.sizeDelta.y - GetComponent<VerticalLayoutGroup>().preferredHeight) > float.Epsilon)
			{
				gameObject.SetActive(true);
				m_IsOpen = true;
				iTween.Stop(gameObject);
				m_Container.sizeDelta = new Vector2(m_ParentLayoutGroupTransform.sizeDelta.x, GetComponent<VerticalLayoutGroup>().preferredHeight);
				refreshParentLayoutGroup();
			}
		}
		
		public void close()
		{
			m_IsOpen = false;
			iTween.Stop(gameObject);
			iTween.ValueTo(gameObject, iTween.Hash(
				"from", m_Container.sizeDelta,
				"to", new Vector2(m_ParentLayoutGroupTransform.sizeDelta.x, 0),
				"time", m_AnimDuration, "easetype", iTween.EaseType.easeOutSine,
				"onupdate", "resizeContainer",
				"oncomplete", "onCloseComplete"));
		}
		
		public void closeImmediately()
		{
			if (Math.Abs(m_Container.sizeDelta.y) > float.Epsilon)
			{
				m_IsOpen = false;
				iTween.Stop(gameObject);
				m_Container.sizeDelta = new Vector2(m_ParentLayoutGroupTransform.sizeDelta.x, 0);
				refreshParentLayoutGroup();
				gameObject.SetActive(false);
			}
		}

		public void onCloseComplete()
		{
			gameObject.SetActive(false);
		}
		
		public void resizeContainer(Vector2 size)
		{
			m_Container.sizeDelta = size;
			refreshParentLayoutGroup();
		}

		private void refreshParentLayoutGroup()
		{
			if (m_ParentLayoutGroupTransform)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(m_ParentLayoutGroupTransform);
			}
		}

	#endregion ANIM_HANDLERS
		
}