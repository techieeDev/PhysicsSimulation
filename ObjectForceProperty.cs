using static System.Math;


namespace Physics
{
    public partial class Object
    {
        public void AddTranslationForce(IForce force){
            double[] components = force.GetComponents();
             
            // Calculate acceleration
            double accelerationX = components[0] / Mass.Value;
            double accelerationY = components[1] / Mass.Value;

            // Update velocity
            double deltaSeconds = App.mainloop.deltaTime;

            double velocityX = Velocity.XValue + (accelerationX * deltaSeconds);
            double velocityY = Velocity.YValue + (accelerationY * deltaSeconds);

            // Update position
            double positionX = LocalPosition.XValue + (Velocity.XValue * deltaSeconds);
            double positionY = LocalPosition.YValue + (Velocity.YValue * deltaSeconds);

            // Update the object's position and velocity
            LocalPosition = CartesianVector.Instantiate(positionX, positionY);
            Velocity = CartesianVector.Instantiate(velocityX, velocityY);
        }

        public void AddTranslationForce(AbsoluteForce absoluteForce, Angle angle){
            double radians = angle.Radians;
            
            // Force components
            double forceX = absoluteForce.Value;
            double forceY = absoluteForce.Value;
          
            // X Component 

            if (Cos(radians) > 0)
                forceX *= Cos(angle.Radians);
            else
                forceX *= -Cos(angle.Radians);

            // Y Component

            if(Sin(radians) > 0)
                forceY *= Sin(radians);
            else
                forceY *= -Sin(radians);
            

            // Calculate acceleration
            double accelerationX = forceX / Mass.Value;
            double accelerationY = forceY / Mass.Value;

            // Update velocity
            double deltaSeconds = App.mainloop.deltaTime;
            
            double velocityX = Velocity.XValue + (accelerationX * deltaSeconds); 
            double velocityY = Velocity.YValue + (accelerationY * deltaSeconds);

            // Update position
            double positionX = LocalPosition.XValue + (Velocity.XValue * deltaSeconds);
            double positionY = LocalPosition.YValue + (Velocity.YValue * deltaSeconds);

            // Update the object's position and velocity
            LocalPosition = CartesianVector.Instantiate(positionX, positionY);
            Velocity = CartesianVector.Instantiate(velocityX, velocityY);
        }

        public double CalculateTorque(double forceMagnitude, double leverArmDistance, double angularAcceleration)
        {
            return Torque.Value + (leverArmDistance * forceMagnitude * angularAcceleration);
        }

        public double CalculateLeverArmDistance(Point initialPoint)
        {
            Point finalPoint = AnalyticGeometry.CalculateFinalPoint(LocalPosition, initialPoint);

            double perpendicularX = LocalPosition.XValue - finalPoint.x;
            double perpendicularY = LocalPosition.YValue - finalPoint.y;

            CartesianVector perpendicularVector = CartesianVector.Instantiate(perpendicularX, perpendicularY);

            double leverArmDistance = perpendicularVector.GetMagnitude();

            return leverArmDistance;
        }

        public void AddRotationForce(IForce force, Point initialPoint) {

            // Force Componenets & Magnitude
            double magnitude = force.GetMagnitude();
            double[] componenets = force.GetComponents();
            double forceX = componenets[0];
            double forceY = componenets[1];

            // Calculate Angle
            double theta = Atan2(forceY, forceX);

            // Calculate target angular velocity
            double deltaSeconds = App.mainloop.deltaTime;
            double targetAngularVelocity = theta / deltaSeconds;

            // Calculate angular displacement
            double angularDisplacement = targetAngularVelocity - AngularVelocity.Value;

            // Calculate angular acceleration
            double angularAcceleration = angularDisplacement / deltaSeconds;

            // Determine distance
            double leverArmDistance = CalculateLeverArmDistance(initialPoint);

            // Update torque
            double torque = CalculateTorque(magnitude, leverArmDistance, angularAcceleration);

            // Calculate angular velocity
            AngularVelocity.Value += angularAcceleration * deltaSeconds;

            // Update rotation
            double rotationRadians = LocalRotation.Radians + (AngularVelocity.Value * deltaSeconds);
            double rotationDegrees = LocalRotation.Degrees + Trigonometric.ConvertToDegrees(AngularVelocity.Value * deltaSeconds);

            // Update the object's rotation and torque
            LocalRotation.Radians = rotationRadians;
            LocalRotation.Degrees = rotationDegrees;
            Torque.Value = torque;
        }

        public void AddRotationForce(AbsoluteForce absoluteForce, double angle, Point initialPoint)
        {
            angle = Abs(angle);
            double radians = Trigonometric.ConvertToRadians(angle);
            double degrees = angle;

            // Force magnitude
            double magnitude = absoluteForce.Value;

            // Calculate target angular velocity
            double deltaSeconds = App.mainloop.deltaTime;
            double targetAngularVelocity = radians / deltaSeconds;

            // Calculate angular displacement
            double angularDisplacement = targetAngularVelocity - AngularVelocity.Value;
            
            // Calculate angular acceleration
            double angularAcceleration = angularDisplacement / deltaSeconds;

            // Determine distance
            double leverArmDistance = CalculateLeverArmDistance(initialPoint);

            // Update torque
            double torque = CalculateTorque(magnitude, leverArmDistance, angularAcceleration);

            // Calculate angular velocity
            AngularVelocity.Value += angularAcceleration * deltaSeconds;

            // Update rotation
            double rotationRadians = LocalRotation.Radians + (AngularVelocity.Value * deltaSeconds);
            double rotationDegrees = LocalRotation.Degrees + Trigonometric.ConvertToDegrees(AngularVelocity.Value * deltaSeconds);

            // Update the object's rotation and torque
            LocalRotation.Radians = rotationRadians;
            LocalRotation.Degrees = rotationDegrees;
            Torque.Value = torque;
        }
    }
}