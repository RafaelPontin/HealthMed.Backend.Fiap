namespace HealthMed.Backend.Dominio.Entidades
{
    public abstract class Base
    {
        public Guid Id { get; private set; }

        public Base()
        {
            Id = Guid.NewGuid();
        }
        protected void DefinirId(Guid id)
        {
            Id = id;
        }
    }
}
