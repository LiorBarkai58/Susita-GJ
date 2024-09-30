namespace Utility
{
    public class Cooldown   
    {
        private float duration = 0f;//Maximum duration of a timer
        private float completeTime = 0f;
        
        public Cooldown(float duration){
            this.duration = duration;
            completeTime = 0;
        }
    }
}
