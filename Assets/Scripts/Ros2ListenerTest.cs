using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ROS2;
public class Ros2ListenerTest : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<std_msgs.msg.String> chatter_sub;

    void Start()
    {
        ros2Unity = GetComponent<ROS2UnityComponent>();
    }

    void Update()
    {
        if (ros2Node == null && ros2Unity.Ok())
        {
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNode");
            chatter_sub = ros2Node.CreateSubscription<std_msgs.msg.String>(
              "chatter", msg => Debug.Log("Unity listener heard: [" + msg.Data + "]"));
        }
    }
}
