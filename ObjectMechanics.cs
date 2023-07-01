namespace Physics
{
    public partial class Object
    {
        protected CartesianVector CalculateAcceleration(double forceX, double forceY){
            double accelerationX = Acceleration.XValue + (forceX / Mass.Value);
            double accelerationY = Acceleration.YValue + (forceY / Mass.Value);
            CartesianVector acceleration = CartesianVector.Instantiate(accelerationX, accelerationY);
            return acceleration;
        }

        protected CartesianVector CalculateVelocity(double deltaTime){
            double velocityX = Velocity.XValue + (Acceleration.XValue * deltaTime);
            double velocityY = Velocity.YValue + (Acceleration.YValue * deltaTime);
            CartesianVector velocity = CartesianVector.Instantiate(velocityX, velocityY);
            return velocity;
        }

        protected CartesianVector CalculatePosition(double deltaTime){
            double positionX = LocalPosition.XValue + (Velocity.XValue * deltaTime);
            double positionY = LocalPosition.YValue + (Velocity.YValue * deltaTime);
            CartesianVector position = CartesianVector.Instantiate(positionX, positionY);
            return position;
        }

        protected double CalculateTorque(double forceMagnitude, double leverArmDistance, double angularAcceleration){
            return Torque.Value + (leverArmDistance * forceMagnitude * angularAcceleration);
        }

        protected double CalculateLeverArmDistance(Point initialPoint){
            Point finalPoint = AnalyticGeometry.CalculateFinalPoint(LocalPosition, initialPoint);

            double perpendicularX = LocalPosition.XValue - finalPoint.x;
            double perpendicularY = LocalPosition.YValue - finalPoint.y;

            CartesianVector perpendicularVector = CartesianVector.Instantiate(perpendicularX, perpendicularY);

            double leverArmDistance = perpendicularVector.GetMagnitude();

            return leverArmDistance;
        }

        protected double CalculateAngularAcceleration(double angle, double deltaTime){
            double targetAngularVelocity = angle / deltaTime;

            double angularDisplacement = targetAngularVelocity - AngularVelocity.Value;

            double angularAcceleration = angularDisplacement / deltaTime;

            return angularAcceleration;
        }

        protected Angle CalculateRotation(double angularVelocity, double deltaTime) {
            double rotationDegrees = LocalRotation.Degrees + Trigonometric.ConvertToDegrees(AngularVelocity.Value * deltaTime);
            Angle theta = Angle.Instantiate(rotationDegrees);
            return theta;
        }
    }
}