using System;
using UnityEngine;

public class Clock : MonoBehaviour {

    public float TotalEnemyWaves;

    const float
        degreesPerHour = 30f,
        degreesPerMinute = 6f,
        degreesPerSecond = 6f;
    //degreesPerEnemyWave = 12.17f,
    //degreesPerSemester = 730;

    public Transform hoursTransform, minutesTransform, secondsTransform; // enemyWavesTransform, SemesterTransform; 

	public bool continuous;

	void Update () {
		if (continuous) {
			UpdateContinuous();
		}
		else {
			UpdateDiscrete();
		}
	}

	void UpdateContinuous () {
		TimeSpan time = DateTime.Now.TimeOfDay;
        //enemyWavesTransform.localRotation =
        //    Quaternion.Euler(0f, (float)time.TotalEnemyWaves * degreesPerEnemyWave, 0f);
        hoursTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
	}

	void UpdateDiscrete () {
		DateTime time = DateTime.Now;
        //enemyWavesTransform.localRotation =
        //    Quaternion.Euler(0f, time.EnemyWave * degreesPerEnemyWave, 0f);
        hoursTransform.localRotation =
			Quaternion.Euler(0f, time.Hour * degreesPerHour, 0f);
		minutesTransform.localRotation =
			Quaternion.Euler(0f, time.Minute * degreesPerMinute, 0f);
		secondsTransform.localRotation =
			Quaternion.Euler(0f, time.Second * degreesPerSecond, 0f);
	}
}