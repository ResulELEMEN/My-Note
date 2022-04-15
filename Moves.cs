
// Bu class da 2 deger arasinda hareket, boyut, ve yon icin lineer ilerleme yapilmistir.
// ilk parametre suanki Transform 2. parametre hedeflenen transform 3. parametre suresini belirler.
// hareket zamani verilmesse timeLong'i alir. ve o surede hareketi tamamlar.

//In this class, linear progression is made for move, scale, and rotation between 2 values. 
//The first parameter is the current Transform. 2nd parameter target transform. 3rd parameter is the time
//If 'time' is not defined, 'timeLong' is set as defult


using System.Collections;
using UnityEngine;

public class Moves : MonoBehaviour
{
   
    [SerializeField] private float timeLong; //defult time parameter.

	/// <summary>
	/// reaches the target position linearly
	/// </summary>
	/// <param name="currentTransform">Current Position</param>
	/// <param name="target">Target Position</param>
	/// <param name="time">Move Time</param>
	/// <returns></returns>
	public IEnumerator Move(Transform currentTransform, Vector3 target, float time = 0)
    {
        time = time == 0 ? timeLong : time;
        float passed = 0f;
        Vector3 initPos = currentTransform.transform.position;
        while (passed < time)
        {
            passed += Time.deltaTime;
            float normalize = passed / time;
            Vector3 position = Vector3.Lerp(initPos, target, normalize);
            position.z = currentTransform.transform.position.z;
            currentTransform.transform.position = position;

            yield return null;
        }
    }

	/// <summary>
	/// reaches the target scale linearly
	/// </summary>
	/// <param name="currentTransform">Current Scale</param>
	/// <param name="target">Target Scale</param>
	/// <param name="time">Scale Time</param>
	/// <returns></returns>
	public IEnumerator Scale(Transform currentTransform, Vector3 target, float time = 0)
	{
		time = time == 0 ? timeLong : time;
		float passed = 0f;
		Vector3 init = currentTransform.transform.localScale;
		while (passed < time)
		{
			passed += Time.deltaTime;
			float normalized = passed / time;
			Vector3 current = Vector3.Lerp(init, target, normalized);
			currentTransform.localScale = current;
			yield return null;
		}
	}

	/// <summary>
	/// reaches the target rotate linearly
	/// </summary>
	/// <param name="currentTransform">Current Rotate</param>
	/// <param name="target">Target Rotate</param>
	/// <param name="time">Rotate Time</param>
	/// <returns></returns>
	public IEnumerator Rotate(Transform currentTransform, Transform target, float time = 0)
	{
		time = time == 0 ? timeLong : time;
		float passed = 0f;
		Quaternion init = currentTransform.rotation;
		while (passed < time)
		{
			passed += Time.deltaTime;
			var normalized = passed / time;
			Quaternion current = Quaternion.Lerp(init, target.rotation, normalized);
			currentTransform.rotation = current;
			yield return null;
		}
	}
}
