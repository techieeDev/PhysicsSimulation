using static System.Math;


namespace Physics
{
    public partial class Object
    {
        public virtual void AddTranslationForce(IForce force, double deltaTime){
            double[] components = force.GetComponents();
             
            // Calculate acceleration
            CartesianVector acceleration = CalculateAcceleration(components[0], components[1]);

            // Calculate velocity
            CartesianVector velocity = CalculateVelocity(deltaTime);

            // Calculate position
            CartesianVector position = CalculatePosition(deltaTime);

            // Update the object's position, velocity, acceleration
            LocalPosition = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }

        public virtual void AddTranslationForce(AbsoluteForce absoluteForce, Angle angle, double deltaTime){
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
            CartesianVector acceleration = CalculateAcceleration(forceX, forceY);

            // Calculate velocity            
            CartesianVector velocity = CalculateVelocity(deltaTime);

            // Calculate position
            CartesianVector position = CalculatePosition(deltaTime);

            // Update the object's position and velocity
            LocalPosition = position;
            Velocity = velocity;
            Acceleration = acceleration;
        }

        public virtual void AddRotationForce(IForce force, Point initialPoint, double deltaTime) {

            // Force Componenets & Magnitude
            double magnitude = force.GetMagnitude();
            double[] componenets = force.GetComponents();
            double forceX = componenets[0];
            double forceY = componenets[1];

            // Calculate Angle
            double theta = Atan2(forceY, forceX);

            // Calculate angular acceleration
            double angularAcceleration = CalculateAngularAcceleration(theta, deltaTime);

            // Determine distance
            double leverArmDistance = CalculateLeverArmDistance(initialPoint);

            // Calculate torque
            double torque = CalculateTorque(magnitude, leverArmDistance, angularAcceleration);

            // Calculate angular velocity
            AngularVelocity.Value += angularAcceleration * deltaTime;

            // Calculate rotation
            Angle rotation = CalculateRotation(AngularVelocity.Value, deltaTime);

            // Update the object's rotation and torque
            LocalRotation = rotation;
            Torque.Value = torque;
        }

        public virtual void AddRotationForce(AbsoluteForce absoluteForce, double angle, Point initialPoint, double deltaTime)
        {
            double radians = Trigonometric.ConvertToRadians(angle);

            // Force magnitude
            double magnitude = absoluteForce.Value;
            
            // Calculate angular acceleration
            double angularAcceleration = CalculateAngularAcceleration(radians, deltaTime);

            // Determine distance
            double leverArmDistance = CalculateLeverArmDistance(initialPoint);

            // Calculate torque
            double torque = CalculateTorque(magnitude, leverArmDistance, angularAcceleration);

            // Calculate angular velocity
            AngularVelocity.Value += angularAcceleration * deltaTime;

            // Calculate rotation
            Angle rotation = CalculateRotation(AngularVelocity.Value, deltaTime);

            // Update the object's rotation and torque
            LocalRotation = rotation;
            Torque.Value = torque;
        }
    }
}