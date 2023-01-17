using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarChassis))]
public class Car : MonoBehaviour
{
    [SerializeField] CarChassis chassis;

    [SerializeField] private float maxMotorTorque;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float maxBrakeTorque;

    [SerializeField] private AnimationCurve engineTorqueCurve;

    [SerializeField] private int maxSpeed;

    public float LinearVelocity => chassis.LinearVelocity;
    public float WheelSpeed => chassis.GetWheelSpeed();
    public float MaxSpeed => maxSpeed;

    [SerializeField] private float linearVelocity;
    public float ThrottleControl;
    public float SteerControl;
    public float BrakeControl;

    private void Start()
    {
        chassis = GetComponent<CarChassis>();
    }

    private void FixedUpdate()
    {
        linearVelocity = LinearVelocity;

        float engineTorque = engineTorqueCurve.Evaluate(LinearVelocity);

        if (LinearVelocity >= maxSpeed)
        {
            engineTorque = 0;
        }

        chassis.MotorTorque = ThrottleControl;
        chassis.SteerAngle = SteerControl ;
        chassis.BrakeTorque = BrakeControl;
    }


}
