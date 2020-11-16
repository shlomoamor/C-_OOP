namespace Ex03.GarageLogic
{
    public class Engine
    {
        protected float m_RemainingCapacity = 0;
        protected float m_MaxEngergyCapacity = 0;

        public float EngineCurrentCapacity
        {
            get { return m_RemainingCapacity; }
            set {m_RemainingCapacity = value; }
        }
        public virtual object Type
        {
            get;
        }
        public float MaxEngergyCapacity
        {
            get {return m_MaxEngergyCapacity; }
            set {m_MaxEngergyCapacity = value; }
        }


    }
}