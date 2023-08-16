using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CodeBase.Logic.PlayingCard
{
  public class CardMove : MonoBehaviour
  {
    [SerializeField] private float _speed = 1;
    private Vector3 _prevPosition;
    
    public async UniTask FollowTrajectory(Vector3[] waypoints)
    {
      transform.position = waypoints[0];

      int targetWaypointIndex = 1;
      Vector3 targetWaypoint = waypoints[targetWaypointIndex];
      Vector3 lastWaypoint = waypoints.Last();
      
      while (transform.position != lastWaypoint)
      {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, _speed * Time.deltaTime);
        if (transform.position == targetWaypoint && targetWaypoint != lastWaypoint)
        {
          targetWaypointIndex++;
          targetWaypoint = waypoints[targetWaypointIndex];
        }

        await UniTask.Yield();
      }
    }
  }
}